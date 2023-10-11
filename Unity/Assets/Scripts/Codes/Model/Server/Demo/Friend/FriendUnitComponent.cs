using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class FriendUnitComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, FriendUnit> FriendUnits = new();
        public Dictionary<string, long> NameToId = new();
    }
}