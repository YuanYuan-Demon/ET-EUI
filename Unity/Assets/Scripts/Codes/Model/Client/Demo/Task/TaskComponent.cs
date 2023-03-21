using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class TaskComponent : Entity, IAwake, IDestroy
    {
        public SortedDictionary<int, TaskInfo> TaskInfoDict = new();

        public List<TaskInfo> TaskInfoList = new();
    }
}