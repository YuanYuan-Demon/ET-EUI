using TMPro;
using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof (HeadHUDViewComponent))]
    public static class HeadHUDViewComponentSystem
    {
        public static void SetHp(this HeadHUDViewComponent self, int hp) => self.ES_HpBar.SetValue(hp);

#region 生命周期

        public class HeadHUDViewComponentAwakeSystem: AwakeSystem<HeadHUDViewComponent, string>
        {
            protected override void Awake(HeadHUDViewComponent self, string name)
            {
                var unit = self.GetParent<Unit>();
                self.HeadPointTransform = unit.GetComponent<GameObjectComponent>().GameObject.transform.Find("HeadHUD");

                self.TMP_Name = self.HeadPointTransform.Find(nameof (self.TMP_Name)).GetComponent<TextMeshProUGUI>();
                self.TMP_Name.text = name;

                self.MainCamera = Camera.main;

                Transform hpBarTrans = self.HeadPointTransform.Find(nameof (self.ES_HpBar));
                self.ES_HpBar = self.AddChild<ES_Slider, Transform>(hpBarTrans);

                int maxHp = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MaxHp);
                self.ES_HpBar.InitMax(maxHp);
            }
        }

        public class HeadHUDViewComponentLateUpdateSystem: LateUpdateSystem<HeadHUDViewComponent>
        {
            protected override void LateUpdate(HeadHUDViewComponent self) => self.HeadPointTransform.forward = self.MainCamera.transform.forward;
        }

#endregion
    }
}