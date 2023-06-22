namespace ET.Server
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
                self.ConfigId = 0;
                self.Count = 0;
            }
        }

        #endregion 生命周期

        public static ItemInfo ToMessage(this Item self, bool isAllInfo = true)
        {
            ItemInfo itemInfo = new ItemInfo
            {
                ItemUid = self.Id,
                ItemConfigId = self.ConfigId,
                Count = self.Count
            };

            if (!isAllInfo)
            {
                return itemInfo;
            }

            EquipInfoComponent equipInfoComponent = self.GetComponent<EquipInfoComponent>();
            if (equipInfoComponent != null)
            {
                itemInfo.EquipInfo = equipInfoComponent.ToMessage();
            }

            return itemInfo;
        }
    }
}