namespace ET.Server
{
    [FriendOf(typeof (ChatInfoUnitsComponent))]
    [FriendOf(typeof (ChatInfoUnit))]
    [ActorMessageHandler(SceneType.Chat)]
    [FriendOfAttribute(typeof (ChatMessage))]
    public class C2Chat_SendChatInfoHandler: AMActorRpcHandler<ChatInfoUnit, C2Chat_SendChatInfo, Chat2C_SendChatInfo>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2Chat_SendChatInfo request, Chat2C_SendChatInfo response)
        {
            if (string.IsNullOrEmpty(request.NChatMessage.message))
            {
                response.Error = ErrorCode.ERR_ChatMessageEmpty;
                return;
            }

            //向其他玩家转发聊天信息
            var chatInfoUnitsComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitsComponent>();
            foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnits.Values)
            {
                MessageHelper.SendActor(otherUnit.GateSessionActorId,
                    new Chat2C_NoticeChatInfo() { NChatMessage = request.NChatMessage });
            }

            //将信息存储至服务器中
            var cmc = chatInfoUnit.DomainScene().GetComponent<ChatComponent>();
            cmc.AddMessage(request.NChatMessage);
            await ETTask.CompletedTask;
        }
    }
}