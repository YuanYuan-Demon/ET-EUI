namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class AccountInfoComponent: Entity, IAwake, IDestroy
    {
        public string Token { get; set; }
        public long AccountId { get; set; }
        public string RealmToken { get; set; }
        public string RealmAddress { get; set; }
    }
}