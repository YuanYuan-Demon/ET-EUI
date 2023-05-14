namespace ET
{
    public enum RoleInfoStatus
    {
        Normal,
        Freeze
    }

    public enum RoleClass
    {
        Warrior,
        Wizard,
        Archer
    }

    [ComponentOf(typeof(Unit))]
    [ChildOf]
    public class RoleInfo : Entity, IAwake, ITransfer, IUnitCache
    {
        public string Name;
        public int ServerId;
        public long AccountId;
        public RoleClass RoleClass;
        public int Level;
        public int Status;
        public long LastLoginTIme;
        public long CreateTime;
    }
}