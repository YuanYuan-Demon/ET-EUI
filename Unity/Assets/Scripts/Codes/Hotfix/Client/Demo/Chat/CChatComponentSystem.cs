using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof (CChatComponent))]
    [FriendOfAttribute(typeof (ChatMessage))]
    public static class CChatComponentSystem
    {
        public static ChatMessage Create(this CChatComponent self, string name, string message)
        {
            var chatInfo = self.AddChild<ChatMessage>(true);
            chatInfo.FromName = name;
            chatInfo.Message = message;
            self.Add(chatInfo);
            return chatInfo;
        }

        public static void Add(this CChatComponent self, NChatMessage nChat)
        {
            var chatMessage = self.AddChild<ChatMessage>();
            chatMessage.FromNChatMessage(nChat);
            self.Add(chatMessage);
        }

        public static void Add(this CChatComponent self, ChatMessage chatMessage)
        {
            if (chatMessage.Parent != self)
                self.AddChild(chatMessage);

            //客户端最大值留存100条世界聊天信息
            var messages = self.AllMessages[chatMessage.Channel];
            if (messages.Count >= 100)
            {
                var oldChatInfo = messages.Dequeue();
                oldChatInfo?.Dispose();
            }

            messages.Enqueue(chatMessage);
            self.AllMessages[ChatChannel.All].Enqueue(chatMessage);

            //可以扩展自定义聊天频道
            // foreach (var (channel, messages2) in self.AllMessages)
            // {
            //     if ((channel & chatMessage.Channel) == channel)
            //         messages2.Enqueue(chatMessage);
            // }
        }

        public static int GetMessageCount(this CChatComponent self, ChatChannel channel) => self.AllMessages[channel].Count;

        public static ChatMessage GetChatMessageByIndex(this CChatComponent self, ChatChannel channel, int index)
            => self.AllMessages[channel].ElementAt(index);

        public static List<ChatMessage> GetMessagesByChannel(this CChatComponent self, ChatChannel channel) => self.AllMessages[channel].ToList();

#region 生命周期

        public class CChatComponentAwakeSystem: AwakeSystem<CChatComponent>
        {
            protected override void Awake(CChatComponent self)
            {
                self.AllMessages = new();
                foreach (var e in Enum.GetValues(typeof (ChatChannel)))
                    self.AllMessages[(ChatChannel)e] = new(100);
            }
        }

        public class CChatComponentDestroySystem: DestroySystem<CChatComponent>
        {
            protected override void Destroy(CChatComponent self)
            {
                foreach (var messages in self.AllMessages.Values)
                {
                    foreach (var message in messages)
                        message?.Dispose();

                    messages.Clear();
                }
            }
        }

#endregion 生命周期
    }
}