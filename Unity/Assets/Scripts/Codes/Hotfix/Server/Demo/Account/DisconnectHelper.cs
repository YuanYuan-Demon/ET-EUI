namespace ET.Server
{
    [FriendOf(typeof (Player))]
    public static class DisconnectHelper
    {
        public static async void Disconnect(this Session session)
        {
            if (session == null || session.IsDisposed)
            {
                return;
            }

            var instanceId = session.InstanceId;

            await TimerComponent.Instance.WaitAsync(1000);

            if (instanceId != session.InstanceId)
                return;
            session.Dispose();
        }

        public static async ETTask KickPlayer(Player player, bool isException = false)
        {
            if (player is null || player.IsDisposed)
                return;
            long instanceId = player.InstanceId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.AccountId))
            {
                if (player.IsDisposed || instanceId != player.InstanceId)
                    return;
                if (!isException)
                {
                    switch (player.PlayerState)
                    {
                        case PlayerState.Disconnect:
                            break;

                        case PlayerState.Gate:
                            break;

                        case PlayerState.Game:
                            //通知游戏逻辑服下线Unit角色逻辑，并将数据存入数据库
                            _ = await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestExitGame()) as M2G_RequestExitGame;

                            //undone:通知聊天服下线聊天Unit
                            //_ = await MessageHelper.CallActor(player.ChatInfoInstanceId, new G2Chat_RequestExitChat()) as Chat2G_RequestExitChat;

                            //通知移除账号角色登录信息
                            long loginCenterSceneId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;
                            _ = await MessageHelper.CallActor(loginCenterSceneId,
                                new G2L_RemoveLoginRecord() { AccountId = instanceId, ServerId = player.DomainZone() }) as L2G_RemoveLoginRecord;
                            break;
                    }
                }

                player.PlayerState = PlayerState.Disconnect;
                player.DomainScene().GetComponent<PlayerComponent>()?.Remove(player.AccountId);
                player.Dispose();
            }

            await TimerComponent.Instance.WaitAsync(300);
        }
    }
}