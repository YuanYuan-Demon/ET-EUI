namespace ET.Server
{
    [FriendOf(typeof (AttributeEntry))]
    public static class AttributeEntrySystem
    {
        public static AttributeEntryProto ToMessage(this AttributeEntry self)
        {
            return new AttributeEntryProto
            {
                Id = self.Id, AttributeName = self.AttributeType, AttributeValue = self.AttributeValue, EntryType = self.EntryType
            };
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