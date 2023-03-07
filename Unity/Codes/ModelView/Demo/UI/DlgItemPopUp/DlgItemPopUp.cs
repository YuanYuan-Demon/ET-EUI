﻿using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemPopUp : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Entry> ScrollItemEntries;
        public long ItemId = 0;
        public ItemContainerType ItemContainerType = ItemContainerType.Bag;
        public DlgItemPopUpViewComponent View { get => this.Parent.GetComponent<DlgItemPopUpViewComponent>(); }
    }
}