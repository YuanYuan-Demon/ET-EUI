namespace ET.Client
{
    [FriendOf(typeof (AttributeEntry))]
    [FriendOf(typeof (EquipInfoComponent))]
    public static class EquipInfoComponentSystem
    {
        public static void FromMessage(this EquipInfoComponent self, EquipInfoProto equipInfoProto)
        {
            self.Score = equipInfoProto.Score;
            self.Quality = equipInfoProto.Quality;

            for (int i = 0; i < self.EntryList.Count; i++)
            {
                self.EntryList[i]?.Dispose();
            }

            self.EntryList.Clear();

            for (int i = 0; i < equipInfoProto.AttributeEntryList.Count; i++)
            {
                AttributeEntry attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.FromMessage(equipInfoProto.AttributeEntryList[i]);
                self.EntryList.Add(attributeEntry);
            }

            self.IsInited = true;
        }

#region 生命周期

        public class EquipInfoComponentDestorySystem: DestroySystem<EquipInfoComponent>
        {
            protected override void Destroy(EquipInfoComponent self)
            {
                self.IsInited = false;
                self.Score = 0;
                for (int i = 0; i < self.EntryList.Count; i++)
                {
                    self.EntryList[i]?.Dispose();
                }

                self.EntryList.Clear();
            }
        }

#endregion 生命周期
    }
}