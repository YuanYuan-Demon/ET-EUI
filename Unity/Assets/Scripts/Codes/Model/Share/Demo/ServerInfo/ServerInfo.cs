namespace ET
{
    public enum ServerStatus
    {
        Normal,
        Stop
    }

    [ChildOf]
    public class ServerInfo: Entity, IAwake
    {
        public int Status { get; set; }
        public string ServerName { get; set; }
    }
}