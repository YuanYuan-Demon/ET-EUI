namespace ET
{
    public enum RoleInfoStatus
    {
        Normal,
        Freeze
    }

    [ComponentOf(typeof(Unit))]
    [ChildOf]
    public class RoleInfo : Entity, IAwake, ITransfer, IUnitCache
    {
        public string Name;
        public int ServerId;
        public int Status;
        public long AccountId;
        public long LastLoginTIme;
        public long CreateTime;
    }
}