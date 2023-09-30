using UnityEditor;
using UnityEngine;

namespace ClientEditor
{
    internal class UIEditorController
    {
        [MenuItem("Assets/EUI/SpawnEUICode", false)]
        public static void CreateNewCode()
        {
            // var go = Selection.activeObject as GameObject;
            GameObject[] selectedObjs = Selection.GetFiltered<GameObject>(SelectionMode.DeepAssets);
            foreach (GameObject go in selectedObjs)
            {
                UICodeSpawner.SpawnEUICode(go);
            }
        }

        [MenuItem("Assets/AssetBundle/NameUIPrefab")]
        public static void NameAllUIPrefab()
        {
            var suffix = ".unity3d";
            Object[] selectAsset = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            for (var i = 0; i < selectAsset.Length; i++)
            {
                string prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                //MARKER：判断是否是.prefab
                if (prefabName.EndsWith(".prefab"))
                {
                    Debug.Log(prefabName);
                    AssetImporter importer = AssetImporter.GetAtPath(prefabName);
                    importer.assetBundleName = selectAsset[i].name.ToLower() + suffix;
                }
            }

            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }

        [MenuItem("Assets/AssetBundle/ClearABName")]
        public static void ClearABName()
        {
            Object[] selectAsset = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            for (var i = 0; i < selectAsset.Length; i++)
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