namespace ET.Server
{
    [ActorMessageHandler(SceneType.Chat)]
    public class G2Chat_RequestExitChatHandler: AMActorRpcHandler<ChatInfoUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response)
        {
            var chatInfoUnitsComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitsComponent>();

            chatInfoUnitsComponent.Remove(chatInfoUnit.Id);

            await ETTask.CompletedTask;
        }
    }
}