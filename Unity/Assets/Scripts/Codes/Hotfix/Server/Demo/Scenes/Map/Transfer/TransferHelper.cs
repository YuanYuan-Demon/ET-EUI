using MongoDB.Bson;

namespace ET.Server
{
    public static class TransferHelper
    {
        public static async ETTask TransferAtFrameFinish(Unit unit, long sceneInstanceId, string sceneName)
        {
            await Game.WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, sceneName);
        }

        public static async ETTask Transfer(Unit unit, long sceneInstanceId, string sceneName)
        {
            // location加锁
            long unitId = unit.Id;
            long unitInstanceId = unit.InstanceId;

            // 通知客户端开始切场景
            M2C_StartSceneChange m2CStartSceneChange = new()
            {
                SceneInstanceId = sceneInstanceId,
                SceneName = sceneName
            };
            MessageHelper.SendToClient(unit, m2CStartSceneChange);

            M2M_UnitTransferRequest request = new()
            {
                OldInstanceId = unitInstanceId,
                Unit = unit.ToBson()
            };

            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
            }
            // 删除Mailbox,让发给Unit的ActorLocation消息重发
            unit.RemoveComponent<MailBoxComponent>();

            await LocationProxyComponent.Instance.Lock(unitId, unitInstanceId);
            await ActorMessageSenderComponent.Instance.Call(sceneInstanceId, request);
            unit.Dispose();
        }
    }
}