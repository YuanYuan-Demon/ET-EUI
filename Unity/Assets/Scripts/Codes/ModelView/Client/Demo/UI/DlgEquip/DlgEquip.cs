using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgEquip: Entity, IAwake, IUILogic
    {
        public List<Item> EquipList = new();
        public EquipPosition EquipPosition = EquipPosition.None;
        public Dictionary<EquipPosition, ES_EquipSlot> EquipSlots;
        public List<Scroll_Item_Equip> ScrollItemEquipItems;

        public DlgEquipViewComponent View => this.GetComponent<DlgEquipViewComponent>();
    }
}