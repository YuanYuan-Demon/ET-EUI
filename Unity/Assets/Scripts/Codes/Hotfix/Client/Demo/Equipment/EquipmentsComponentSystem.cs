namespace ET
{
    [FriendOf(typeof (EquipmentsComponent))]
    [FriendOf(typeof (EquipInfoComponent))]
    public static class EquipmentsComponentSystem
    {
        public static void Clear(this EquipmentsComponent self)
        {
            foreach (var item in self.EquipedItems.Values)
            {
                item?.Dispose();
            }

            self.EquipedItems.Clear();
        }

#region 生命周期

        public class EquipmentsComponentDestrory: DestroySystem<EquipmentsComponent>
        {
            protected override void Destroy(EquipmentsComponent self)
            {
                self.Clear();
            }
        }

#endregion 生命周期

#region 获取/查询

        public static Item GetItemById(this EquipmentsComponent self, long itemId)
        {
            if (self.Children.TryGetValue(itemId, out Entity entity))
            {
                return entity as Item;
            }

            return null;
        }

        public static Item GetItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            return self.EquipedItems.TryGetValue(equipPosition, out Item item)? item : null;
        }

        /// <summary>
        /// 对应位置处是否有装配Item
        /// </summary>
        /// <param name="self"></param>
        /// <param name="equipPosition"></param>
        /// <returns></returns>
        public static bool IsEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            self.EquipedItems.TryGetValue(equipPosition, out Item item);
            return item != null && !item.IsDisposed;
        }

#endregion 获取/查询

#region 装备/卸下(客户端专用)

        public static void AddEquipItem(this EquipmentsComponent self, Item item)
        {
            EquipPosition equipPosition = (EquipPosition)item.GetComponent<EquipInfoComponent>().Config.EquipPosition;
            if (self.EquipedItems.TryGetValue(equipPosition, out Item equipItem))
            {
                Log.Error($"当前位置[{equipPosition}]已装备[{equipItem.Config.Name}][{equipItem.Config.Id}]");
                return;
            }

            self.AddChild(item);
            self.EquipedItems.Add(equipPosition, item);
        }

        public static bool UnloadEquipItem(this EquipmentsComponent self, Item item)
        {
            EquipPosition equipPosition = (EquipPosition)item.GetComponent<EquipInfoComponent>().Config.EquipPosition;
            self.EquipedItems.Remove(equipPosition);
            item?.Dispose();
            return true;
        }

#endregion 装备/卸下(客户端专用)
    }
}