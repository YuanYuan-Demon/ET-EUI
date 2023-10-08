using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class ChatComponent: Entity, IAwake
    {
        public Dictionary<ChatChannel, Queue<ChatMessage>> AllMessages;
    }
}