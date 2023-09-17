using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgEquip : Entity, IAwake, IUILogic
    {
        public Dictionary<int, Scroll_Item_Equip> ScrollItemEquipItems;
        public Dictionary<EquipPosition,ES_EquipSlot> EquipSlots;
        public List<Item> EquipList = new();
        public EquipPosition EquipPosition = EquipPosition.无;

        public DlgEquipViewComponent View { get => this.GetComponent<DlgEquipViewComponent>(); }
    }
}