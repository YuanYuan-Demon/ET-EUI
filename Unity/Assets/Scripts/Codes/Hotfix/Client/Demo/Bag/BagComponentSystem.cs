namespace ET.Client
{
    [FriendOf(typeof(BagComponent))]
    public static class BagComponentSystem
    {
        #region 生命周期

        public class BagComponentDestorySystem : DestroySystem<BagComponent>
        {
            protected override void Destroy(BagComponent self)
            {
                self.Clear();
            }
        }

        #endregion 生命周期

        /// <summary>
        /// 是否达到最大负载
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsMaxLoad(this BagComponent self)
        {
            NumericComponent numericComponent = self.GetMyNumericComponent();
            return self.ItemsDict.Count == numericComponent[NumericType.MaxBagCapacity];
        }

        public static void Clear(this BagComponent self)
        {
            foreach ((long id, Item item) in self.ItemsDict)
            {
                item?.Dispose();
            }

            self.ItemsDict.Clear();
            self.ItemsMap.Clear();
        }

        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.ItemsMap.ContainsKey((int)itemType))
            {
                return 0;
            }
            return self.ItemsMap[(int)itemType].Count;
        }

        public static void AddItem(this BagComponent self, Item item)
        {
            self.AddChild(item);
            self.ItemsDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.Type, item);
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return;
            }

            self.ItemsDict.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
            item?.Dispose();
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            if (self.ItemsDict.TryGetValue(itemId, out Item item))
            {
                return item;
            }
            return null;
        }
    }
}