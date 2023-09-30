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

            var request = new M2M_UnitTransferRequest() { Entitys = new() };
            request.OldInstanceId = unitInstanceId;
            request.Unit = unit.ToBson();
            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
            }

            unit.Dispose();

            await LocationProxyComponent.Instance.Lock(unitId, unitInstanceId);
            await ActorMessageSenderComponent.Instance.Call(sceneInstanceId, request);
        }
    }
}