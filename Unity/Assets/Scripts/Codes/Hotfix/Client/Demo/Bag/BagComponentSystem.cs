namespace ET.Client
{
    [FriendOf(typeof(BagComponent))]
    [FriendOfAttribute(typeof(ET.Item))]
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
            foreach ((_, Item item) in self.ItemsDict)
            {
                item?.Dispose();
            }

            self.ItemsDict.Clear();
            self.ItemsMap.Clear();
            self.ItemTypeMap.Clear();
        }

        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.ItemTypeMap.ContainsKey((int)itemType))
            {
                return 0;
            }
            return self.ItemTypeMap[(int)itemType].Count;
        }

        public static void AddItem(this BagComponent self, Item item)
        {
            //如果是可堆叠的物品
            if (item.CanStack)
            {
                //如果已经存在该物品
                if (self.ItemsMap.TryGetValue(item.ConfigId, out var item1))
                {
                    item1.Count += item.Count;
                    return;
                }
                else //第一次添加
                {
                    self.AddChild(item);
                    self.ItemsDict.Add(item.Id, item);
                    self.ItemTypeMap.Add(item.Config.Type, item);
                    self.ItemsMap.Add(item.ConfigId, item);
                }
            }
            //不可堆叠的物品
            else
            {
                self.AddChild(item);
                self.ItemsDict.Add(item.Id, item);
                self.ItemTypeMap.Add(item.Config.Type, item);
            }
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return;
            }
            //如果是可堆叠的物品
            if (item.CanStack)
            {
                if (self.ItemsMap.TryGetValue(item.ConfigId, out var item1))
                {
                    item1.Count -= item.Count;
                    if (item1.Count <= 0)
                    {
                        self.ItemsDict.Remove(item.Id);
                        self.ItemTypeMap.Remove(item.Config.Type, item);
                        self.ItemsMap.Remove(item.ConfigId);
                        item?.Dispose();
                    }
                }
                else
                {
                    Log.Error($"bag item is not exist, id: {item.Id}");
                }
            }
            else
            {
                self.ItemsDict.Remove(item.Id);
                self.ItemTypeMap.Remove(item.Config.Type, item);
                item?.Dispose();
            }
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