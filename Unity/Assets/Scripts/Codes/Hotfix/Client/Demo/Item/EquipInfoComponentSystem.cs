namespace ET.Client
{
    [FriendOf(typeof (AttributeEntry))]
    [FriendOf(typeof (EquipInfoComponent))]
    public static class EquipInfoComponentSystem
    {
        public static void FromMessage(this EquipInfoComponent self, NEquipInfo nEquipInfo)
        {
            self.Score = nEquipInfo.Score;
            self.Quality = nEquipInfo.Quality;

            for (var i = 0; i < self.EntryList.Count; i++)
                self.EntryList[i]?.Dispose();

            self.EntryList.Clear();

            for (var i = 0; i < nEquipInfo.AttributeEntrys.Count; i++)
            {
                var attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.FromMessage(nEquipInfo.AttributeEntrys[i]);
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
                for (var i = 0; i < self.EntryList.Count; i++)
                    self.EntryList[i]?.Dispose();

                self.EntryList.Clear();
            }
        }

#endregion 生命周期
    }
}