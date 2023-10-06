using System;
using ET.Client;

namespace ET.Server
{
    [FriendOfAttribute(typeof (ChatComponent))]
    [FriendOfAttribute(typeof (ChatMessage))]
    public static class ChatComponentSystem
    {
        public static void AddMessage(this ChatComponent self, NChatMessage nMessage)
        {
            var chatMessage = self.AddChild<ChatMessage>();
            chatMessage.FromNChatMessage(nMessage);
            self.AddMessage(chatMessage);
        }

        public static void AddMessage(this ChatComponent self, ChatMessage chatMessage)
        {
            if (chatMessage.Parent != self)
                self.AddChild(chatMessage);

            if (chatMessage.Channel == ChatChannel.Private)
                self.PrivateTarget.Enqueue(chatMessage.ToId);

            self.AllMessages[chatMessage.Channel].Enqueue(chatMessage);
            self.AllMessages[ChatChannel.All].Enqueue(chatMessage);
        }

#region 生命周期

        public class ChatComponentAwakeSystem: AwakeSystem<ChatComponent>
        {
            protected override void Awake(ChatComponent self)
            {
                self.AllMessages = new();
                foreach (var e in Enum.GetValues(typeof (ChatChannel)))
                {
                    var channel = (ChatChannel)e;
                    if (channel == ChatChannel.System)
                        continue;
                    self.AllMessages[(ChatChannel)e] = new(100);
                }
            }
        }

#endregion
    }
}