using TMPro;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class HeadHUDViewComponent: Entity, ILateUpdate, IDestroy, IAwake<string>, IUpdate
    {
        public ES_Slider ES_HpBar;
        public Transform HeadPointTransform;
        public Camera MainCamera;
        public TextMeshProUGUI TMP_Name;
    }
}