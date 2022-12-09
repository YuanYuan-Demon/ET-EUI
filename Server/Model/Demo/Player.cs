namespace ET
{
    public enum PlayerStatus
    {
        Disconnect,
        Gate,
        Game,
    }

    public sealed class Player : Entity, IAwake<long, long>
    {
        public long AccountId;
        public long UnitId;
        public PlayerStatus Status;
        public Session ClientSession;
    }
}