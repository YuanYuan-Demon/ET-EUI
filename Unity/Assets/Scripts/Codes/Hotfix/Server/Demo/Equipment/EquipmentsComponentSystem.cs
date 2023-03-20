namespace ET.Server
{
    [FriendOf(typeof(EquipmentsComponent))]
    public static class EquipmentsComponentSystem
    {
        #region 生命周期

        public class EquipmentsComponentDestroy : DestroySystem<EquipmentsComponent>
        {
            protected override void Destroy(EquipmentsComponent self)
            {
                foreach (var item in self.EquipItems.Values)
                {
                    item?.Dispose();
                }
                self.EquipItems.Clear();
            }
        }

        public class EquipmentsComponentDeserializeSystem : DeserializeSystem<EquipmentsComponent>
        {
            protected override void Deserialize(EquipmentsComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    Item item = entity as Item;
                    self.EquipItems.Add(item.Config.EquipPosition, item);
                }
            }
        }

        #endregion 生命周期

        /// <summary>
        /// 对应位置处是否有装配Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="equipPosition"></param>
        /// <returns></returns>
        public static bool IsEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            self.EquipItems.TryGetValue((int)equipPosition, out Item item);

            return item != null && !item.IsDisposed;
        }

        /// <summary>
        /// 装配Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool EquipItem(this EquipmentsComponent self, Item item)
        {
            if (!self.EquipItems.ContainsKey(item.Config.EquipPosition))
            {
                self.AddChild(item);
                self.EquipItems.Add(item.Config.EquipPosition, item);
                EventSystem.Instance.Publish(self.DomainScene(), new EventType.ChangeEquipItem()
                {
                    Unit = self.GetParent<Unit>(),
                    Item = item,
                    EquipOp = EquipOp.Load
                });
                ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, ItemContainerType.RoleInfo);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 卸下对应位置的Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="equipPosition"></param>
        /// <returns></returns>
        public static Item UnloadEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            if (self.EquipItems.TryGetValue((int)equipPosition, out Item item))
            {
                self.EquipItems.Remove((int)equipPosition);
                EventSystem.Instance.Publish(self.DomainScene(), new EventType.ChangeEquipItem()
                {
                    Unit = self.GetParent<Unit>(),
                    Item = item,
                    EquipOp = EquipOp.Unload
                });
                ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, ItemContainerType.RoleInfo);
            }
            return item;
        }

        public static Item GetEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            if (!self.EquipItems.TryGetValue((int)equipPosition, out Item item))
            {
                return null;
            }
            return item;
        }
    }
}