namespace ET.Client
{
    [FriendOf(typeof (Item))]
    public static class ItemSystem
    {
        public static void FromMessage(this Item self, NItem nItem)
        {
            self.Id = nItem.ItemUid;
            self.ConfigId = nItem.ItemConfigId;
            self.Count = nItem.Count;

            if (nItem.EquipInfo != null)
            {
                var equipInfoComponent = self.GetComponent<EquipInfoComponent>() ?? self.AddComponent<EquipInfoComponent>();
                equipInfoComponent.FromMessage(nItem.EquipInfo);
            }
        }

#region 生命周期

        public class ItemAwakeSystem: AwakeSystem<Item, int>
        {
            protected override void Awake(Item self, int name) => self.ConfigId = name;
        }

        public class ItemDestorySystem: DestroySystem<Item>
        {
            protected override void Destroy(Item self)
            {
                self.ConfigId = 0;
                self.Count = 0;
            }
        }

#endregion 生命周期
    }
}