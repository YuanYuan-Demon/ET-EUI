using System;

namespace ET
{
    [FriendClassAttribute(typeof(ET.ChatInfoUnitsComponent))]
    [FriendClassAttribute(typeof(ET.ChatInfoUnit))]
    public class C2Chat_SendChatInfoHandler : AMActorRpcHandler<ChatInfoUnit, C2Chat_SendChatInfo, Chat2C_SendChatInfo>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2Chat_SendChatInfo request, Chat2C_SendChatInfo response, Action reply)
        {
            if (string.IsNullOrEmpty(request.ChatMessage))
            {
                response.Error = ErrorCode.ERR_ChatMessageEmpty;
                reply();
                return;
            }

            //向其他玩家转发聊天信息
            ChatInfoUnitsComponent chatInfoUnitsComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitsComponent>();
            foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
            {
                MessageHelper.SendActor(otherUnit.GateSessionActorId, new Chat2C_NoticeChatInfo()
                {
                    Name = chatInfoUnit.Name,
                    ChatMessage = request.ChatMessage
                });
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}