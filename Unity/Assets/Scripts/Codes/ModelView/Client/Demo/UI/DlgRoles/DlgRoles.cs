using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoles : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Role> ScrollItemRoleInfos = new();

        public DlgRolesViewComponent View { get => this.GetComponent<DlgRolesViewComponent>(); }
    }
}