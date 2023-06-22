using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(Item))]
    [FriendOf(typeof(BagComponent))]
    public static class BagComponentSystem
    {
        #region 生命周期

        public class BagComponentDestroySystem : DestroySystem<BagComponent>
        {
            protected override void Destroy(BagComponent self)
            {
                foreach (var item in self.ItemsDict.Values)
                {
                    item?.Dispose();
                }
                self.ItemsDict.Clear();
                self.ItemTypeMap.Clear();
                self.ItemsMap.Clear();
            }
        }

        public class BagComponentDeserializeSystem : DeserializeSystem<BagComponent>
        {
            protected override void Deserialize(BagComponent self)
            {
                foreach (Entity entity in self.Children.Values)
                {
                    self.AddContainer(entity as Item);
                }
            }
        }

        #endregion 生命周期

        #region 添加道具

        public static bool AddItemByConfigId(this BagComponent self, int configId, int count = 1, bool isSync = true)
        {
            if (!self.IsCanAddItemByConfigId(configId))
                return false;
            if (count <= 0)
                return false;

            //如果已经存在该物品
            if (self.ItemsMap.TryGetValue(configId, out var item))
                item.Count += count;
            else //如果不存在该物品
                self.AddNewItem(configId, count, isSync);
            return true;
        }

        public static void AddNewItem(this BagComponent self, int configId, int count = 1, bool isSync = true)
        {
            var itemConfig = ItemConfigCategory.Instance.Get(configId);
            if (itemConfig.StackLimit > 1)
            {
                Item newItem = ItemFactory.CreateOne(self, configId);
                if (!self.AddItem(newItem, count, isSync))
                {
                    Log.Error("添加物品失败！");
                    newItem?.Dispose();
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Item newItem = ItemFactory.CreateOne(self, configId);
                    if (!self.AddItem(newItem, 1, isSync))
                    {
                        Log.Error("添加物品失败！");
                        newItem?.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 将道具添加到背包中
        /// </summary>
        /// <param name="self"></param>
        /// <param name="item"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool AddItem(this BagComponent self, Item item, int count = 1, bool isSync = true)
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
            item.Count += count;
            if (isSync)
                ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, ItemContainerType.Bag, count);
            return true;
        }

        public static bool AddContainer(this BagComponent self, Item item)
        {
            if (self.ContainItem(item.Id))
                return false;

            self.ItemsDict.Add(item.Id, item);
            self.ItemTypeMap.Add(item.Config.Type, item);
            if (item.CanStack)
                self.ItemsMap.Add(item.ConfigId, item);
            return true;
        }

        #endregion 添加道具

        #region 删除道具

        public static bool RemoveItem(this BagComponent self, Item item, int count = 1)
        {
            if (self.ContainItem(item.Id))
            {
                if (item.CanStack)
                {
                    if (item.Count < count)
                    {
                        Log.Error("item count is not enough!");
                        return false;
                    }
                    else
                    {
                        item.Count -= count;
                    }
                }
                else
                {
                    self.RemoveContainer(item);
                }

                ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, ItemContainerType.Bag, count);
                return true;
            }
            else
            {
                Log.Error("item is not in bag!");
                return false;
            }
        }

        public static void RemoveContainer(this BagComponent self, Item item)
        {
            self.ItemsDict.Remove(item.Id);
            self.ItemTypeMap.Remove(item.Config.Type, item);
        }

        #endregion 删除道具

        #region 获取道具

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            self.ItemsDict.TryGetValue(itemId, out Item item);
            return item;
        }

        #endregion 获取道具

        #region 查询

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
            return self.ItemsDict.Count >= self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity];
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

        public static bool ContainItem(this BagComponent self, long itemId)
        {
            self.ItemsDict.TryGetValue(itemId, out Item item);
            return item != null && !item.IsDisposed;
        }

        public static bool ContainItem(this BagComponent self, Item item) => self.ContainItem(item.Id);

        #endregion 查询
    }
}