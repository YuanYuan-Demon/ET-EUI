using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class FriendInfo: Entity, IAwake, IDestroy, ISerializeToEntity
    {
        [BsonIgnore]
        public bool IsApply;

        // [BsonIgnore]
        public long LastLoginTime;

        // [BsonIgnore]
        public int Level;
        public string Name;

        [BsonIgnore]
        public bool Online;

        // [BsonIgnore]
        public RoleClass RoleClass;
    }
}