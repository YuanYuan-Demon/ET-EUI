namespace ET.Client
{
    public static class AccountInfoComponentSystem
    {
        public class AccountInfoComponentDestroySystem : DestroySystem<AccountInfoComponent>
        {
            protected override void Destroy(AccountInfoComponent self)
            {
                self.Token = string.Empty;
                self.AccountId = 0;
            }
        }
    }
}