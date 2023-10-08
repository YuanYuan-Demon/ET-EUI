using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class CRoleInfosComponent: Entity, IAwake, IDestroy
    {
        public RoleInfo CurrentRole = null;

        public long CurRoleId = 0;
        public List<RoleInfo> RoleInfos = new();
    }
}