namespace ET
{
    [FriendClass(typeof(RankInfo))]
    [FriendClass(typeof(RankInfosComponent))]
    public static class RankInfosComponentSystem
    {
        #region 生命周期

        public class RankInfosComponentDestroy : DestroySystem<RankInfosComponent>
        {
            public override void Destroy(RankInfosComponent self)
            {
                foreach (var rankInfo in self.RankInfosDictionary.Values)
                {
                    rankInfo?.Dispose();
                }
                self.RankInfosDictionary.Clear();
                self.SortedRankInfoList.Clear();
            }
        }

        #endregion 生命周期

        public static async ETTask LoadRankInfo(this RankInfosComponent self)
        {
            var rankInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<RankInfo>(d => true, collection: "RankInfosComponent");

            foreach (RankInfo rankInfo in rankInfoList)
            {
                self.AddChild(rankInfo);
                self.RankInfosDictionary.Add(rankInfo.UnitId, rankInfo);
                self.SortedRankInfoList.Add(rankInfo, rankInfo.UnitId);
            }
        }

        public static void AddOrUpdate(this RankInfosComponent self, RankInfo newRankInfo)
        {
            if (self.RankInfosDictionary.TryGetValue(newRankInfo.UnitId, out RankInfo oldRankInfo))
            {
                if (oldRankInfo.Level == newRankInfo.Level)
                {
                    return;
                }

                DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Remove<RankInfo>(oldRankInfo.UnitId, oldRankInfo.Id, "RankInfosComponent").Coroutine();
                self.RankInfosDictionary.Remove(oldRankInfo.UnitId);
                self.SortedRankInfoList.Remove(oldRankInfo);
                oldRankInfo?.Dispose();
            }

            self.AddChild(newRankInfo);
            self.RankInfosDictionary.Add(newRankInfo.UnitId, newRankInfo);
            self.SortedRankInfoList.Add(newRankInfo, newRankInfo.UnitId);
            DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newRankInfo.UnitId, newRankInfo, "RankInfosComponent").Coroutine();
        }
    }
}