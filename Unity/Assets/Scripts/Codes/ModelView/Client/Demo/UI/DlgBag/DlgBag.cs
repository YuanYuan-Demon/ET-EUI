using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgBag: Entity, IAwake, IUILogic
    {
        public ItemType BagTab;
        public List<Item> ItemList;
        public List<Scroll_Item_BagItem> ScrollItemBagItems;

        public DlgBagViewComponent View => this.GetComponent<DlgBagViewComponent>();
    }
}