namespace ET.Server
{
    [FriendOf(typeof (ChatUnitComponent))]
    [FriendOfAttribute(typeof (ChatUnit))]
    public static class ChatUnitComponentSystem
    {
#region 生命周期

        public class ChatUnitComponentDestroy: DestroySystem<ChatUnitComponent>
        {
            protected override void Destroy(ChatUnitComponent self)
            {
                foreach (var chatInfoUnit in self.ChatUnits.Values)
                {
                    chatInfoUnit?.Dispose();
                }

                self.ChatUnits.Clear();
            }
        }

#endregion 生命周期

        public static ChatUnit Create(this ChatUnitComponent self, long unitId, string name, long actorId)
        {
            var unitChatInfo = self.AddChildWithId<ChatUnit>(unitId);
            unitChatInfo.AddComponent<MailBoxComponent>();

            unitChatInfo.Name = name;
            unitChatInfo.GateSessionActorId = actorId;
            self.Add(unitChatInfo);
            return unitChatInfo;
        }

        public static void Add(this ChatUnitComponent self, ChatUnit chatUnit)
        {
            if (!self.ChatUnits.TryAdd(chatUnit.Id, chatUnit))
                Log.Error($"UnitChatInfo已经存在! ： [{chatUnit.Id}]");
        }

        public static ChatUnit Get(this ChatUnitComponent self, long id)
        {
            self.ChatUnits.TryGetValue(id, out var chatInfoUnit);
            return chatInfoUnit;
        }

        public static void Remove(this ChatUnitComponent self, long id)
        {
            if (self.ChatUnits.TryGetValue(id, out var chatInfoUnit))
            {
                self.ChatUnits.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }
    }
}