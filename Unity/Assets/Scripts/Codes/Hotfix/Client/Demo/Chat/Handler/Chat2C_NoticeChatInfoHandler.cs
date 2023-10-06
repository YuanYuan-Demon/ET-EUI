using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof (ChatMessage))]
    [MessageHandler(SceneType.Client)]
    public class Chat2C_NoticeChatInfoHandler: AMHandler<Chat2C_NoticeChatInfo>
    {
        protected override async ETTask Run(Session session, Chat2C_NoticeChatInfo message)
        {
            await ETTask.CompletedTask;
            var chatComponent = session.DomainScene().GetComponent<CChatComponent>();
            chatComponent.Add(message.NChatMessage);
            await EventSystem.Instance.PublishAsync(session.ClientScene(), new UpdateChat());
        }
    }
}