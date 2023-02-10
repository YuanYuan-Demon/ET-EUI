using System;

namespace ET
{
    [ActorMessageHandler]
    public class M2M_UnitTransferRequestHandler : AMActorRpcHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response, Action reply)
        {
            await ETTask.CompletedTask;
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = request.Unit;

            unitComponent.AddChild(unit);
            unitComponent.Add(unit);

            //添加自动保存数据组件
            unit.AddComponent<UnitDBSaveComponent>();
            //添加数值监听组件
            unit.AddComponent<NumericNoticeComponent>();
            //添加冒险闯关校验组件
            unit.AddComponent<AdventureCheckComponent>();

            //添加Actor通信组件
            unit.AddComponent<MailBoxComponent>();

            foreach (Entity entity in request.Entitys)
            {
                unit.AddComponent(entity);
            }

            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MessageHelper.SendToClient(unit, m2CCreateUnits);

            // 加入aoi
            //unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);

            response.NewInstanceId = unit.InstanceId;

            reply();
        }
    }
}