namespace ET
{
    [FriendClassAttribute(typeof(ET.ChatInfoUnitsComponent))]
    public static class ChatInfoUnitsComponentSystem
    {
        #region 生命周期

        public class ChatInfoUnitsComponentDestroy : DestroySystem<ChatInfoUnitsComponent>
        {
            public override void Destroy(ChatInfoUnitsComponent self)
            {
                foreach (var chatInfoUnit in self.ChatInfoUnitsDict.Values)
                {
                    chatInfoUnit?.Dispose();
                }
            }
        }

        #endregion 生命周期

        public static void Add(this ChatInfoUnitsComponent self, ChatInfoUnit chatInfoUnit)
        {
            if (self.ChatInfoUnitsDict.ContainsKey(chatInfoUnit.Id))
            {
                Log.Error($"ChatInfoUnit已经存在! ： [{chatInfoUnit.Id}]");
                return;
            }
            self.ChatInfoUnitsDict.Add(chatInfoUnit.Id, chatInfoUnit);
        }

        public static ChatInfoUnit Get(this ChatInfoUnitsComponent self, long id)
        {
            self.ChatInfoUnitsDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit);
            return chatInfoUnit;
        }

        public static void Remove(this ChatInfoUnitsComponent self, long id)
        {
            if (self.ChatInfoUnitsDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit))
            {
                self.ChatInfoUnitsDict.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }
    }
}