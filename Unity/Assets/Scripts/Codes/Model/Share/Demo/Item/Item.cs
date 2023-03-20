using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class Item : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        /// <summary>
        /// 物品配置ID
        /// </summary>
        public int ConfigId = 0;

        /// <summary>
        /// 物品品质
        /// </summary>
        public int Quality = 0;

        /// <summary>
        /// 物品配置数据
        /// </summary>
        [BsonIgnore]
        public ItemConfig Config => ItemConfigCategory.Instance.Get(ConfigId);
    }
}