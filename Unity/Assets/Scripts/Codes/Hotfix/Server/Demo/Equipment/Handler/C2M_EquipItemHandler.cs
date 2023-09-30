namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_EquipItemHandler: AMActorLocationRpcHandler<Unit, C2M_EquipItem, M2C_EquipItem>
    {
        protected override async ETTask Run(Unit unit, C2M_EquipItem request, M2C_EquipItem response)
        {
            BagComponent bagComponent = unit.GetComponent<BagComponent>();
            EquipmentsComponent equipmentsComponent = unit.GetComponent<EquipmentsComponent>();

            if (!bagComponent.ContainItem(request.ItemUid))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            Item bagItem = bagComponent.GetItemById(request.ItemUid);
            var equipPosition = (EquipPosition)bagItem.EquipConfig.EquipPosition;
            bagComponent.RemoveItem(bagItem);

            Item equipItem = equipmentsComponent.GetItemByPosition(equipPosition);

            if (equipItem != null)
            {
                if (bagComponent.CanAddItem(equipItem))
                {
                    equipItem = equipmentsComponent.UnloadEquipItemByPosition(equipPosition);
                    bagComponent.AddItem(equipItem);
                }
                else
                {
                    bagComponent.AddItem(bagItem);
                    response.Error = ErrorCode.ERR_AddBagItemError;
                    return;
                }
            }

            if (!equipmentsComponent.EquipItem(bagItem))
            {
                response.Error = ErrorCode.ERR_EquipItemError;
                return;
            }

            await ETTask.CompletedTask;
        }
    }
}