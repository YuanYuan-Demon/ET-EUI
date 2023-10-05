using ET.Server.EventType;

namespace ET.Server
{
    [FriendOf(typeof (EquipmentsComponent))]
    [FriendOfAttribute(typeof (RoleInfo))]
    public static class EquipmentsComponentSystem
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

        public class EquipmentsComponentDeserializeSystem: DeserializeSystem<EquipmentsComponent>
        {
            protected override void Deserialize(EquipmentsComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    var item = entity as Item;
                    self.EquipedItems.Add(item.EquipConfig.EquipPosition, item);
                }
            }
        }

#endregion 生命周期

#region 装备/卸下

        /// <summary>
        ///     装配Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool EquipItem(this EquipmentsComponent self, Item item)
        {
            if (self.EquipedItems.ContainsKey(item.EquipConfig.EquipPosition))
            {
                return false;
            }

            if (item.EquipConfig.Role != self.GetParent<Unit>().GetComponent<RoleInfo>().RoleClass)
            {
                return false;
            }

            self.AddChild(item);
            self.EquipedItems.Add(item.EquipConfig.EquipPosition, item);
            EventSystem.Instance.Publish(self.DomainScene(),
                new ChangeEquipItem() { Unit = self.GetParent<Unit>(), Item = item, EquipOp = EquipOp.Load });
            ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, ItemContainerType.Equip);
            return true;
        }

        /// <summary>
        ///     卸下对应位置的Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="equipPosition"></param>
        /// <returns></returns>
        public static Item UnEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            if (self.EquipedItems.TryGetValue(equipPosition, out var item))
            {
                self.EquipedItems.Remove(equipPosition);
                EventSystem.Instance.Publish(self.DomainScene(),
                    new ChangeEquipItem() { Unit = self.GetParent<Unit>(), Item = item, EquipOp = EquipOp.Unload });
                ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, ItemContainerType.Equip);
            }

            return item;
        }

#endregion 装备/卸下
    }
}