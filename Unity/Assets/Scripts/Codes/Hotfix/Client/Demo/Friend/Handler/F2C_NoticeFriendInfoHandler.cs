using System;

namespace ET.Client.Handler
{
    [MessageHandler(SceneType.Client)]
    public class F2C_NoticeFriendInfoHandler: AMHandler<F2C_NoticeFriendInfo>
    {
        protected override async ETTask Run(Session session, F2C_NoticeFriendInfo message)
        {
            var cfc = session.ClientScene().GetComponent<CFriendComponent>();
            switch (message.Type)
            {
                case FriendUpdateType.AddOrUpdateFriend:
                    cfc.AddOrUpdateFriend(message.NFriend);
                    break;
                case FriendUpdateType.DeleteFriend:
                    cfc.DeleteFriend(message.NFriend.UnitId);
                    break;
                case FriendUpdateType.AddApply:
                    cfc.AddApply(message.NFriend);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            await ETTask.CompletedTask;
        }
    }
}