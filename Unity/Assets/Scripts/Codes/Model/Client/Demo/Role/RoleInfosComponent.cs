using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class RoleInfosComponent: Entity, IAwake, IDestroy
    {
        public long CurRoleId = 0;
        public List<RoleInfo> RoleInfos = new();
    }
}