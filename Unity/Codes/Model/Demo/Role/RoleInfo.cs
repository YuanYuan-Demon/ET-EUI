namespace ET
{
    public enum RoleInfoStatus
    {
        Normal,
        Freeze
    }

    [ComponentOf(typeof(Unit))]
#if SERVER
    public class RoleInfo : Entity, IAwake, ITransfer, IUnitCache
#else
    public class RoleInfo : Entity,IAwake
#endif
    {
        public string Name;
        public int ServerId;
        public int Status;
        public long AccountId;
        public long LastLoginTIme;
        public long CreateTime;
    }
}