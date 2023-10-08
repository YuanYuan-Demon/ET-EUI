namespace ET.Server
{
    [FriendOfAttribute(typeof (RoleInfo))]
    [FriendOfAttribute(typeof (FriendInfo))]
    [FriendOfAttribute(typeof (FriendUnit))]
    public static class FriendUnitSystem
    {
#region 生命周期

        public class FriendUnitDestroySystem: DestroySystem<FriendUnit>
        {
            protected override void Destroy(FriendUnit self)
            {
                self.Name = null;
                self.GateSessionActorId = 0;
                foreach (var friend in self.Friends.Values)
                {
                    friend?.Dispose();
                }

                foreach (var apply in self.Application.Values)
                {
                    apply?.Dispose();
                }

                self.Friends.Clear();
                self.Application.Clear();
            }
        }

#endregion

        public static async ETTask<FriendInfo> AddApply(this FriendUnit self, long unitId)
        {
            var friendInfo = await self.Create(unitId);
            self.Application.TryAdd(friendInfo.Id, friendInfo);
            return friendInfo;
        }

        public static void RemoveApply(this FriendUnit self, long unitId)
        {
            if (self.Application.TryGetValue(unitId, out var friendInfo))
            {
                friendInfo?.Dispose();
                self.Application.Remove(unitId);
            }
        }

        public static async ETTask<FriendInfo> Create(this FriendUnit self, long unitId)
        {
            var friendInfo = self.AddChildWithId<FriendInfo>(unitId);
            var roleInfo = await UnitCacheHelper.GetUnitComponentCache<RoleInfo>(unitId);
            if (roleInfo is null)
                return null;

            friendInfo.Name = roleInfo.Name;
            friendInfo.RoleClass = roleInfo.RoleClass;
            friendInfo.Level = roleInfo.Level;
            friendInfo.LastLoginTime = roleInfo.LastLoginTime;
            friendInfo.Online = roleInfo.Online;
            // var response = await MessageHelper.CallActor(self.GateSessionActorId, new F2G_Online() { UnitId = unitId });
            // friendInfo.Online = response.Error == ErrorCode.ERR_Success;
            return friendInfo;
        }

        public static async ETTask<FriendInfo> AddFriend(this FriendUnit self, long unitId)
        {
            var friendInfo = await self.Create(unitId);
            self.Friends.TryAdd(friendInfo.Id, friendInfo);
            self.RemoveApply(unitId);
            MessageHelper.SendActor(self.GateSessionActorId, new F2C_NoticeAddFriend() { NFriend = friendInfo.ToNFriend() });

            return friendInfo;
        }

        public static bool DeleteFriend(this FriendUnit self, long unitId)
        {
            if (self.Friends.TryGetValue(unitId, out var friendInfo))
            {
                friendInfo?.Dispose();
                self.Friends.Remove(unitId);
                return true;
            }

            return false;
        }
    }
}