namespace ET.Server
{
    [ActorMessageHandler(SceneType.Chat)]
    public class G2F_ExitFriendHandler: AMActorRpcHandler<ChatUnit, G2F_ExitFriend, F2G_ExitFriend>
    {
        protected override async ETTask Run(ChatUnit chatUnit, G2F_ExitFriend request, F2G_ExitFriend response)
        {
            var fuc = chatUnit.DomainScene().GetComponent<FriendUnitComponent>();

            fuc.Remove(chatUnit.Id);

            await ETTask.CompletedTask;
        }
    }
}