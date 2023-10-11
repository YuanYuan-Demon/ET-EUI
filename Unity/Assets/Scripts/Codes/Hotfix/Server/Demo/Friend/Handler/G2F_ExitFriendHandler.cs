namespace ET.Server
{
    [ActorMessageHandler(SceneType.Chat)]
    [FriendOfAttribute(typeof (FriendUnit))]
    public class G2F_ExitFriendHandler: AMActorRpcHandler<FriendUnit, G2F_ExitFriend, F2G_ExitFriend>
    {
        protected override async ETTask Run(FriendUnit friendUnit, G2F_ExitFriend request, F2G_ExitFriend response)
        {
            //目前暂不处理, 由好友系统自动管理生命周期
            // var fuc = chatUnit.DomainScene().GetComponent<FriendUnitComponent>();
            // fuc.Remove(chatUnit.Id);
            friendUnit.Online = false;
            await ETTask.CompletedTask;
        }
    }
}