using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(Item))]
    [FriendClass(typeof(BagComponent))]
    public static class BagComponentSystem
    {
        public class BagComponentDestroySystem : DestroySystem<BagComponent>
        {
            public override void Destroy(BagComponent self)
            {
                foreach (var item in self.ItemsDict.Values)
                {
                    item?.Dispose();
                }
                self.ItemsDict.Clear();
                self.ItemsMap.Clear();
            }
        }

        public class BagComponentDeserializeSystem : DeserializeSystem<BagComponent>
        {
            public override void Deserialize(BagComponent self)
            {
                foreach (Entity entity in self.Children.Values)
                {
                    self.AddContainer(entity as Item);
                }
            }
        }

        #region 添加道具

        public static bool AddItemByConfigId(this BagComponent self, int configId, int count = 1)
        {
            if (!ItemConfigCategory.Instance.Contain(configId))
            {
                return false;
            }

            if (count <= 0)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                Item newItem = ItemFactory.Create(self, configId);

                if (!self.AddItem(newItem))
                {
                    Log.Error("添加物品失败！");
                    newItem?.Dispose();
                    return false;
                }
            }

            return true;
        }

        public static bool AddItemList(this BagComponent self, List<Item> itemsList)
        {
            if (itemsList.Count <= 0)
            {
                return true;
            }

            foreach (Item newItem in itemsList)
            {
                if (!self.AddItem(newItem))
                {
                    newItem?.Dispose();
                    return false;
                }
            }
            return true;
        }

        public static bool AddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                Log.Error("item is null!");
                return false;
            }

            if (self.IsMaxLoad())
            {
                Log.Error("bag is IsMaxLoad!");
                return false;
            }

            if (!self.AddContainer(item))
            {
                Log.Error("Add Container is Error!");
                return false;
            }

            if (item.Parent != self)
            {
                self.AddChild(item);
            }

            ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, self.message);
            return true;
        }

        public static bool AddContainer(this BagComponent self, Item item)
        {
            if (self.ItemsDict.ContainsKey(item.Id))
            {
                return false;
            }

            self.ItemsDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.Type, item);
            return true;
        }

        #endregion 添加道具

        #region 删除道具

        public static void RemoveContainer(this BagComponent self, Item item)
        {
            self.ItemsDict.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
        }

        public static void GetItemListByConfigId(this BagComponent self, int configID, List<Item> list)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(configID);
            foreach (Item goods in self.ItemsMap[itemConfig.Type])
            {
                if (goods.ConfigId == configID)
                {
                    list.Add(goods);
                }
            }
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            item.Dispose();
        }

        public static Item RemoveItemNoDispose(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            return item;
        }

        #endregion 删除道具

        #region 获取道具

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            self.ItemsDict.TryGetValue(itemId, out Item item);
            return item;
        }

        #endregion 获取道具

        #region 判断

        public static bool IsCanAddItemByConfigId(this BagComponent self, int configID)
        {
            if (!ItemConfigCategory.Instance.Contain(configID))
            {
                return false;
            }

            if (self.IsMaxLoad())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 是否达到最大负载
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsMaxLoad(this BagComponent self)
        {
            return self.ItemsDict.Count == self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity];
        }

        public static bool IsCanAddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                return false;
            }

            if (!ItemConfigCategory.Instance.Contain(item.ConfigId))
            {
                return false;
            }

            if (self.IsMaxLoad())
            {
                return false;
            }

            if (self.ItemsDict.ContainsKey(item.Id))
            {
                return false;
            }

            if (item.Parent == self)
            {
                return false;
            }
            return true;
        }

        public static bool IsCanAddItemList(this BagComponent self, List<Item> goodsList)
        {
            if (goodsList.Count <= 0)
            {
                return false;
            }

            if (self.ItemsDict.Count + goodsList.Count > self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity])
            {
                return false;
            }

            foreach (var item in goodsList)
            {
                if (item == null || item.IsDisposed)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsItemExist(this BagComponent self, long itemId)
        {
            self.ItemsDict.TryGetValue(itemId, out Item item);
            return item != null && !item.IsDisposed;
        }

        #endregion 判断
    }
}