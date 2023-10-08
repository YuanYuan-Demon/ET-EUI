using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (ChatUnitComponent))]
    public class ChatUnit: Entity, IAwake, IDestroy
    {
        public Queue<(long target, ChatMessage message)> PrivateTarget;
        public long GateSessionActorId;

        public string Name;
    }
}