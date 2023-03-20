using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    public class ForgeComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer, IUnitCache
    {
        /// <summary>
        /// Key: ProductionId
        /// <para>Value: TimerId</para>
        /// </summary>

        [BsonIgnore]
        public Dictionary<long, long> ProductionTimerDict = new();

        /// <summary>
        /// 生产队列
        /// </summary>
        [BsonIgnore]
        public List<Production> ProductionsList = new();
    }
}