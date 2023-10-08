using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public enum RoleInfoStatus
    {
        Normal,
        Delete,
        Freeze,
    }

    [ComponentOf(typeof (Unit))]
    [ChildOf]
    public class RoleInfo: Entity, IAwake, ITransfer, IUnitCache
    {
        public long AccountId;
        public int ConfigId;
        public long CreateTime;
        public long LastLoginTime;
        public int Level;
        public string Name;
        public RoleClass RoleClass;
        public int ServerId;
        public RoleInfoStatus Status;

        [BsonIgnore]
        public bool Online;

        public UnitConfig UnitConfig => UnitConfigCategory.Instance.Get(this.ConfigId);
    }
}