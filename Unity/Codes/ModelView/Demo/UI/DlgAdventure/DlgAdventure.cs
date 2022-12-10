using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgAdventure : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Level> ScrollItems_Level;
        public DlgAdventureViewComponent View { get => this.Parent.GetComponent<DlgAdventureViewComponent>(); }
    }
}