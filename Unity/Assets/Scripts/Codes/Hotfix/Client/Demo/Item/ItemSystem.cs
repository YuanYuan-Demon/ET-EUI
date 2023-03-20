namespace ET.Client
{
    [FriendOf(typeof(Item))]
    public static class ItemSystem
    {
        #region 生命周期

        public class ItemAwakeSystem : AwakeSystem<Item, int>
        {
            protected override void Awake(Item self, int configID)
            {
                self.ConfigId = configID;
            }
        }

        public class ItemDestorySystem : DestroySystem<Item>
        {
            protected override void Destroy(Item self)
            {
                self.Quality = 0;
                self.ConfigId = 0;
            }
        }

        #endregion 生命周期

        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.Id = itemInfo.ItemUid;
            self.ConfigId = itemInfo.ItemConfigId;
            self.Quality = itemInfo.ItemQuality;

            if (itemInfo.EquipInfo != null)
            {
                var equipInfoComponent = self.GetComponent<EquipInfoComponent>() ?? self.AddComponent<EquipInfoComponent>();
                equipInfoComponent.FromMessage(itemInfo.EquipInfo);
            }
        }
    }
}