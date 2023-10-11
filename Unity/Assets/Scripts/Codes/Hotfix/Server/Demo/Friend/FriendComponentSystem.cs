using System;

namespace ET.Server
{
    [FriendOfAttribute(typeof (FriendUnitComponent))]
    [FriendOfAttribute(typeof (FriendUnit))]
    [FriendOfAttribute(typeof (DBComponent))]
    [FriendOfAttribute(typeof (RoleInfo))]
    public static class FriendComponentSystem
    {
        public static FriendUnit Create(this FriendUnitComponent self, long unitId, long actorId, string name)
        {
            var friendUnit = self.AddChildWithId<FriendUnit>(unitId, true);
            friendUnit.AddComponent<MailBoxComponent>();
            friendUnit.GateSessionActorId = actorId;
            friendUnit.Name = name;
            friendUnit.VisitTime = TimeHelper.ServerNow();
            self.Add(friendUnit);
            return friendUnit;
        }

        public static async ETTask<FriendUnit> Get(this FriendUnitComponent self, long unitId)
        {
            if (!self.FriendUnits.TryGetValue(unitId, out var target))
            {
                var res = await self.QueryDB<FriendUnit>(unit => unit.Id == unitId);
                if (res.Count > 0)
                {
                    target = res[0];
                    self.Add(target);
                    target.AddComponent<MailBoxComponent>();
                }
                else
                {
                    var roleInfo = await UnitCacheHelper.GetUnitComponentCache<RoleInfo>(unitId);
                    if (roleInfo is null) return null;
                    target = self.Create(unitId, 0, roleInfo.Name);
                }
            }

            return target;
        }

        public static async ETTask<FriendUnit> Get(this FriendUnitComponent self, string name)
        {
            if (self.NameToId.TryGetValue(name, out var unitId))
                return await self.Get(unitId);
            var roles = await self.QueryDB<RoleInfo>(role => role.Name == name);
            if (roles?.Count > 0)
                return await self.Get(roles[0].Id);
            return null;
        }

        public static void Add(this FriendUnitComponent self, FriendUnit friendUnit)
        {
            if (friendUnit.Parent != self)
                self.AddChild(friendUnit);

            self.FriendUnits[friendUnit.Id] = friendUnit;
            if (!string.IsNullOrEmpty(friendUnit.Name))
                self.NameToId[friendUnit.Name] = friendUnit.Id;
        }

        public static void Remove(this FriendUnitComponent self, long id)
        {
            if (self.FriendUnits.TryGetValue(id, out var chatInfoUnit))
            {
                self.FriendUnits.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }

        public static async ETTask<int> SendAddFriendRequest(this FriendUnitComponent self, long fromId, long toId)
        {
            // self.FriendUnits.TryGetValue(fromId, out var sender);
            var target = await self.Get(toId);
            if (target is null)
                return ErrorCode.ERR_Friend_Role_NoExist;

            var friendInfo = await target.AddApply(fromId);
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> SendAddFriendRequest(this FriendUnitComponent self, long fromId, string toName)
        {
            var target = await self.Get(toName);
            if (target is null)
                return ErrorCode.ERR_Friend_Role_NoExist;

            var friendInfo = await target.AddApply(fromId);
            return ErrorCode.ERR_Success;
        }

#region 生命周期

        public class FriendComponentAwakeSystem: AwakeSystem<FriendUnitComponent>
        {
            protected override void Awake(FriendUnitComponent self)
            {
                TimerComponent.Instance.NewRepeatedTimer(TimeHelper.Minute, TimerInvokeType.FriendUnitSave, self);
                TimerComponent.Instance.NewRepeatedTimer(TimeHelper.Minute * 10, TimerInvokeType.FriendUnitExit, self);
            }
        }

        public class FriendComponentDestroySystem: DestroySystem<FriendUnitComponent>
        {
            protected override void Destroy(FriendUnitComponent self) => self.FriendUnits.Clear();
        }

#endregion 生命周期

#region 定时任务

        [Invoke(TimerInvokeType.FriendUnitSave)]
        public class FriendUnitSaveTimer: ATimer<FriendUnitComponent>
        {
            protected override void Run(FriendUnitComponent self)
            {
                try
                {
                    if (self is null || self.IsDisposed)
                        return;
                    if (self.DomainScene() is null)
                        return;
                    self.SaveChangeAsync();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        [Invoke(TimerInvokeType.FriendUnitExit)]
        public class FriendUnitExitTimer: ATimer<FriendUnitComponent>
        {
            protected override void Run(FriendUnitComponent self)
            {
                try
                {
                    if (self is null || self.IsDisposed)
                        return;
                    if (self.DomainScene() is null)
                        return;
                    self.ClearInactiveUnit().Coroutine();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        private static void SaveChangeAsync(this FriendUnitComponent self)
        {
            var db = DBManagerComponent.Instance.GetZoneDB(self.DomainZone());
            foreach (var friendUnit in self.FriendUnits.Values)
            {
                db.SaveAsync(friendUnit).Coroutine();
            }
        }

        private static void SaveChange(this FriendUnitComponent self)
        {
            var db = DBManagerComponent.Instance.GetZoneDB(self.DomainZone());
            foreach (var friendUnit in self.FriendUnits.Values)
            {
                db.Save(friendUnit);
            }
        }

        private static async ETTask ClearInactiveUnit(this FriendUnitComponent self)
        {
            var time = TimeHelper.ServerNow();
            var db = DBManagerComponent.Instance.GetZoneDB(self.DomainZone());

            using (var clearUnits = ListComponent<FriendUnit>.Create())
            {
                foreach (var unit in self.FriendUnits.Values)
                {
                    if (unit.Online)
                        continue;

                    if (time - unit.VisitTime <= TimeHelper.Minute * 10)
                        continue;
                    await db.SaveAsync(unit);
                    clearUnits.Add(unit);
                    unit.Dispose();
                }

                foreach (var unit in clearUnits)
                {
                    self.FriendUnits.Remove(unit.Id);
                    unit.Dispose();
                }
            }
        }

#endregion 定时任务
    }
}