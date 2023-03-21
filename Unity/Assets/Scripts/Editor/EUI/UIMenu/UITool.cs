using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UITool
{
    [MenuItem("Assets/去除RaycastTarget")]
    private static void UncheckRaycastTarget()
    {
        var selectedObjs = Selection.GetFiltered<GameObject>(SelectionMode.DeepAssets);
        foreach (var go in selectedObjs)
        {
            var mkgs = go.GetComponentsInChildren<Graphic>();
            foreach (var mkg in mkgs)
            {
                mkg.raycastTarget = false;
            }

            var btns = go.GetComponentsInChildren<Button>();
            foreach (var btn in btns)
            {
                if (btn.targetGraphic != null)
                {
                    btn.targetGraphic.raycastTarget = true;
                }
            }

            var infds = go.GetComponentsInChildren<InputField>();
            foreach (var infd in infds)
            {
                if (infd.targetGraphic != null)
                    infd.targetGraphic.raycastTarget = true;
            }

            var tmpIpd = go.GetComponentsInChildren<TMP_InputField>();
            foreach (var infd in tmpIpd)
            {
                if (infd.targetGraphic != null)
                    infd.targetGraphic.raycastTarget = true;
            }
            Debug.Log($"已修改预制体[{go.name}]组件的Raycast");
            EditorUtility.SetDirty(go);
        }
    }
}