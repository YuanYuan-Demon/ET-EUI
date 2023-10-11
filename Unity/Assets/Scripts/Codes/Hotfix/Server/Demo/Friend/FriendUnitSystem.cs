namespace ET.Server
{
    [FriendOfAttribute(typeof (RoleInfo))]
    [FriendOfAttribute(typeof (FriendInfo))]
    [FriendOfAttribute(typeof (FriendUnit))]
    public static class FriendUnitSystem
    {
        public static async ETTask<FriendInfo> Create(this FriendUnit self, long unitId, bool isApply)
        {
            var friendInfo = self.AddChildWithId<FriendInfo>(unitId, true);
            var roleInfo = await UnitCacheHelper.GetUnitComponentCache<RoleInfo>(unitId);
            if (roleInfo is null)
                return null;

            friendInfo.FromRoleInfo(roleInfo);
            friendInfo.IsApply = isApply;
            return friendInfo;
        }

        public static void PostDispose(this FriendUnit self)
        {
            self.Name = null;
            self.GateSessionActorId = 0;

            foreach (var apply in self.Application.Values)
            {
                apply.Destroy();
            }

            foreach (var friend in self.Friends.Values)
            {
                friend.Destroy();
            }

            self.Friends.Clear();
            self.Application.Clear();
        }

        [FriendOfAttribute(typeof (FriendInfo))]

#region 生命周期

        public class FriendUnitDeserializeSystem: DeserializeSystem<FriendUnit>
        {
            protected override void Deserialize(FriendUnit self)
            {
                foreach (var apply in self.Application.Values)
                {
                    apply.IsApply = true;
                    self.AddChild(apply);
                }

                foreach (var friendInfo in self.Friends.Values)
                {
                    friendInfo.IsApply = false;
                    self.AddChild(friendInfo);
                }
            }
        }

        public class FriendUnitDestroySystem: DestroySystem<FriendUnit>
        {
            protected override void Destroy(FriendUnit self)
            {
                self.Save();
                self.PostDispose();
            }
        }

        private static void Save(this FriendUnit self)
        {
            var db = DBManagerComponent.Instance.GetZoneDB(self.DomainZone());
            db.Save(self);
        }

#endregion

#region 通知客户端

        public static void SyncFriendInfo(this FriendUnit self, FriendInfo friendInfo, FriendUpdateType type)
        {
            if (!self.Online)
                return;
            var message = new F2C_NoticeFriendInfo() { NFriend = friendInfo.ToNFriend(), Type = type };
            MessageHelper.SendActor(self.GateSessionActorId, message);
        }

        public static void SyncAllFriendInfo(this FriendUnit self)
        {
            if (!self.Online)
                return;

            var message = new F2C_AllNoticeFriendInfo();
            foreach (var friendInfo in self.Friends.Values)
            {
                message.NFriends.Add(friendInfo.ToNFriend());
            }

            foreach (var apply in self.Application.Values)
            {
                message.NApplys.Add(apply.ToNFriend());
            }

            MessageHelper.SendActor(self.GateSessionActorId, message);
        }

#endregion

#region 好友申请

        public static async ETTask<FriendInfo> AddApply(this FriendUnit self, long unitId, bool noticeClient = true)
        {
            var apply = await self.Create(unitId, true);
            self.Application.TryAdd(apply.Id, apply);
            if (noticeClient)
                self.SyncFriendInfo(apply, FriendUpdateType.AddApply);

            return apply;
        }

        public static void DeleteApply(this FriendUnit self, long unitId, bool noticeClient = true)
        {
            if (self.Application.TryGetValue(unitId, out var friendInfo))
            {
                friendInfo?.Destroy();
                self.Application.Remove(unitId);
            }
        }

#endregion

#region 好友管理

        public static async ETTask<FriendInfo> AddFriend(this FriendUnit self, long unitId, bool noticeClient = true)
        {
            if (self.Application.TryGetValue(unitId, out var friendInfo))
                self.Application.Remove(unitId);
            else
                friendInfo = await self.Create(unitId, false);
            friendInfo.IsApply = false;
            self.Friends.TryAdd(friendInfo.Id, friendInfo);

            if (noticeClient)
                self.SyncFriendInfo(friendInfo, FriendUpdateType.AddOrUpdateFriend);

            return friendInfo;
        }

        public static bool DeleteFriend(this FriendUnit self, long unitId, bool noticeClient = true)
        {
            if (self.Friends.TryGetValue(unitId, out var friendInfo))
            {
                friendInfo?.Destroy();
                self.Friends.Remove(unitId);
                if (noticeClient)
                    self.SyncFriendInfo(friendInfo, FriendUpdateType.DeleteFriend);
                return true;
            }

            return false;
        }

#endregion
    }
}