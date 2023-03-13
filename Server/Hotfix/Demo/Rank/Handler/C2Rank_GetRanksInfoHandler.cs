using System;

namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfosComponent))]
    public class C2Rank_GetRanksInfoHandler : AMActorRpcHandler<Scene, C2Rank_GetRanksInfo, Rank2C_GetRanksInfo>
    {
        protected override async ETTask Run(Scene scene, C2Rank_GetRanksInfo request, Rank2C_GetRanksInfo response, Action reply)
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

            reply();
            await ETTask.CompletedTask;
        }
    }
}