namespace ET.Server
{
    [FriendOf(typeof(Player))]
    [ActorMessageHandler(SceneType.Gate)]
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response)
        {
            var accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.GateLoginLock, accountId))
            {
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                var player = playerComponent.Get(accountId);
                if (player == null)
                {
                    return;
                }
                //强制玩家下线
                scene.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                Session gateSession = player.ClientSession;
                if (gateSession != null && !gateSession.IsDisposed)
                {
                    gateSession.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_OtherAccountLogin });
                    gateSession.Disconnect();
                }
                player.AddComponent<PlayerOfflineOutTimeComponent>();
            }
        }
    }
}