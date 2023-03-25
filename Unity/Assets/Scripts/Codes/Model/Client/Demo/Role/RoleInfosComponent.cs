using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class RoleInfosComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, RoleInfo> RoleInfos = new();
        public long CurRoleId = 0;
    }
}