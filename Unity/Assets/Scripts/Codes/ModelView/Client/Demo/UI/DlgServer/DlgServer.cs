using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgServer: Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_ServerInfo> ScrollItemServerInfos = new();

        public DlgServerViewComponent View => this.GetComponent<DlgServerViewComponent>();
    }
}