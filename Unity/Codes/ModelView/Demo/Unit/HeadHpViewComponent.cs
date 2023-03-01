using TMPro;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class HeadHpViewComponent : Entity, IAwake, IDestroy
    {
        public GameObject HpBarGroup;
        public SpriteRenderer HpBar;
        public TextMeshPro HpText;
    }
}