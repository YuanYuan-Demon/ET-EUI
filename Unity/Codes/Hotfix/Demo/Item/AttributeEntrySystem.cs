namespace ET
{
    [FriendClass(typeof(AttributeEntry))]
    public static class AttributeEntrySystem
    {
        public class AttributeEntryDestorySystem : DestroySystem<AttributeEntry>
        {
            public override void Destroy(AttributeEntry self)
            {
                self.AttributeType = 0;
                self.AttributeValue = 0;
                self.EntryType = EntryType.Common;
            }
        }

        public static void FromMessage(this AttributeEntry self, AttributeEntryProto attributeEntryProto)
        {
            self.Id = attributeEntryProto.Id;
            self.AttributeType = attributeEntryProto.AttributeName;
            self.AttributeValue = attributeEntryProto.AttributeValue;
            self.EntryType = (EntryType)attributeEntryProto.EntryType;
        }
    }
}