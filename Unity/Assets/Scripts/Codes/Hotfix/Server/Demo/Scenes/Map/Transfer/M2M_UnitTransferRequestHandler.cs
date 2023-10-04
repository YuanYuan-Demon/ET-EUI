using Unity.Mathematics;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler: AMActorRpcHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            var unitComponent = scene.GetComponent<UnitComponent>();
            var unit = MongoHelper.Deserialize<Unit>(request.Unit);

            unitComponent.Add(unit);

            foreach (var bytes in request.Entitys)
            {
                var entity = MongoHelper.Deserialize<Entity>(bytes);
                unit.AddComponent(entity);
            }

            unit.AddComponent<MoveComponent>();
            unit.AddComponent<PathfindingComponent, string>(scene.Name);

            //添加自动保存数据组件
            unit.AddComponent<UnitDBSaveComponent>();
            //添加数值监听组件
            unit.AddComponent<NumericNoticeComponent>();
            //添加冒险闯关校验组件
            //unit.AddComponent<AdventureCheckComponent>();

            //添加Actor通信组件
            unit.AddComponent<MailBoxComponent>();

            // 通知客户端开始切场景
            var m2CStartSceneChange = new M2C_StartSceneChange() { SceneInstanceId = scene.InstanceId, SceneName = scene.Name };
            MessageHelper.SendToClient(unit, m2CStartSceneChange);

            // 通知客户端创建My Unit
            var m2CCreateUnits = new M2C_CreateMyUnit();
            m2CCreateUnits.Unit = unit.ToNUnit();
            MessageHelper.SendToClient(unit, m2CCreateUnits);

            //通知客户端同步背包信息

#region 背包测试

            ////添加装备
            //for (int i = 0; i < 10; i++)
            //{
            //    int equipId = RandomHelper.RandomInt32(1, 8) + 1000 * RandomHelper.RandomInt32(1, 4) + 10 * RandomHelper.RandomInt32(0, 2);
            //    if (!BagHelper.AddItemByConfigId(unit, equipId))
            //    {
            //        Log.Error("增加背包物品失败");
            //    }
            //}

            ////添加道具
            //for (int i = 0; i < 30; i++)
            //{
            //    int itemId = RandomHelper.RandomInt32(1, 11);
            //    if (!BagHelper.AddItemByConfigId(unit, itemId))
            //    {
            //        Log.Error("增加背包物品失败");
            //    }
            //}

#endregion 背包测试

            ItemUpdateNoticeHelper.SyncAllBagItems(unit);
            ItemUpdateNoticeHelper.SyncAllEquipItems(unit);

            //通知客户端同步打造信息
            //ForgeHelper.SyncAllProduction(unit);

            //通知客户端同步任务信息
            TaskNoticeHelper.SyncAllTaskInfo(unit);

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            //response.NewInstanceId = unit.InstanceId;

            // 解锁location，可以接收发给Unit的消息
            await LocationProxyComponent.Instance.UnLock(unit.Id, request.OldInstanceId, unit.InstanceId);
        }

        //    protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        //    {
        //        UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
        //        Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);

        //        unitComponent.AddChild(unit);
        //        unitComponent.Add(unit);

        //        foreach (byte[] bytes in request.Entitys)
        //        {
        //            Entity entity = MongoHelper.Deserialize<Entity>(bytes);
        //            unit.AddComponent(entity);
        //        }

        //        //unit.AddComponent<MoveComponent>();
        //        //unit.AddComponent<PathfindingComponent, string>(scene.Name);
        //        unit.Position = new float3(-10, 0, -10);

        //        unit.AddComponent<MailBoxComponent>();

        //        // 通知客户端开始切场景
        //        M2C_StartSceneChange m2CStartSceneChange = new M2C_StartSceneChange() { SceneInstanceId = scene.InstanceId, SceneName = scene.Name };
        //        MessageHelper.SendToClient(unit, m2CStartSceneChange);

        //        // 通知客户端创建My Unit
        //        M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
        //        m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
        //        MessageHelper.SendToClient(unit, m2CCreateUnits);

        //        // 加入aoi
        //        unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

        //        // 解锁location，可以接收发给Unit的消息
        //        await LocationProxyComponent.Instance.UnLock(unit.Id, request.OldInstanceId, unit.InstanceId);
        //    }
    }
}