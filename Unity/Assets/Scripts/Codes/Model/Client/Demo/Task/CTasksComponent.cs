using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class CTasksComponent: Entity, IAwake, IDestroy
    {
        public SortedDictionary<int, TaskInfo> AllTasks = new();

        public List<TaskInfo> TaskInfoList;
    }
}