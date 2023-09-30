using UnityEngine;

namespace ET.Client
{
    public class UIHelper
    {
        /// <summary>
        ///     查找子节点
        /// </summary>
        /// <OtherParam name="_target"></OtherParam>
        /// <OtherParam name="_childName"></OtherParam>
        /// <returns></returns>
        public static Transform FindDeepChild(GameObject _target, string _childName)
        {
            Transform resultTrs = null;
            resultTrs = _target.transform.Find(_childName);
            if (resultTrs == null)
            {
                foreach (Transform trs in _target.transform)
                {
                    resultTrs = FindDeepChild(trs.gameObject, _childName);
                    if (resultTrs != null)
                    {
                        return resultTrs;
                    }
                }
            }

            return resultTrs;
        }

        /// <summary>
        ///     根据泛型查找子节点
        /// </summary>
        /// <param name="_target"></param>
        /// <param name="_childName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindDeepChild<T>(GameObject _target, string _childName) where T : Component
        {
            Transform resultTrs = FindDeepChild(_target, _childName);
            if (resultTrs != null)
            {
                return resultTrs.gameObject.GetComponent<T>();
            }

            return null;
        }

        public static bool IsTouchedUI()
        {
            var touchedUI = false;
            if (Application.isMobilePlatform)
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    //Input.GetTouch(0).phase == TouchPhase.Began)
                    touchedUI = true;
                }
            }
            else if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                touchedUI = true;
            }

            return touchedUI;
        }
    }
}