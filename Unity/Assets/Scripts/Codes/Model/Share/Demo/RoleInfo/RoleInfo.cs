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
        public string Name;
        public int ServerId;
        public int Status;
    }
}