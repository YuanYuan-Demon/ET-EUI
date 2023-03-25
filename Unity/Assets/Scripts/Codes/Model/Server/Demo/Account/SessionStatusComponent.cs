namespace ET.Server
{
    public enum SessionStatus
    {
        Normal,
        Game
    }

    [ComponentOf(typeof (Session))]
    public class SessionStatusComponent: Entity, IAwake
    {
        public SessionStatus Status;
    }
}