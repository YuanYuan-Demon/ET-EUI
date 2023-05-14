using TMPro;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class HeadHUDViewComponent : Entity, IAwake, ILateUpdate, IDestroy
    {
        public Transform HeadPointTransform;
        public TextMeshProUGUI TMP_Name;
        public Camera MainCamera;
    }
}