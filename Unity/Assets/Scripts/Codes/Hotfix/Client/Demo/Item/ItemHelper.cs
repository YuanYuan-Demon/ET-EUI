namespace ET.Client
{
    public static class ItemHelper
    {
        public static void Clear(Scene ZoneScene, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene?.GetComponent<BagComponent>()?.Clear();
                    break;

                case ItemContainerType.Equip:
                    ZoneScene?.GetComponent<EquipmentsComponent>()?.Clear();
                    break;
            }
        }

        public static Item GetItem(Scene ZoneScene, long itemId, ItemContainerType itemContainerType) => itemContainerType switch
        {
            ItemContainerType.Bag => ZoneScene.GetComponent<BagComponent>().GetItemById(itemId),
            ItemContainerType.Equip => ZoneScene.GetComponent<EquipmentsComponent>().GetItemById(itemId),
            _ => null,
        };

        public static void AddItem(Scene ZoneScene, ItemInfo itemInfo, ItemContainerType itemContainerType)
        {
            var item = ItemFactory.Create(ZoneScene, itemInfo);
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene.GetComponent<BagComponent>().AddItem(item);
                    break;

                case ItemContainerType.Equip:
                    ZoneScene.GetComponent<EquipmentsComponent>().AddEquipItem(item);
                    break;
            }
        }

        public static void UpdateItem(Scene ZoneScene, ItemInfo itemInfo, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene.GetComponent<BagComponent>().UpdateItem(itemInfo);
                    break;

                default:
                    Log.Error("不合法的容器类型");
                    break;
            }
        }

        public static void RemoveItemById(Scene ZoneScene, long itemId, ItemContainerType itemContainerType)
        {
            var item = GetItem(ZoneScene, itemId, itemContainerType);
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene.GetComponent<BagComponent>().RemoveItem(item);
                    break;

                case ItemContainerType.Equip:
                    ZoneScene.GetComponent<EquipmentsComponent>().UnloadEquipItem(item);
                    break;
            }
        }

        public static void RemoveItem(Scene ZoneScene, Item item, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene.GetComponent<BagComponent>().RemoveItem(item);
                    break;

                case ItemContainerType.Equip:
                    ZoneScene.GetComponent<EquipmentsComponent>().UnloadEquipItem(item);
                    break;
            }
        }
    }
}