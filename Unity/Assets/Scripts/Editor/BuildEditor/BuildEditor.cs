using System;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace ET
{
    public enum PlatformType
    {
        None,
        Android,
        IOS,
        Windows,
        MacOS,
        Linux
    }

    public enum ConfigFolder
    {
        Localhost,
        Release,
        RouterTest,
        Benchmark
    }

    public enum BuildType
    {
        Development,
        Release
    }

    public class BuildEditor: EditorWindow
    {
        private PlatformType activePlatform;
        private BuildAssetBundleOptions buildAssetBundleOptions = BuildAssetBundleOptions.None;
        private BuildOptions buildOptions;
        private bool clearFolder;
        private CodeOptimization codeOptimization = CodeOptimization.Debug;
        private ConfigFolder configFolder;

        private GlobalConfig globalConfig;
        private bool isBuildExe;
        private bool isContainAB;
        private PlatformType platformType;

        private void OnEnable()
        {
            this.globalConfig = AssetDatabase.LoadAssetAtPath<GlobalConfig>("Assets/Resources/GlobalConfig.asset");

#if UNITY_ANDROID
			activePlatform = PlatformType.Android;
#elif UNITY_IOS
			activePlatform = PlatformType.IOS;
#elif UNITY_STANDALONE_WIN
            this.activePlatform = PlatformType.Windows;
#elif UNITY_STANDALONE_OSX
			activePlatform = PlatformType.MacOS;
#elif UNITY_STANDALONE_LINUX
			activePlatform = PlatformType.Linux;
#else
			activePlatform = PlatformType.None;
#endif
            this.platformType = this.activePlatform;
        }

        private void OnGUI()
        {
            this.platformType = (PlatformType)EditorGUILayout.EnumPopup(this.platformType);
            this.clearFolder = EditorGUILayout.Toggle("clean folder? ", this.clearFolder);
            this.isBuildExe = EditorGUILayout.Toggle("build exe?", this.isBuildExe);
            this.isContainAB = EditorGUILayout.Toggle("contain assetsbundle?", this.isContainAB);
            this.codeOptimization = (CodeOptimization)EditorGUILayout.EnumPopup("CodeOptimization ", this.codeOptimization);
            EditorGUILayout.LabelField("BuildAssetBundleOptions ");
            this.buildAssetBundleOptions = (BuildAssetBundleOptions)EditorGUILayout.EnumFlagsField(this.buildAssetBundleOptions);

            switch (this.codeOptimization)
            {
                case CodeOptimization.None:
                case CodeOptimization.Debug:
                    this.buildOptions = BuildOptions.Development | BuildOptions.ConnectWithProfiler;
                    break;
                case CodeOptimization.Release:
                    this.buildOptions = BuildOptions.None;
                    break;
            }

            GUILayout.Space(5);

            if (GUILayout.Button("BuildPackage"))
            {
                if (this.platformType == PlatformType.None)
                {
                    this.ShowNotification(new GUIContent("please select platform!"));
                    return;
                }

                if (this.platformType != this.activePlatform)
                {
                    switch (EditorUtility.DisplayDialogComplex("Warning!",
                                $"current platform is {this.activePlatform}, if change to {this.platformType}, may be take a long time", "change",
                                "cancel", "no change"))
                    {
                        case 0:
                            this.activePlatform = this.platformType;
                            break;
                        case 1:
                            return;
                        case 2:
                            this.platformType = this.activePlatform;
                            break;
                    }
                }

                BuildHelper.Build(this.platformType, this.buildAssetBundleOptions, this.buildOptions, this.isBuildExe, this.isContainAB,
                    this.clearFolder);
            }

            GUILayout.Label("");
            GUILayout.Label("Code Compile：");
            EditorGUI.BeginChangeCheck();
            this.globalConfig.CodeMode = (CodeMode)EditorGUILayout.EnumPopup("CodeMode: ", this.globalConfig.CodeMode);
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(this.globalConfig);
                AssetDatabase.SaveAssetIfDirty(this.globalConfig);
                AssetDatabase.Refresh();
            }

            if (GUILayout.Button("BuildModelAndHotfix"))
            {
                if (Define.EnableCodes)
                {
                    throw new Exception("now in ENABLE_CODES mode, do not need Build!");
                }

                BuildAssembliesHelper.BuildModel(this.codeOptimization, this.globalConfig);
                BuildAssembliesHelper.BuildHotfix(this.codeOptimization, this.globalConfig);

                AfterCompiling();

                ShowNotification("Build Model And Hotfix Success!");
            }

            if (GUILayout.Button("BuildModel"))
            {
                if (Define.EnableCodes)
                {
                    throw new Exception("now in ENABLE_CODES mode, do not need Build!");
                }

                BuildAssembliesHelper.BuildModel(this.codeOptimization, this.globalConfig);

                AfterCompiling();

                ShowNotification("Build Model Success!");
            }

            if (GUILayout.Button("BuildHotfix"))
            {
                if (Define.EnableCodes)
                {
                    throw new Exception("now in ENABLE_CODES mode, do not need Build!");
                }

                BuildAssembliesHelper.BuildHotfix(this.codeOptimization, this.globalConfig);

                AfterCompiling();

                ShowNotification("Build Hotfix Success!");
            }

            if (GUILayout.Button("Proto2CS"))
            {
                ToolsEditor.Proto2CS();
            }

            EditorGUILayout.BeginHorizontal();
            {
                this.configFolder = (ConfigFolder)EditorGUILayout.EnumPopup(this.configFolder, GUILayout.Width(200f));

                if (GUILayout.Button("ExcelExporter"))
                {
                    //Directory.Delete("Assets/Bundles/Config", true);
                    ToolsEditor.ExcelExporter(this.globalConfig.CodeMode, this.configFolder);

                    // 设置ab包
                    var assetImporter = AssetImporter.GetAtPath($"Assets/Bundles/Config");
                    assetImporter.assetBundleName = "Config.unity3d";
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(5);
        }

        [MenuItem("ET/Build Tool")]
        public static void ShowWindow()
        {
            GetWindow<BuildEditor>(DockDefine.Types);
        }

        private static void AfterCompiling()
        {
            Directory.CreateDirectory(BuildAssembliesHelper.CodeDir);

            // 设置ab包
            var assetImporter = AssetImporter.GetAtPath("Assets/Bundles/Code");
            assetImporter.assetBundleName = "Code.unity3d";
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("build success!");
        }

        public static void ShowNotification(string tips)
        {
            var game = GetWindow(typeof (EditorWindow).Assembly.GetType("UnityEditor.GameView"));
            game?.ShowNotification(new GUIContent($"{tips}"));
        }
    }
}