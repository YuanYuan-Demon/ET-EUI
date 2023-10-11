using ET.Server;

namespace ET.Client
{
    [FriendOfAttribute(typeof (CFriendComponent))]
    public static class CFriendComponentSystem
    {
        public static void AddOrUpdateFriend(this CFriendComponent self, NFriend nFriend)
        {
            if (self.TryGetApply(nFriend.UnitId, out var friend))
            {
                friend.FromNFriend(nFriend);
                self.Friends[friend.Id] = friend;
                self.FriendApplys.Remove(nFriend.UnitId);
            }
            else
            {
                if (self.TryGetFriend(nFriend.UnitId, out friend))
                {
                    friend.FromNFriend(nFriend);
                }
                else
                {
                    friend = self.Create(nFriend);
                    self.Friends.Add(friend.Id, friend);
                }
            }
        }

        public static bool TryGetFriend(this CFriendComponent self, long unitId, out FriendInfo friend)
            => self.Friends.TryGetValue(unitId, out friend);

        public static FriendInfo GetFriend(this CFriendComponent self, long unitId)
        {
            self.Friends.TryGetValue(unitId, out var friend);
            return friend;
        }

        public static bool DeleteFriend(this CFriendComponent self, long unitId)
        {
            if (self.Friends.TryGetValue(unitId, out var friend))
            {
                friend.Destroy();
                self.Friends.Remove(unitId);
                return true;
            }

            return false;
        }

        public static FriendInfo Create(this CFriendComponent self, NFriend nFriend)
        {
            var friendUnit = self.AddChildWithId<FriendInfo>(nFriend.UnitId);
            friendUnit.FromNFriend(nFriend);
            return friendUnit;
        }

#region 处理好友申请

        public static void AddApply(this CFriendComponent self, NFriend nFriend)
        {
            var apply = self.Create(nFriend);
            self.FriendApplys.TryAdd(apply.Id, apply);
        }

        public static FriendInfo GetApply(this CFriendComponent self, long unitId)
        {
            self.FriendApplys.TryGetValue(unitId, out var apply);
            return apply;
        }

        public static bool TryGetApply(this CFriendComponent self, long unitId, out FriendInfo apply)
            => self.FriendApplys.TryGetValue(unitId, out apply);

        public static bool DeleteApply(this CFriendComponent self, long unitId)
        {
            if (self.FriendApplys.TryGetValue(unitId, out var apply))
            {
                apply.Destroy();
                self.Friends.Remove(unitId);
                return true;
            }

            return false;
        }

#endregion
    }
}