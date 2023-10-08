using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class RoleInfoComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, RoleInfo> RoleInfos;
    }
}