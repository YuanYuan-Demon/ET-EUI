namespace ET.Server
{
    [FriendOfAttribute(typeof (FriendUnitComponent))]
    [FriendOfAttribute(typeof (FriendUnit))]
    public static class FriendComponentSystem
    {
#region 生命周期

        public class FriendComponentDestroySystem: DestroySystem<FriendUnitComponent>
        {
            protected override void Destroy(FriendUnitComponent self)
            {
                foreach (var friendUnit in self.FriendUnits.Values)
                {
                    friendUnit?.Dispose();
                }

                self.FriendUnits.Clear();
            }
        }

#endregion 生命周期

        public static FriendUnit Create(this FriendUnitComponent self, long unitId, long actorId, string name)
        {
            var friendUnit = self.AddChildWithId<FriendUnit>(unitId);
            friendUnit.AddComponent<MailBoxComponent>();
            friendUnit.GateSessionActorId = actorId;
            friendUnit.Name = name;
            self.Add(friendUnit);
            return friendUnit;
        }

        public static void Add(this FriendUnitComponent self, FriendUnit chatUnit) => self.FriendUnits.TryAdd(chatUnit.Id, chatUnit);

        public static void Remove(this FriendUnitComponent self, long id)
        {
            if (self.FriendUnits.TryGetValue(id, out var chatInfoUnit))
            {
                self.FriendUnits.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }

        public static async ETTask SendAddFriendRequest(this FriendUnitComponent self, long fromId, long toId)
        {
            self.FriendUnits.TryGetValue(fromId, out var sender);
            if (self.FriendUnits.TryGetValue(toId, out var target))
            {
                var friendInfo = await target.AddApply(fromId);
                MessageHelper.SendActor(target.GateSessionActorId, new F2C_SendFriendApply() { NFriend = friendInfo.ToNFriend() });
            }
        }

        public static FriendUnit Get(this FriendUnitComponent self, long unitId)
        {
            self.FriendUnits.TryGetValue(unitId, out var friendUnit);
            return friendUnit;
        }
    }
}