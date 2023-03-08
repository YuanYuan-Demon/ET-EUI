using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    [ChildType(typeof(Item))]
#if SERVER
    public class EquipmentsComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize, IUnitCache
#else
    public class EquipmentsComponent : Entity, IAwake, IDestroy
#endif
    {
        /// <summary>
        /// Key: 装备位置
        /// Item: 装备道具
        /// </summary>
#if SERVER
        [BsonIgnore]
#endif

        public Dictionary<int, Item> EquipItems = new Dictionary<int, Item>();

#if SERVER

        [BsonIgnore]
        public M2C_ItemUpdateOpInfo message = new M2C_ItemUpdateOpInfo() { ContainerType = (int)ItemContainerType.RoleInfo };

#endif
    }
}