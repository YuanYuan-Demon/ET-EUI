namespace ET.Client
{
    [FriendOf(typeof(ChatInfo))]
    [MessageHandler(SceneType.Client)]
    public class Chat2C_NoticeChatInfoHandler : AMHandler<Chat2C_NoticeChatInfo>
    {
        protected override async ETTask Run(Session session, Chat2C_NoticeChatInfo message)
        {
            await ETTask.CompletedTask;
            ChatComponent chatComponent = session.DomainScene().GetComponent<ChatComponent>();
            ChatInfo chatInfo = chatComponent.AddChild<ChatInfo>(true);
            chatInfo.Name = message.Name;
            chatInfo.Message = message.ChatMessage;
            chatComponent.Add(chatInfo);
            EventSystem.Instance.Publish(session.ClientScene(), new EventType.UpdateChatInfo());
        }
    }
}