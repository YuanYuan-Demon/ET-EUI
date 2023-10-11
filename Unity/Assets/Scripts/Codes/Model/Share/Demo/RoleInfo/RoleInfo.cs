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

        [BsonIgnore]
        public bool Online;

        public RoleClass RoleClass;
        public int ServerId;

        public RoleInfoStatus Status;

        public UnitConfig UnitConfig => UnitConfigCategory.Instance.Get(this.ConfigId);
    }
}