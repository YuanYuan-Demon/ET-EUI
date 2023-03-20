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

                case ItemContainerType.RoleInfo:
                    ZoneScene?.GetComponent<EquipmentsComponent>()?.Clear();
                    break;
            }
        }

        public static Item GetItem(Scene ZoneScene, long itemId, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    return ZoneScene.GetComponent<BagComponent>().GetItemById(itemId);

                case ItemContainerType.RoleInfo:
                    return ZoneScene.GetComponent<EquipmentsComponent>().GetItemById(itemId);
            }

            return null;
        }

        public static void AddItem(Scene ZoneScene, Item item, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene.GetComponent<BagComponent>().AddItem(item);
                    break;

                case ItemContainerType.RoleInfo:
                    ZoneScene.GetComponent<EquipmentsComponent>().AddEquipItem(item);
                    break;
            }
        }

        public static void RemoveItemById(Scene ZoneScene, long itemId, ItemContainerType itemContainerType)
        {
            Item item = GetItem(ZoneScene, itemId, itemContainerType);
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    ZoneScene.GetComponent<BagComponent>().RemoveItem(item);
                    break;

                case ItemContainerType.RoleInfo:
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

                case ItemContainerType.RoleInfo:
                    ZoneScene.GetComponent<EquipmentsComponent>().UnloadEquipItem(item);
                    break;
            }
        }
    }
}