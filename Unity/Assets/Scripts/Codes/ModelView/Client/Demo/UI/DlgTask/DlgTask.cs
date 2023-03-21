using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTask : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Task> ScrollItemTasks;

        public DlgTaskViewComponent View { get => this.GetComponent<DlgTaskViewComponent>(); }
    }
}