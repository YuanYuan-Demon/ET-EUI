using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    [FriendOf(typeof(DlgShop))]
    public class SelectShopItem_UpdateDlgShop : AEvent<SelectShopItem>
    {
        protected override async ETTask Run(Scene scene, SelectShopItem args)
        {
            DlgShop dlgShop = scene.GetComponent<UIComponent>().GetDlgLogic<DlgShop>();
            dlgShop.SelectItem.ConfigId = (int)args.Id;
            dlgShop.SelectItem.Count = args.Count;

            await ETTask.CompletedTask;
        }
    }
}