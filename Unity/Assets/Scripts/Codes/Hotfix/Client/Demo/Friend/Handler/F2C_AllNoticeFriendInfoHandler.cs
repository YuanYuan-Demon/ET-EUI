namespace ET.Client.Handler
{
    [MessageHandler(SceneType.Client)]
    [FriendOfAttribute(typeof (CFriendComponent))]
    public class F2C_AllNoticeFriendInfoHandler: AMHandler<F2C_AllNoticeFriendInfo>
    {
        protected override async ETTask Run(Session session, F2C_AllNoticeFriendInfo message)
        {
            var cfc = session.ClientScene().GetComponent<CFriendComponent>();
            foreach (var nFriend in message.NFriends)
            {
                cfc.AddOrUpdateFriend(nFriend);
            }

            foreach (var nApply in message.NApplys)
            {
                cfc.AddApply(nApply);
            }

            await ETTask.CompletedTask;
        }
    }
}