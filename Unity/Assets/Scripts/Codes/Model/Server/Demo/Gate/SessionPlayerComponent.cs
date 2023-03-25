namespace ET.Server
{
    [ComponentOf(typeof (Session))]
    public class SessionPlayerComponent: Entity, IAwake, IDestroy
    {
        public long PlayerId { get; set; }
        public long PlayerInstanceId { get; set; }
        public long AccountId { get; set; }
    }
}