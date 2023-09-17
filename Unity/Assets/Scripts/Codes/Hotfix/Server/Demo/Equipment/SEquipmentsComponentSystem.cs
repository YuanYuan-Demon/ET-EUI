namespace ET.Server
{
    [FriendOf(typeof(EquipmentsComponent))]
    public static class SEquipmentsComponentSystem
    {
        #region 生命周期

        //public class EquipmentsComponentDestroy : DestroySystem<EquipmentsComponent>
        //{
        //    protected override void Destroy(EquipmentsComponent self)
        //    {
        //        foreach (var item in self.EquipedItems.Values)
        //        {
        //            item?.Dispose();
        //        }
        //        self.EquipedItems.Clear();
        //    }
        //}

        public class EquipmentsComponentDeserializeSystem : DeserializeSystem<EquipmentsComponent>
        {
            protected override void Deserialize(EquipmentsComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    Item item = entity as Item;
                    self.EquipedItems.Add((EquipPosition)item.EquipConfig.EquipPosition, item);
                }
            }
        }

        #endregion 生命周期

        #region 装备/卸下

        /// <summary>
        /// 装配Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool EquipItem(this EquipmentsComponent self, Item item)
        {
            if (!self.EquipedItems.ContainsKey((EquipPosition)item.EquipConfig.EquipPosition))
            {
                self.AddChild(item);
                self.EquipedItems.Add((EquipPosition)item.EquipConfig.EquipPosition, item);
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
            if (self.EquipedItems.TryGetValue(equipPosition, out Item item))
            {
                self.EquipedItems.Remove(equipPosition);
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

        #endregion 装备/卸下
    }
}