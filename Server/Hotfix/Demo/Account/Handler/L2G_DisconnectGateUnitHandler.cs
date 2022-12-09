using System;

namespace ET
{
    [FriendClassAttribute(typeof(ET.Player))]
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            var accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.GateLoginLock, accountId))
            {
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                var player = playerComponent.Get(accountId);
                if (player == null)
                {
                    reply();
                    return;
                }
                //Todo:强制玩家下线
                scene.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                Session gateSession = player.ClientSession;
                if (gateSession != null && !gateSession.IsDisposed)
                {
                    gateSession.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_OtherAccountLogin });
                    gateSession.Disconnect();
                }
                player.AddComponent<PlayerOfflineOutTimeComponent>();
            }
            reply();
        }
    }
}