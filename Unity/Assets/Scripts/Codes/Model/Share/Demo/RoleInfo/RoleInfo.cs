namespace ET
{
    public enum RoleInfoStatus
    {
        Normal,
        Freeze
    }

    [ComponentOf(typeof (Unit))]
    [ChildOf]
    public class RoleInfo: Entity, IAwake, ITransfer, IUnitCache
    {
        public long AccountId;
        public long CreateTime;
        public long LastLoginTIme;
        public int Level;
        public string Name;
        public RoleClass RoleClass;
        public int ServerId;
        public RoleInfoStatus Status;
    }
}