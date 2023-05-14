using TMPro;
using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.HeadHUDViewComponent))]
    public static class HeadHUDViewComponentSystem
    {
        #region 生命周期

        public class HeadHUDViewComponentAwakeSystem : AwakeSystem<HeadHUDViewComponent>
        {
            protected override void Awake(HeadHUDViewComponent self)
            {
                GameObject go = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;

                self.MainCamera = Camera.main;
                self.HeadPointTransform = go.Get<GameObject>("HeadHUD").transform;
                self.TMP_Name = go.Get<GameObject>("TMP_Name").GetComponent<TextMeshProUGUI>();
            }
        }

        public class HeadHUDViewComponentLateUpdateSystem : LateUpdateSystem<HeadHUDViewComponent>
        {
            protected override void LateUpdate(HeadHUDViewComponent self)
            {
                if (self.MainCamera == null) return;
                if (self.HeadPointTransform == null) return;

                self.HeadPointTransform.forward = self.MainCamera.transform.forward;
            }
        }

        public class HeadHUDViewComponentDestroySystem : DestroySystem<HeadHUDViewComponent>
        {
            protected override void Destroy(HeadHUDViewComponent self)
            {
                self.MainCamera = null;
                self.HeadPointTransform = null;
                self.TMP_Name = null;
            }
        }

        #endregion 生命周期

        public static void SetName(this HeadHUDViewComponent self, string name)
        {
            if (self.TMP_Name == null) return;
            self.TMP_Name.text = name;
        }
    }
}