namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler : AMActorRpcHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);

            unitComponent.AddChild(unit);
            unitComponent.Add(unit);

            foreach (var bytes in request.Entitys)
            {
                var entity = MongoHelper.Deserialize<Entity>(bytes);
                unit.AddComponent(entity);
            }

            //添加自动保存数据组件
            unit.AddComponent<UnitDBSaveComponent>();
            //添加数值监听组件
            unit.AddComponent<NumericNoticeComponent>();
            //添加冒险闯关校验组件
            unit.AddComponent<AdventureCheckComponent>();

            //添加Actor通信组件
            unit.AddComponent<MailBoxComponent>();

            // 通知客户端开始切场景
            //M2C_StartSceneChange m2CStartSceneChange = new()
            //{
            //    SceneInstanceId = scene.InstanceId,
            //    SceneName = scene.Name
            //};
            //MessageHelper.SendToClient(unit, m2CStartSceneChange);

            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MessageHelper.SendToClient(unit, m2CCreateUnits);

            //通知客户端同步背包信息
            //ItemUpdateNoticeHelper.SyncAllBagItems(unit);
            //ItemUpdateNoticeHelper.SyncAllEquipItems(unit);

            //通知客户端同步打造信息
            //ForgeHelper.SyncAllProduction(unit);

            //通知客户端同步任务信息
            //TaskNoticeHelper.SyncAllTaskInfo(unit);

            // 加入aoi
            //unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);

            //response.NewInstanceId = unit.InstanceId;

            // 解锁location，可以接收发给Unit的消息
            await LocationProxyComponent.Instance.UnLock(unit.Id, request.OldInstanceId, unit.InstanceId);
        }
    }
}