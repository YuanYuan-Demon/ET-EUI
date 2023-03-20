namespace ET.Server
{
    [FriendOf(typeof(Production))]
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_ReceiveProductionHandler : AMActorLocationRpcHandler<Unit, C2M_ReceiveProduction, M2C_ReceiveProduction>
    {
        protected override async ETTask Run(Unit unit, C2M_ReceiveProduction request, M2C_ReceiveProduction response)
        {
            ForgeComponent forgeComponent = unit.GetComponent<ForgeComponent>();
            BagComponent bagComponent = unit.GetComponent<BagComponent>();

            if (bagComponent.IsMaxLoad())
            {
                response.Error = ErrorCode.ERR_BagMaxLoad;
                return;
            }

            if (!forgeComponent.IsExistProductionOverQueue(request.ProducitonId))
            {
                response.Error = ErrorCode.ERR_NoMakeQueueOver;
                return;
            }

            Production production = forgeComponent.GetProductionById(request.ProducitonId);

            var config = ForgeProductionConfigCategory.Instance.Get(production.ConfigId);
            if (!BagHelper.AddItemByConfigId(unit, config.ItemConfigId))
            {
                response.Error = ErrorCode.ERR_AddBagItemError;
                return;
            }
            EventSystem.Instance.Publish(unit.DomainScene(), new EventType.MakeProdutionOver()
            {
                Unit = unit,
                ProductionConfigId = production.ConfigId
            });
            production.Reset();

            response.ProductionProto = production.ToMessage();

            await ETTask.CompletedTask;
        }
    }
}