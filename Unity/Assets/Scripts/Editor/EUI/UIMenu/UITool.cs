using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UITool
{
    [MenuItem("Assets/去除RaycastTarget")]
    private static void UncheckRaycastTarget()
    {
        var selectedObjs = Selection.GetFiltered<GameObject>(SelectionMode.DeepAssets);
        foreach (GameObject go in selectedObjs)
        {
            var mkgs = go.GetComponentsInChildren<Graphic>();
            foreach (Graphic mkg in mkgs)
            {
                mkg.raycastTarget = false;
            }

            var selelctObjs = go.GetComponentsInChildren<Selectable>();
            foreach (Selectable s in selelctObjs)
            {
                Navigation nav = s.navigation;
                nav.mode = Navigation.Mode.None;
                s.navigation = nav;

                if (s.targetGraphic != null)
                {
                    s.targetGraphic.raycastTarget = true;
                }
            }

            //var infds = go.GetComponentsInChildren<InputField>();
            //foreach (var infd in infds)
            //{
            //    if (infd.targetGraphic != null)
            //        infd.targetGraphic.raycastTarget = true;
            //}

            //var tmpIpd = go.GetComponentsInChildren<TMP_InputField>();
            //foreach (var infd in tmpIpd)
            //{
            //    if (infd.targetGraphic != null)
            //        infd.targetGraphic.raycastTarget = true;
            //}

            var loopList = go.GetComponentsInChildren<LoopScrollRectBase>();
            foreach (LoopScrollRectBase list in loopList)
            {
                list.transform.GetComponentInChildren<Image>().raycastTarget = true;
            }

            Transform mask = go.transform.Find("Mask");
            if (mask != null && mask.TryGetComponent<Image>(out Image image))
            {
                image.raycastTarget = true;
            }

            Debug.Log($"已修改预制体[{go.name}]组件的Raycast");
            EditorUtility.SetDirty(go);
        }
    }
}