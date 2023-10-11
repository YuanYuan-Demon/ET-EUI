using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace ET
{
    public class CodeLoader: Singleton<CodeLoader>
    {
        private Assembly model;

        public void Start()
        {
            if (Define.EnableCodes)
            {
                var globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
                if (globalConfig.CodeMode != CodeMode.ClientServer)
                    throw new("ENABLE_CODES mode must use ClientServer code mode!");

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var types = AssemblyHelper.GetAssemblyTypes(assemblies);
                EventSystem.Instance.Add(types);
                foreach (var ass in assemblies)
                {
                    var name = ass.GetName().Name;
                    if (name == "Unity.Model.Codes")
                        this.model = ass;
                }
            }
            else
            {
                byte[] assBytes;
                byte[] pdbBytes;
                if (!Define.IsEditor)
                {
                    var dictionary = AssetsBundleHelper.LoadBundle("code.unity3d");
                    assBytes = ((TextAsset)dictionary["Model.dll"]).bytes;
                    pdbBytes = ((TextAsset)dictionary["Model.pdb"]).bytes;
                    if (Define.EnableIL2CPP)
                        HybridCLRHelper.Load();
                }
                else
                {
                    assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, "Model.dll"));
                    pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, "Model.pdb"));
                }

                this.model = Assembly.Load(assBytes, pdbBytes);
                this.LoadHotfix();
            }

            IStaticMethod start = new StaticMethod(this.model, "ET.Entry", "Start");
            start.Run();
        }

        // 热重载调用该方法
        public void LoadHotfix()
        {
            byte[] assBytes;
            byte[] pdbBytes;
            if (!Define.IsEditor)
            {
                var dictionary = AssetsBundleHelper.LoadBundle("code.unity3d");
                assBytes = ((TextAsset)dictionary["Hotfix.dll"]).bytes;
                pdbBytes = ((TextAsset)dictionary["Hotfix.pdb"]).bytes;
            }
            else
            {
                // 傻屌Unity在这里搞了个傻逼优化，认为同一个路径的dll，返回的程序集就一样。所以这里每次编译都要随机名字
                var logicFiles = Directory.GetFiles(Define.BuildOutputDir, "Hotfix_*.dll");
                if (logicFiles.Length != 1)
                    throw new("Logic dll count != 1");
                var logicName = Path.GetFileNameWithoutExtension(logicFiles[0]);
                assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.dll"));
                pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.pdb"));
            }

            var hotfixAssembly = Assembly.Load(assBytes, pdbBytes);

            var types = AssemblyHelper.GetAssemblyTypes(typeof (Game).Assembly, typeof (Init).Assembly, this.model, hotfixAssembly);

            EventSystem.Instance.Add(types);
        }
    }
}