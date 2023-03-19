namespace ET
{
    [FriendOf(typeof(EquipmentsComponent))]
    public static class EquipmentsComponentSystem
    {
        #region 生命周期

        public class EquipmentsComponentDestrory : DestroySystem<EquipmentsComponent>
        {
            protected override void Destroy(EquipmentsComponent self)
            {
                self.Clear();
            }
        }

        #endregion 生命周期

        public static void Clear(this EquipmentsComponent self)
        {
            foreach (var (_, item) in self.EquipItems)
            {
                item?.Dispose();
            }
            self.EquipItems.Clear();
        }

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
            if (self.EquipItems.TryGetValue((int)equipPosition, out Item item))
            {
                return item;
            }

            return null;
        }

        public static void AddEquipItem(this EquipmentsComponent self, Item item)
        {
            if (self.EquipItems.TryGetValue(item.Config.EquipPosition, out Item equipItem))
            {
                Log.Error($"当前位置[{(EquipPosition)item.Config.EquipPosition}]已有装备");
                return;
            }

            self.AddChild(item);
            self.EquipItems.Add(item.Config.EquipPosition, item);
        }

        public static bool IsEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            return self.EquipItems.ContainsKey((int)equipPosition);
        }

        public static bool UnloadEquipItem(this EquipmentsComponent self, Item item)
        {
            self.EquipItems.Remove(item.Config.EquipPosition);
            item?.Dispose();
            return true;
        }
    }
}