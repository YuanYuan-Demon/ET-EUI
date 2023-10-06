namespace ET.Server
{
    [FriendOf(typeof (ChatInfoUnitsComponent))]
    [FriendOfAttribute(typeof (ChatInfoUnit))]
    public static class ChatInfoUnitsComponentSystem
    {
        public static ChatInfoUnit Create(this ChatInfoUnitsComponent self, long unitId, string name, long actorId)
        {
            var unitChatInfo = self.AddChildWithId<ChatInfoUnit>(unitId);
            unitChatInfo.AddComponent<MailBoxComponent>();

            unitChatInfo.Name = name;
            unitChatInfo.GateSessionActorId = actorId;
            self.Add(unitChatInfo);
            return unitChatInfo;
        }

        public static void Add(this ChatInfoUnitsComponent self, ChatInfoUnit chatInfoUnit)
        {
            if (!self.ChatInfoUnits.TryAdd(chatInfoUnit.Id, chatInfoUnit))
                Log.Error($"UnitChatInfo已经存在! ： [{chatInfoUnit.Id}]");
        }

        public static ChatInfoUnit Get(this ChatInfoUnitsComponent self, long id)
        {
            self.ChatInfoUnits.TryGetValue(id, out var chatInfoUnit);
            return chatInfoUnit;
        }

        public static void Remove(this ChatInfoUnitsComponent self, long id)
        {
            if (self.ChatInfoUnits.TryGetValue(id, out var chatInfoUnit))
            {
                self.ChatInfoUnits.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }

#region 生命周期

        public class ChatInfoUnitsComponentDestroy: DestroySystem<ChatInfoUnitsComponent>
        {
            protected override void Destroy(ChatInfoUnitsComponent self)
            {
                foreach (var chatInfoUnit in self.ChatInfoUnits.Values)
                    chatInfoUnit?.Dispose();
            }
        }

#endregion 生命周期
    }
}