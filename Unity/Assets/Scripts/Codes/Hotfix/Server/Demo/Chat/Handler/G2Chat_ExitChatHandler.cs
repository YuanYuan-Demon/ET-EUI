namespace ET.Server
{
    [ActorMessageHandler(SceneType.Chat)]
    public class G2Chat_ExitChatHandler: AMActorRpcHandler<ChatUnit, G2Chat_ExitChat, Chat2G_ExitChat>
    {
        protected override async ETTask Run(ChatUnit chatUnit, G2Chat_ExitChat request, Chat2G_ExitChat response)
        {
            var chatInfoUnitsComponent = chatUnit.DomainScene().GetComponent<ChatUnitComponent>();

            chatInfoUnitsComponent.Remove(chatUnit.Id);

            await ETTask.CompletedTask;
        }
    }
}