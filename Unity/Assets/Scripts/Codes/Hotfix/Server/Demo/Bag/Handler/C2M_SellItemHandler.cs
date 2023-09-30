namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    [FriendOf(typeof (Item))]
    public class C2M_SellItemHandler: AMActorLocationRpcHandler<Unit, C2M_SellItem, M2C_SellItem>
    {
        protected override async ETTask Run(Unit unit, C2M_SellItem request, M2C_SellItem response)
        {
            BagComponent bagComponent = unit.GetComponent<BagComponent>();

            if (!bagComponent.ContainItem(request.ItemUid))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            Item bagItem = bagComponent.GetItemById(request.ItemUid);
            int addGold = bagItem.Config.SellPrice * request.Count;

            bagComponent.RemoveItem(bagItem, request.Count);

            unit.GetComponent<NumericComponent>()[NumericType.Gold] += addGold;

            await ETTask.CompletedTask;
        }
    }
}