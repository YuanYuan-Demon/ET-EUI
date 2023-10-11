namespace ET.Server
{
    [FriendOf(typeof (ChatUnitComponent))]
    [FriendOf(typeof (ChatUnit))]
    [ActorMessageHandler(SceneType.Chat)]
    [FriendOfAttribute(typeof (ChatMessage))]
    public class C2Chat_SendChatInfoHandler: AMActorRpcHandler<ChatUnit, C2Chat_SendChatInfo, Chat2C_SendChatInfo>
    {
        protected override async ETTask Run(ChatUnit chatUnit, C2Chat_SendChatInfo request, Chat2C_SendChatInfo response)
        {
            if (string.IsNullOrEmpty(request.NChatMessage.message))
            {
                response.Error = ErrorCode.ERR_ChatMessageEmpty;
                return;
            }

            //向其他玩家转发聊天信息
            ChatUnitComponent chatUnitComponent = chatUnit.DomainScene().GetComponent<ChatUnitComponent>();
            request.NChatMessage.fromName = chatUnit.Name;
            foreach (ChatUnit otherUnit in chatUnitComponent.ChatUnits.Values)
            {
                MessageHelper.SendActor(otherUnit.GateSessionActorId,
                    new Chat2C_NoticeChatInfo() { NChatMessage = request.NChatMessage });
            }

            //将信息存储至服务器中
            ChatComponent cmc = chatUnit.DomainScene().GetComponent<ChatComponent>();
            cmc.AddMessage(request.NChatMessage);
            await ETTask.CompletedTask;
        }
    }
}