using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class TasksComponent: Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        /// <summary>
        ///     当前正在进行的任务(InProgress, Completed)
        /// </summary>
        [BsonIgnore]
        public Dictionary<int, TaskConfig> CurrentTaskSet = new();

        /// <summary>
        ///     存储接取过的任务(TaskState > None )
        /// </summary>
        [BsonIgnore]
        public SortedDictionary<int, TaskInfo> TaskInfos = new();
    }
}