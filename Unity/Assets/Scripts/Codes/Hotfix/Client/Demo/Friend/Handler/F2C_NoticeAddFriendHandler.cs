using ET.Client.EventType;

namespace ET.Client.Handler
{
    [MessageHandler(SceneType.Client)]
    public class F2C_NoticeAddFriendHandler: AMHandler<F2C_NoticeAddFriend>
    {
        protected override async ETTask Run(Session session, F2C_NoticeAddFriend message)
        {
            session.ClientScene().GetComponent<CFriendComponent>().AddFriend(message.NFriend);
            EventSystem.Instance.PublishAsync(session.DomainScene(), new FriendUpdate() { Type = FriendUpdateType.FriendUpdate }).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}