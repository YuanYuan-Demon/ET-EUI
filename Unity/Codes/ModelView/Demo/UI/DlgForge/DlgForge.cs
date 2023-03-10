using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgForge : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Production> ScrollItemProductions;
        public long MakeQueueTimer = 0;
        public DlgForgeViewComponent View => this.Parent.GetComponent<DlgForgeViewComponent>();
    }
}