using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class TasksComponent : Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        [BsonIgnore]
        public SortedDictionary<int, TaskInfo> TaskInfoDict = new();

        [BsonIgnore]
        public HashSet<int> CurrentTaskSet = new();
    }
}