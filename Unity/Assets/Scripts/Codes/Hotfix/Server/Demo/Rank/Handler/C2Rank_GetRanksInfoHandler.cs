namespace ET.Server
{
    [FriendOf(typeof(ET.RankInfosComponent))]
    [ActorMessageHandler(SceneType.Rank)]
    public class C2Rank_GetRanksInfoHandler : AMActorRpcHandler<Scene, C2Rank_GetRanksInfo, Rank2C_GetRanksInfo>
    {
        protected override async ETTask Run(Scene scene, C2Rank_GetRanksInfo request, Rank2C_GetRanksInfo response)
        {
            RankInfosComponent rankInfosComponent = scene.GetComponent<RankInfosComponent>();
            //获取排行榜前100名数据
            int count = 0;
            foreach ((RankInfo rankInfo, _) in rankInfosComponent.SortedRankInfoList)
            {
                response.RankInfoProtoList.Add(rankInfo.ToMessage());
                ++count;
                if (count >= 100)
                {
                    break;
                }
            }
            await ETTask.CompletedTask;
        }
    }
}