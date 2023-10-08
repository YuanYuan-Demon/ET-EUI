using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class FriendInfo: Entity, IAwake, IDestroy, ISerializeToEntity
    {
        public string Name;

        [BsonIgnore]
        public RoleClass RoleClass;

        [BsonIgnore]
        public int Level;

        [BsonIgnore]
        public long LastLoginTime;

        [BsonIgnore]
        public bool Online;
    }
}