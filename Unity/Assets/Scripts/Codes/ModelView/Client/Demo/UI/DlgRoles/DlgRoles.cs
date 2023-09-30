using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoles: Entity, IAwake, IUILogic
    {
        public int index;
        public List<RoleInfo> RoleInfos;
        public List<Scroll_Item_RoleInfo> ScrollItemRoleInfos = new();
        public DlgRolesViewComponent View => this.GetComponent<DlgRolesViewComponent>();
    }
}