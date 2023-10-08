namespace ET.Server
{
    [FriendOf(typeof (Player))]
    public static class PlayerSystem
    {
#region 生命周期

        public class PlayerAwakeSystem: AwakeSystem<Player, long, long>
        {
            protected override void Awake(Player self, long accountId, long unitId)
            {
                self.AccountId = accountId;
                self.UnitId = unitId;
            }
        }

        public class PlayerDestroySystem: DestroySystem<Player>
        {
            protected override void Destroy(Player self)
            {
                self.AccountId = 0;
                self.UnitId = 0;
                self.ChatUnitInstanceId = 0;
                self.PlayerState = PlayerState.Disconnect;
                self.ClientSession?.Dispose();
            }
        }

#endregion 生命周期
    }
}