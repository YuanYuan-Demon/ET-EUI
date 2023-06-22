namespace ET
{
    [FriendOf(typeof(EquipmentsComponent))]
    [FriendOf(typeof(EquipInfoComponent))]
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
            int equipPosition = item.GetComponent<EquipInfoComponent>().Config.EquipPosition;
            if (self.EquipItems.TryGetValue(equipPosition, out Item equipItem))
            {
                Log.Error($"当前位置[{(EquipPosition)equipPosition}]已有装备");
                return;
            }

            self.AddChild(item);
            self.EquipItems.Add(equipPosition, item);
        }

        public static bool IsEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            return self.EquipItems.ContainsKey((int)equipPosition);
        }

        public static bool UnloadEquipItem(this EquipmentsComponent self, Item item)
        {
            int equipPosition = item.GetComponent<EquipInfoComponent>().Config.EquipPosition;
            self.EquipItems.Remove(equipPosition);
            item?.Dispose();
            return true;
        }
    }
}