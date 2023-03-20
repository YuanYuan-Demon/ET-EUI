using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgForge : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Production> ScrollItemProductions;
        public long MakeQueueTimer = 0;

        public DlgForgeViewComponent View { get => this.GetComponent<DlgForgeViewComponent>(); }
    }
}