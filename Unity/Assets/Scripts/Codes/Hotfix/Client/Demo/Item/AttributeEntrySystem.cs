namespace ET.Client
{
    [FriendOf(typeof(AttributeEntry))]
    public static class AttributeEntrySystem
    {
        #region 生命周期

        public class AttributeEntryDestorySystem : DestroySystem<AttributeEntry>
        {
            protected override void Destroy(AttributeEntry self)
            {
                self.AttributeType = 0;
                self.AttributeValue = 0;
                self.EntryType = EntryType.Common;
            }
        }

        #endregion 生命周期

        public static void FromMessage(this AttributeEntry self, AttributeEntryProto attributeEntryProto)
        {
            self.Id = attributeEntryProto.Id;
            self.AttributeType = attributeEntryProto.AttributeName;
            self.AttributeValue = attributeEntryProto.AttributeValue;
            self.EntryType = (EntryType)attributeEntryProto.EntryType;
        }
    }
}