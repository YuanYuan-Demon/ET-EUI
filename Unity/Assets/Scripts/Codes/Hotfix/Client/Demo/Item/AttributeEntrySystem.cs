namespace ET.Client
{
    [FriendOf(typeof (AttributeEntry))]
    public static class AttributeEntrySystem
    {
        public static void FromMessage(this AttributeEntry self, NAttributeEntry nAttributeEntry)
        {
            self.Id = nAttributeEntry.Id;
            self.AttributeType = nAttributeEntry.AttributeName;
            self.AttributeValue = nAttributeEntry.AttributeValue;
            self.EntryType = nAttributeEntry.EntryType;
        }

#region 生命周期

        public class AttributeEntryDestorySystem: DestroySystem<AttributeEntry>
        {
            protected override void Destroy(AttributeEntry self)
            {
                self.AttributeType = 0;
                self.AttributeValue = 0;
                self.EntryType = EntryType.Common;
            }
        }

#endregion 生命周期
    }
}