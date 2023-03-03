using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgBag : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_BagItem> ScrollItemBagItems;
        public ItemType CurrentItemType;
        public int CurrentPageIndex = 0;
        public DlgBagViewComponent View { get => this.Parent.GetComponent<DlgBagViewComponent>(); }
    }
}