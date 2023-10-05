using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    [FriendOfAttribute(typeof (DlgEquip))]
    public class ChangeEquipItem_RefreshEquipSlot: AEvent<ChangeEquipItem>
    {
        protected override async ETTask Run(Scene scene, ChangeEquipItem args)
        {
            UIComponent.Instance.GetDlgLogic<DlgEquip>()?.EquipSlots[args.EquipPosition].RefreshEquip();
            UIComponent.Instance.GetDlgLogic<DlgEquip>().RefreshEquipList();
            await ETTask.CompletedTask;
        }
    }
}