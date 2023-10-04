using UnityEditor;
using UnityEngine;

namespace ClientEditor
{
    internal class UIEditorController
    {
        [MenuItem("Assets/EUI/SpawnEUICode", false)]
        [MenuItem("GameObject/SpawnEUICode", false, -2)]
        public static void CreateNewCode()
        {
            // var go = Selection.activeObject as GameObject;
            var selectedObjs = Selection.GetFiltered<GameObject>(SelectionMode.DeepAssets);
            foreach (var go in selectedObjs)
            {
                UICodeSpawner.SpawnEUICode(go);
            }
        }

        [MenuItem("Assets/AssetBundle/NameUIPrefab")]
        public static void NameAllUIPrefab()
        {
            var suffix = ".unity3d";
            var selectAsset = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            for (var i = 0; i < selectAsset.Length; i++)
            {
                var prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                //MARKER：判断是否是.prefab
                if (prefabName.EndsWith(".prefab"))
                {
                    Debug.Log(prefabName);
                    var importer = AssetImporter.GetAtPath(prefabName);
                    importer.assetBundleName = selectAsset[i].name.ToLower() + suffix;
                }
            }

            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }

        [MenuItem("Assets/AssetBundle/ClearABName")]
        public static void ClearABName()
        {
            var selectAsset = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            for (var i = 0; i < selectAsset.Length; i++)
            {
                var prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                var importer = AssetImporter.GetAtPath(prefabName);
                importer.assetBundleName = string.Empty;
                Debug.Log(prefabName);
            }

            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
    }
}