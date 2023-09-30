using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class Item: Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        //物品配置ID
        public int ConfigId = 0;

        public int Count = 0;

        [BsonIgnore]
        public ItemConfig Config => ItemConfigCategory.Instance.Get(this.ConfigId);

        public EquipConfig EquipConfig => EquipConfigCategory.Instance.Get(this.ConfigId);

        public bool IsEquip => this.Config.Type == ItemType.Equip;

        public bool CanStack => this.Config.StackLimit > 1;
    }
}