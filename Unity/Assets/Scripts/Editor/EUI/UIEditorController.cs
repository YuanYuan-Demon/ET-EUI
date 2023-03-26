using UnityEditor;
using UnityEngine;

namespace ClientEditor
{
    internal class UIEditorController
    {
        [MenuItem("GameObject/SpawnEUICode", false, -2)]
        public static void CreateNewCode()
        {
            GameObject go = Selection.activeObject as GameObject;
            UICodeSpawner.SpawnEUICode(go);
        }

        [MenuItem("Assets/AssetBundle/NameUIPrefab")]
        public static void NameAllUIPrefab()
        {
            string suffix = ".unity3d";
            var selectAsset = Selection.GetFiltered<UnityEngine.Object>(SelectionMode.DeepAssets);
            foreach (var obj in selectAsset)
            {
                string prefabName = AssetDatabase.GetAssetPath(obj);
                //MARKER：判断是否是.prefab
                if (prefabName.EndsWith(".prefab") || prefabName.EndsWith(".unity") || prefabName.EndsWith(".spriteatlasv2"))
                {
                    Debug.Log(prefabName);
                    AssetImporter importer = AssetImporter.GetAtPath(prefabName);
                    importer.assetBundleName = obj.name.ToLower() + suffix;
                }
            }
            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }

        [MenuItem("Assets/AssetBundle/ClearABName")]
        public static void ClearABName()
        {
            UnityEngine.Object[] selectAsset = Selection.GetFiltered<UnityEngine.Object>(SelectionMode.DeepAssets);
            for (int i = 0; i < selectAsset.Length; i++)
            {
                string prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                AssetImporter importer = AssetImporter.GetAtPath(prefabName);
                importer.assetBundleName = string.Empty;
                Debug.Log(prefabName);
            }
            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
    }
}