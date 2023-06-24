namespace ET.Server
{
    [FriendOf(typeof(EquipmentsComponent))]
    [FriendOf(typeof(BagComponent))]
    [FriendOf(typeof(Item))]
    public static class ItemUpdateNoticeHelper
    {
        public static void SyncAddItem(Unit unit, Item item, ItemContainerType containerType)
        {
            var message = new M2C_ItemUpdateOpInfo
            {
                ContainerType = (int)containerType,
                ItemInfo = item.ToMessage(),
                Op = (int)ItemOp.Add
            };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncRemoveItem(Unit unit, Item item, ItemContainerType containerType)
        {
            var message = new M2C_ItemUpdateOpInfo
            {
                ContainerType = (int)containerType,
                ItemInfo = item.ToMessage(false),
                Op = (int)ItemOp.Remove
            };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncAllBagItems(Unit unit)
        {
            M2C_AllItemsList message = new()
            {
                ContainerType = (int)ItemContainerType.Bag
            };
            BagComponent bagComponent = unit.GetComponent<BagComponent>();
            bagComponent ??= unit.AddComponent<BagComponent>();

            foreach (var item in bagComponent.ItemsDict.Values)
            {
                message.ItemInfoList.Add(item.ToMessage());
            }

            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncAllEquipItems(Unit unit)
        {
            M2C_AllItemsList m2CAllItemsList = new()
            {
                ContainerType = (int)ItemContainerType.RoleInfo
            };
            EquipmentsComponent equipmentsComponent = unit.GetComponent<EquipmentsComponent>();
            equipmentsComponent ??= unit.AddComponent<EquipmentsComponent>();

            foreach (var item in equipmentsComponent.EquipItems.Values)
            {
                m2CAllItemsList.ItemInfoList.Add(item.ToMessage());
            }
            MessageHelper.SendToClient(unit, m2CAllItemsList);
        }
    }
}