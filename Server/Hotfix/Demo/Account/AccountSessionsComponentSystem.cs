namespace ET
{
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            return self.AccountSessions.TryGetValue(accountId, out var instanceId)
                ? instanceId : 0;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long instanceId)
        {
            self.AccountSessions[accountId] = instanceId;
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessions.ContainsKey(accountId))
            {
                self.AccountSessions.Remove(accountId);
            }
        }
    }

    public class AccountSessionsComponentDestroySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessions.Clear();
        }
    }
}