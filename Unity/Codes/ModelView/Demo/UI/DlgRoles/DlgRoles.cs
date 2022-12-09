using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoles : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Role> ScrollItemRoleInfos = new();
        public DlgRolesViewComponent View { get => this.Parent.GetComponent<DlgRolesViewComponent>(); }
    }
}