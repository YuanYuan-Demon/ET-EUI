namespace ET
{
    public enum RoleInfoStatus
    {
        Normal,
        Freeze,
    }

    [ComponentOf(typeof (Unit))]
    [ChildOf]
    public class RoleInfo: Entity, IAwake, ITransfer, IUnitCache
    {
        public long AccountId;
        public int ConfigId;
        public long CreateTime;
        public long LastLoginTIme;
        public int Level;
        public string Name;
        public RoleClass RoleClass;
        public int ServerId;
        public RoleInfoStatus Status;
        public UnitConfig UnitConfig => UnitConfigCategory.Instance.Get(this.ConfigId);
    }
}