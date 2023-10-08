using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class CFriendComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, FriendInfo> Friends = new();
        public Dictionary<long, FriendInfo> FriendApplys = new();
    }
}