namespace ET.Server
{
    [FriendOf(typeof(RankInfo))]
    [FriendOf(typeof(RoleInfo))]
    public static class RankHelper
    {
        public static void AddOrUpdateLevelRank(Unit unit)
        {
            RankInfo rankInfo = unit.DomainScene().AddChild<RankInfo>();
            rankInfo.UnitId = unit.Id;
            rankInfo.Name = unit.GetComponent<RoleInfo>().Name;
            rankInfo.Level = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Level);

            Map2Rank_AddOrUpdateRankInfo request = new() { RankInfo = rankInfo };
            long instanceId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Rank").InstanceId;
            MessageHelper.SendActor(instanceId, request);
        }
    }
}