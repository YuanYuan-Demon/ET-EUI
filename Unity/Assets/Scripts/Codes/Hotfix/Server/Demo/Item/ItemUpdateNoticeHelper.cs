namespace ET.Server
{
    [FriendOf(typeof(BagComponent))]
    [FriendOf(typeof(Item))]
    public static class ItemUpdateNoticeHelper
    {
        public static void SyncAddItem(Unit unit, Item item, ItemContainerType containerType, int count)
        {
            var message = new M2C_ItemUpdateOpInfo
            {
                ContainerType = containerType,
                ItemInfo = item.ToMessage(),
                Op = ItemOp.Add,
                Count = count
            };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncRemoveItem(Unit unit, Item item, ItemContainerType containerType, int count)
        {
            var message = new M2C_ItemUpdateOpInfo
            {
                ContainerType = containerType,
                ItemInfo = item.ToMessage(false),
                Op = ItemOp.Remove,
                Count = count
            };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncAllBagItems(Unit unit)
        {
            M2C_AllItemsList message = new()
            {
                ContainerType = ItemContainerType.Bag
            };
            BagComponent bagComponent = unit.GetComponent<BagComponent>();
            bagComponent ??= unit.AddComponent<BagComponent>();

            foreach (var item in bagComponent.ItemsDict.Values)
            {
                message.ItemInfoList.Add(item.ToMessage());
            }

            MessageHelper.SendToClient(unit, message);
        }

        //public static void SyncAllEquipItems(Unit unit)
        //{
        //    M2C_AllItemsList m2CAllItemsList = new()
        //    {
        //        ContainerType = (int)ItemContainerType.RoleInfo
        //    };
        //    EquipmentsComponent equipmentsComponent = unit.GetComponent<EquipmentsComponent>();
        //    equipmentsComponent ??= unit.AddComponent<EquipmentsComponent>();
        //    foreach (var item in equipmentsComponent.EquipItems.Values)
        //    {
        //        m2CAllItemsList.ItemInfoList.Add(item.ToMessage());
        //    }
        //    MessageHelper.SendToClient(unit, m2CAllItemsList);
        //}
    }
}