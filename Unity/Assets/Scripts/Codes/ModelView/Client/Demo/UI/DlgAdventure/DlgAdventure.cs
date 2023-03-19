using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgAdventure : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Level> ScrollItems_Level;
        public DlgAdventureViewComponent View { get => this.GetComponent<DlgAdventureViewComponent>(); }
    }
}