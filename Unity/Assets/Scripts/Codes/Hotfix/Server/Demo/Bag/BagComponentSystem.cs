using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (Item))]
    [FriendOf(typeof (BagComponent))]
    [FriendOfAttribute(typeof (RoleInfo))]
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

#region 获取道具

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            self.AllItemsDict.TryGetValue(itemId, out var item);
            return item;
        }

#endregion 获取道具

#region 生命周期

        public class BagComponentDestroySystem: DestroySystem<BagComponent>
        {
            protected override void Destroy(BagComponent self) => self.Clear();
        }

        public class BagComponentDeserializeSystem: DeserializeSystem<BagComponent>
        {
            protected override void Deserialize(BagComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    self.AddContainer(entity as Item);
                }
            }
        }

#endregion 生命周期

#region 添加道具

        public static bool AddItemByConfigId(this BagComponent self, int configId, int count = 1, bool isSync = true)
        {
            if (count <= 0)
            {
                return false;
            }

            if (!self.CanAddItem(configId, count))
            {
                return false;
            }

            //如果已经存在该物品
            if (self.ItemsMap.TryGetValue(configId, out var item))
            {
                item.Count += count;
                if (isSync)
                {
                    ItemUpdateNoticeHelper.SyncUpdateItem(self.GetParent<Unit>(), item, ItemOp.Update, ItemContainerType.Bag);
                }
            }
            else //如果不存在该物品
            {
                self.AddNewItem(configId, count, isSync);
            }

            return true;
        }

        private static void AddNewItem(this BagComponent self, int configId, int count = 1, bool isSync = true)
        {
            var itemConfig = ItemConfigCategory.Instance.Get(configId);
            if (itemConfig.StackLimit > 1)
            {
                var newItem = ItemFactory.CreateItem(self, configId);
                if (!self.AddItem(newItem, count, isSync))
                {
                    Log.Error("添加物品失败！");
                    newItem?.Dispose();
                }
            }
            else
            {
                for (var i = 0; i < count; i++)
                {
                    var newItem = ItemFactory.CreateItem(self, configId);
                    if (!self.AddItem(newItem, 1, isSync))
                    {
                        Log.Error("添加物品失败！");
                        newItem?.Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     将道具添加到背包中
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
            {
                ItemUpdateNoticeHelper.SyncUpdateItem(self.GetParent<Unit>(), item, ItemOp.Add, ItemContainerType.Bag);
            }

            return true;
        }

        private static bool AddContainer(this BagComponent self, Item item)
        {
            if (self.ContainItem(item.Id))
            {
                return false;
            }

            self.AllItemsDict.Add(item.Id, item);
            self.ItemTypeMap.Add(item.Config.Type, item);
            if (item.CanStack)
            {
                self.ItemsMap.Add(item.ConfigId, item);
            }

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

                    item.Count -= count;
                }
                else
                {
                    self.RemoveContainer(item);
                }

                ItemUpdateNoticeHelper.SyncUpdateItem(self.GetParent<Unit>(), item, ItemOp.Remove, ItemContainerType.Bag);
                return true;
            }

            Log.Error("item is not in bag!");
            return false;
        }

        private static void RemoveContainer(this BagComponent self, Item item)
        {
            self.AllItemsDict.Remove(item.Id);
            self.ItemTypeMap.Remove(item.Config.Type, item);
        }

#endregion 删除道具

#region 查询

        /// <summary>
        ///     是否达到最大负载
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsMaxLoad(this BagComponent self, int count = 1) => self.AllItemsDict.Count + count >
                self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity];

        public static bool CanAddItem(this BagComponent self, int configId, int count = 1)
        {
            var config = ItemConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                return false;
            }

            //如果是可堆叠的
            if (config.StackLimit > 1)
            {
                if (!self.ItemsMap.ContainsKey(configId) && self.IsMaxLoad())
                {
                    return false;
                }
            }
            //如果是不可堆叠的
            else
            {
                if (self.IsMaxLoad(count))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CanAddItem(this BagComponent self, Item item)
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

            if (self.AllItemsDict.ContainsKey(item.Id))
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

            if (self.AllItemsDict.Count + goodsList.Count > self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity])
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
            self.AllItemsDict.TryGetValue(itemId, out var item);
            return item != null && !item.IsDisposed;
        }

        public static bool ContainItem(this BagComponent self, Item item) => self.ContainItem(item.Id);

#endregion 查询
    }
}