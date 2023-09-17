using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    [FriendOfAttribute(typeof(ET.Client.DlgEquip))]
    public class EquipItem_RefreshEquipSlot : AEvent<EquipItem>
    {
        protected override async ETTask Run(Scene scene, EquipItem args)
        {
            UIComponent.Instance.GetDlgLogic<DlgEquip>()?.EquipSlots[args.EquipPosition].RefreshEquip();
            await ETTask.CompletedTask;
        }
    }
}