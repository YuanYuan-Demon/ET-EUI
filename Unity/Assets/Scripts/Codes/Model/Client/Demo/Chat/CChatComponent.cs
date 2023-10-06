using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class CChatComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<ChatChannel, Queue<ChatMessage>> AllMessages = new();
    }
}