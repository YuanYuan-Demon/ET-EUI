//using System.Collections.Generic;
//using MongoDB.Bson.Serialization.Attributes;

//namespace ET
//{
//    [ComponentOf]
//    public class TaskComponent : Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
//    {
//        [BsonIgnore]
//        public SortedDictionary<int, TaskInfo> TaskInfoDict = new SortedDictionary<int, TaskInfo>();

//        public List<TaskInfo> TaskInfoList = new List<TaskInfo>();

//        [BsonIgnore]
//        public HashSet<int> CurrentTaskSet = new HashSet<int>();
//        [BsonIgnore]
//        public M2C_UpdateTaskInfo M2CUpdateTaskInfo = new M2C_UpdateTaskInfo();
//    }
//}