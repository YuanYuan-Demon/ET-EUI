namespace ET.Server
{
    [FriendOf(typeof (BagComponent))]
    [FriendOf(typeof (Item))]
    [FriendOfAttribute(typeof (EquipmentsComponent))]
    public static class ItemUpdateNoticeHelper
    {
        public static void SyncAddItem(Unit unit, Item item, ItemContainerType containerType)
        {
            var message = new M2C_ItemUpdateOpInfo { ContainerType = containerType, ItemInfo = item.ToMessage(), Op = ItemOp.Add };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncRemoveItem(Unit unit, Item item, ItemContainerType containerType)
        {
            var message = new M2C_ItemUpdateOpInfo { ContainerType = containerType, ItemInfo = item.ToMessage(false), Op = ItemOp.Remove };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncUpdateItem(Unit unit, Item item, ItemOp itemOp, ItemContainerType containerType)
        {
            var message = new M2C_ItemUpdateOpInfo { ContainerType = containerType, ItemInfo = item.ToMessage(itemOp == ItemOp.Add), Op = itemOp };
            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncAllBagItems(Unit unit)
        {
            M2C_AllItemsList message = new() { ContainerType = ItemContainerType.Bag };
            var bagComponent = unit.GetComponent<BagComponent>();
            bagComponent ??= unit.AddComponent<BagComponent>();

            foreach (var item in bagComponent.AllItemsDict.Values)
            {
                message.ItemInfoList.Add(item.ToMessage());
            }

            MessageHelper.SendToClient(unit, message);
        }

        public static void SyncAllEquipItems(Unit unit)
        {
            M2C_AllItemsList m2CAllItemsList = new() { ContainerType = ItemContainerType.RoleInfo };
            var ec = unit.GetComponent<EquipmentsComponent>();
            ec ??= unit.AddComponent<EquipmentsComponent>();
            foreach (var item in ec.EquipedItems.Values)
            {
                m2CAllItemsList.ItemInfoList.Add(item.ToMessage());
            }

            MessageHelper.SendToClient(unit, m2CAllItemsList);
        }
    }
}