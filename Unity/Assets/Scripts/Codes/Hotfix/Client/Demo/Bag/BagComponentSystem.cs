namespace ET.Client
{
    [FriendOf(typeof (BagComponent))]
    [FriendOfAttribute(typeof (ET.Item))]
    public static class BagComponentSystem
    {
        public static void Clear(this BagComponent self)
        {
            foreach (var item in self.AllItemsDict.Values)
            {
                item?.Dispose();
            }

            self.AllItemsDict.Clear();
            self.ItemTypeMap.Clear();
            self.ItemsMap.Clear();
        }

        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.ItemTypeMap.ContainsKey(itemType))
            {
                return 0;
            }

            return self.ItemTypeMap[itemType].Count;
        }

        public static void AddItem(this BagComponent self, Item item)
        {
            self.AddChild(item);
            self.AllItemsDict.Add(item.Id, item);
            self.ItemTypeMap.Add((ItemType)item.Config.Type, item);
            if (item.CanStack)
                self.ItemsMap.Add(item.ConfigId, item);
        }

        public static void AddItem(this BagComponent self, ItemInfo itemInfo)
        {
            Item item = self.Create(itemInfo);
            self.AllItemsDict.Add(item.Id, item);
            self.ItemTypeMap.Add((ItemType)item.Config.Type, item);
            if (item.CanStack)
                self.ItemsMap.Add(item.ConfigId, item);
        }

        public static void UpdateItem(this BagComponent self, ItemInfo itemInfo)
        {
            if (self.ContainItem(itemInfo.ItemUid))
            {
                self.GetItemById(itemInfo.ItemUid).Count = itemInfo.Count;
            }
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return;
            }

            self.AllItemsDict.Remove(item.Id);
            self.ItemTypeMap.Remove((ItemType)item.Config.Type, item);
            if (item.CanStack)
                self.ItemsMap.Remove(item.ConfigId);
            item?.Dispose();
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            if (self.AllItemsDict.TryGetValue(itemId, out Item item))
            {
                return item;
            }

            return null;
        }

        public static bool ContainItem(this BagComponent self, long itemId)
        {
            self.AllItemsDict.TryGetValue(itemId, out Item item);
            return item != null && !item.IsDisposed;
        }

#region 生命周期

        public class BagComponentDestroySystem: DestroySystem<BagComponent>
        {
            protected override void Destroy(BagComponent self)
            {
                self.Clear();
            }
        }

#endregion 生命周期
    }
}