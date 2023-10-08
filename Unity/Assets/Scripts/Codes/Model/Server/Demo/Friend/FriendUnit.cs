using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (FriendUnitComponent))]
    public class FriendUnit: Entity, IAwake, IDestroy
    {
        public Dictionary<long, FriendInfo> Friends = new();
        public Dictionary<long, FriendInfo> Application = new();
        public long GateSessionActorId;
        public string Name;
    }
}