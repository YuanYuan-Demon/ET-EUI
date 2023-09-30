using System.Linq;
using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    [FriendOfAttribute(typeof (DlgRoles))]
    public class SelectRole_RefreshRoleItem: AEvent<SelectRole>
    {
        protected override async ETTask Run(Scene scene, SelectRole args)
        {
            var itemRoles = UIComponent.Instance.GetDlgLogic<DlgRoles>().ScrollItemRoleInfos;
            foreach (var item in itemRoles.Where(item => args.RoleId != item.DataId && item.DataId != 0))
            {
                item.OnDeSelect();
            }

            await ETTask.CompletedTask;
        }
    }
}