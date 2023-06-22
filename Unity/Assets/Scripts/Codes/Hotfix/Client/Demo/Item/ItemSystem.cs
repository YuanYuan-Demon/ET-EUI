namespace ET.Client
{
    [FriendOf(typeof(Item))]
    public static class ItemSystem
    {
        #region 生命周期

        public class ItemAwakeSystem : AwakeSystem<Item, int>
        {
            protected override void Awake(Item self, int configId)
            {
                self.ConfigId = configId;
            }
        }

        public class ItemDestorySystem : DestroySystem<Item>
        {
            protected override void Destroy(Item self)
            {
                self.ConfigId = 0;
                self.Count = 0;
            }
        }

        #endregion 生命周期

        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.Id = itemInfo.ItemUid;
            self.ConfigId = itemInfo.ItemConfigId;
            self.Count = itemInfo.Count;

            if (itemInfo.EquipInfo != null)
            {
                var equipInfoComponent = self.GetComponent<EquipInfoComponent>() ?? self.AddComponent<EquipInfoComponent>();
                equipInfoComponent.FromMessage(itemInfo.EquipInfo);
            }
        }
    }
}