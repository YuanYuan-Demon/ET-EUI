using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    public class BagComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer, IUnitCache
    {
        /// <summary>
        /// Key: ItemId
        /// Value: Item
        /// </summary>
        [BsonIgnore]
        public Dictionary<long, Item> ItemsDict = new();

        /// <summary>
        /// Key: ItemType   (武器,防具,戒指,道具)
        /// Value: Item
        /// </summary>
        [BsonIgnore]
        public MultiMap<int, Item> ItemsMap = new();
    }
}