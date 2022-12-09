using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoleInfo : Entity, IAwake, IUILogic
    {
        public readonly Dictionary<int, long> AttributeTable = new()
        {
            { NumericType.DamageValueAdd,NumericType.Power},
            { NumericType.MaxHpPct,NumericType.PhysicalStrength},
            { NumericType.DodgeFinalAdd,NumericType.Agile},
            { NumericType.MaxMpFinalPct,NumericType.Spirit},
        };

        public readonly Dictionary<int, long> AddingAttributes = new();

        public List<Scroll_Item_Attribute> ScrollItemAttributes;
        public DlgRoleInfoViewComponent View { get => this.Parent.GetComponent<DlgRoleInfoViewComponent>(); }
    }
}