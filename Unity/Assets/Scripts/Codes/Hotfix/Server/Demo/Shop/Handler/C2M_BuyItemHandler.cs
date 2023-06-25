namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_BuyItemHandler : AMActorLocationRpcHandler<Unit, C2M_BuyItem, M2C_BuyItem>
    {
        protected override async ETTask Run(Unit unit, C2M_BuyItem request, M2C_BuyItem response)
        {
            var config = ItemConfigCategory.Instance.Get(request.ConfigId);
            if (config == null)
            {
                response.Error = ErrorCode.ERR_ItemConfigNotExist;
                response.Message = "物品配置不存在";
                return;
            }

            var nc = unit.GetComponent<NumericComponent>();
            if (nc.GetAsInt(NumericType.Gold) < config.Price * request.Count)
            {
                response.Error = ErrorCode.ERR_GoldNotEnough;
                response.Message = "金币不足";
            }

            var bagComponent = unit.GetComponent<BagComponent>();
            if (!bagComponent.CanAddItem(config.Id, request.Count))
            {
                response.Error = ErrorCode.ERR_BagFull;
                response.Message = "背包已满";
                return;
            }

            if (bagComponent.AddItemByConfigId(config.Id, request.Count))
            {
                nc[NumericType.Gold] -= config.Price * request.Count;
                response.Error = ErrorCode.ERR_Success;
                response.Message = "购买完成";
            }
            else
            {
                response.Error = ErrorCode.ERR_BuyItemError;
                response.Message = "添加道具失败";
            }

            await ETTask.CompletedTask;
        }
    }
}