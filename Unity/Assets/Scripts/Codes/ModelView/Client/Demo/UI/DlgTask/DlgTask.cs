using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTask: Entity, IAwake, IUILogic
    {
        public List<TaskInfo> BranchTasks;
        public List<Scroll_Item_Task> ItemBranchTasks = new();
        public List<Scroll_Item_Task> ItemMainTasks = new();

        public List<TaskInfo> MainTasks;
        public bool ShowBranchTasks = false;
        public bool ShowMainTasks = true;
        public DlgTaskViewComponent View => this.GetComponent<DlgTaskViewComponent>();
    }
}