using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class Item : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        //物品配置ID
        public int ConfigId = 0;

        public int Count = 0;

        [BsonIgnore]
        public ItemConfig Config => ItemConfigCategory.Instance.Get(ConfigId);

        public EquipConfig EquipConfig => EquipConfigCategory.Instance.Get(ConfigId);

        public bool IsEquip => Config.Type == ((int)ItemType.Equip);

        public bool CanStack => Config.StackLimit > 1;
    }
}