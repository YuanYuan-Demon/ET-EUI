namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_UnloadEquipItemHandler: AMActorLocationRpcHandler<Unit, C2M_UnloadEquipItem, M2C_UnloadEquipItem>
    {
        protected override async ETTask Run(Unit unit, C2M_UnloadEquipItem request, M2C_UnloadEquipItem response)
        {
            var bagComponent = unit.GetComponent<BagComponent>();
            var equipmentsComponent = unit.GetComponent<EquipmentsComponent>();

            if (bagComponent.IsMaxLoad())
            {
                response.Error = ErrorCode.ERR_BagMaxLoad;
                return;
            }

            if (!equipmentsComponent.IsEquipItemByPosition(request.EquipPosition))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            var equipItem = equipmentsComponent.GetItemByPosition(request.EquipPosition);

            if (!bagComponent.CanAddItem(equipItem))
            {
                response.Error = ErrorCode.ERR_AddBagItemError;
                return;
            }

            equipItem = equipmentsComponent.UnEquipItemByPosition(request.EquipPosition);

            bagComponent.AddItem(equipItem);

            await ETTask.CompletedTask;
        }
    }
}