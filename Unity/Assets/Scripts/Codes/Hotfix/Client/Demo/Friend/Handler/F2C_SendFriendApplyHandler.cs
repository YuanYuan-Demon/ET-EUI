using ET.Client.EventType;

namespace ET.Client.Handler
{
    [MessageHandler(SceneType.Client)]
    public class F2C_SendFriendApplyHandler: AMHandler<F2C_SendFriendApply>
    {
        protected override async ETTask Run(Session session, F2C_SendFriendApply message)
        {
            session.ClientScene().GetComponent<CFriendComponent>().AddApply(message.NFriend);
            EventSystem.Instance.PublishAsync(session.DomainScene(), new FriendUpdate() { Type = FriendUpdateType.ApplyUpdate }).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}