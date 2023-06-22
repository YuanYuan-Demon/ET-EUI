using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgBag : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_BagItem> ScrollItemBagItems;
        public List<Item> ItemList;

        public ItemType BagTab;

        public DlgBagViewComponent View { get => this.GetComponent<DlgBagViewComponent>(); }
    }
}