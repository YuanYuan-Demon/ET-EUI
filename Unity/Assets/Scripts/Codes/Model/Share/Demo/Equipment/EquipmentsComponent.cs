using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    public class EquipmentsComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize, IUnitCache
    {
        /// <summary>
        /// Key: 装备位置
        /// Item: 装备道具
        /// </summary>
        [BsonIgnore]
        public Dictionary<int, Item> EquipItems = new();
    }
}