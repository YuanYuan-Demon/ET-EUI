using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRank : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Rank> ScrollItemRanks;
        public long Timer = 0;
        public DlgRankViewComponent View => this.Parent.GetComponent<DlgRankViewComponent>();
    }
}