namespace ET.Server
{
    [FriendOf(typeof(Item))]
    public static class ItemFactory
    {
        public static Item CreateItem(BagComponent parent, int configId)
        {
            if (!ItemConfigCategory.Instance.Contain(configId))
            {
                Log.Error($"当前所创建的物品id 不存在: {configId}");
                return null;
            }

            Item item = parent.AddChild<Item, int>(configId);
            AddComponentByItemType(item);
            return item;
        }

        public static void AddComponentByItemType(Item item)
        {
            switch ((ItemType)item.Config.Type)
            {
                case ItemType.Equip:
                    item.AddComponent<EquipInfoComponent>();
                    break;
            }
        }
    }
}