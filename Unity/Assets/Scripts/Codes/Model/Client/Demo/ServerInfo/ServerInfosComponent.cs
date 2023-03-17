using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    [ChildOf(typeof(ServerInfo))]
    public class ServerInfosComponent : Entity, IAwake, IDestroy
    {
        public List<ServerInfo> ServerInfos { get; } = new List<ServerInfo>();
        public int CurServerId { get; set; } = 0;
    }
}