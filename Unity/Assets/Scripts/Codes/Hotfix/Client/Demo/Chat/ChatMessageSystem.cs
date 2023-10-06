namespace ET.Client
{
    [FriendOfAttribute(typeof (ChatMessage))]
    public static class ChatMessageSystem
    {
        public static void FromNChatMessage(this ChatMessage self, NChatMessage nChat)
        {
            self.Channel = nChat.Channel;
            self.Message = nChat.message;
            self.FromName = nChat.fromName;
            self.FromId = nChat.fromID;
            self.ToId = nChat.toID;
            self.ToName = nChat.toName;
            self.Time = nChat.time;
        }

#region 生命周期

        public class ChatMessageDestroySystem: DestroySystem<ChatMessage>
        {
            protected override void Destroy(ChatMessage self)
            {
                self.Message = null;
                self.FromName = null;
            }
        }

#endregion
    }
}