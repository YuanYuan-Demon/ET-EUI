using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf(typeof(Item))]
    [FriendOf(typeof(Item))]
    public class EquipInfoComponent : Entity, IAwake, IDestroy, ISerializeToEntity, IDeserialize
    {
        public bool IsInited = false;

        /// <summary>
        /// 装备评分
        /// </summary>
        public int Score = 0;

        /// <summary>
        /// 装备品质
        /// </summary>
        public int Quality = 0;

        /// <summary>
        /// 装备词条列表
        /// </summary>
        [BsonIgnore]
        public List<AttributeEntry> EntryList = new();

        public int ConfigId => this.GetParent<Item>().ConfigId;
        public EquipConfig Config => EquipConfigCategory.Instance.Get(ConfigId);
    }
}