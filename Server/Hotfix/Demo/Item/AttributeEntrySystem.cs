namespace ET
{
    [FriendClass(typeof(AttributeEntry))]
    public static class AttributeEntrySystem
    {
        public class AttributeEntryDestorySystem : DestroySystem<AttributeEntry>
        {
            public override void Destroy(AttributeEntry self)
            {
                self.AttributeName = 0;
                self.AttributeValue = 0;
                self.EntryType = EntryType.Common;
            }
        }

        public static AttributeEntryProto ToMessage(this AttributeEntry self)
        {
           return new AttributeEntryProto
            {
                Id = self.Id,
                AttributeName = self.AttributeName,
                AttributeValue = self.AttributeValue,
                EntryType = (int)self.EntryType
            };
        }
    }
}