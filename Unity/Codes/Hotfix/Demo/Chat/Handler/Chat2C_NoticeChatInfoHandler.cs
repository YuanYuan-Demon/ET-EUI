namespace ET
{
    [FriendClassAttribute(typeof(ET.ChatInfo))]
    public class Chat2C_NoticeChatInfoHandler : AMHandler<Chat2C_NoticeChatInfo>
    {
        protected override void Run(Session session, Chat2C_NoticeChatInfo message)
        {
            ChatComponent chatComponent = session.DomainScene().GetComponent<ChatComponent>();
            ChatInfo chatInfo = chatComponent.AddChild<ChatInfo>(true);
            chatInfo.Name = message.Name;
            chatInfo.Message = message.ChatMessage;
            chatComponent.Add(chatInfo);
            Game.EventSystem.Publish(new EventType.UpdateChatInfo() { ZoneScene = session.ZoneScene() });
        }
    }
}