using ET.Server;

namespace ET.Client
{
    [FriendOfAttribute(typeof (CFriendComponent))]
    public static class CFriendComponentSystem
    {
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

        public static bool RemoveApply(this CFriendComponent self, long unitId)
        {
            if (self.FriendApplys.TryGetValue(unitId, out var apply))
            {
                apply.Dispose();
                self.Friends.Remove(unitId);
                return true;
            }

            return false;
        }

        public static bool RemoveApplyNoDispose(this CFriendComponent self, long unitId)
        {
            if (self.FriendApplys.ContainsKey(unitId))
            {
                self.Friends.Remove(unitId);
                return true;
            }

            return false;
        }

#endregion

        public static void AddFriend(this CFriendComponent self, NFriend nFriend)
        {
            if (self.TryGetApply(nFriend.UnitId, out var friend))
            {
                self.Friends.Add(friend.Id, friend);
                self.RemoveApplyNoDispose(nFriend.UnitId);
            }
            else
            {
                friend = self.Create(nFriend);
                self.Friends.TryAdd(friend.Id, friend);
            }
        }

        public static FriendInfo GetFriend(this CFriendComponent self, long unitId)
        {
            self.Friends.TryGetValue(unitId, out var friend);
            return friend;
        }

        public static bool RemoveFriend(this CFriendComponent self, long unitId)
        {
            if (self.FriendApplys.TryGetValue(unitId, out var friend))
            {
                friend.Dispose();
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
    }
}