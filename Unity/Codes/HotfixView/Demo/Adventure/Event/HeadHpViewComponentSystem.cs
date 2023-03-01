using TMPro;
using UnityEngine;

namespace ET
{
    public static class HeadHpViewComponentSystem
    {
        public class HeadHpViewComponentAwakeSystem : AwakeSystem<HeadHpViewComponent>
        {
            public override void Awake(HeadHpViewComponent self)
            {
                GameObject go = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
                ReferenceCollector referenceCollector = go.GetComponent<ReferenceCollector>();
                self.HpBarGroup = referenceCollector.Get<GameObject>("HpBarGroup");
                self.HpBar = referenceCollector.Get<SpriteRenderer>("HpBar");
                self.HpText = referenceCollector.Get<TextMeshPro>("HpText");
            }
        }

        public static void SetVisible(this HeadHpViewComponent self, bool isShow)
        {
            self.HpBarGroup?.SetActive(isShow);
        }

        public static void SetHp(this HeadHpViewComponent self)
        {
            NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();

            int maxHp = numericComponent.GetAsInt(NumericType.MaxHp);
            int hp = numericComponent.GetAsInt(NumericType.Hp);
            self.HpText.text = $"{hp} / {maxHp}";
            self.HpBar.size = new Vector2((float)hp / maxHp, self.HpBar.size.y);
        }
    }
}