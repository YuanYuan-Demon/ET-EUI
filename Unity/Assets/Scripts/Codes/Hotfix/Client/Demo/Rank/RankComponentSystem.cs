﻿namespace ET.Client
{
    [FriendOf(typeof(RankComponent))]
    public static class RankComponentSystem
    {
        public static void ClearAll(this RankComponent self)
        {
            for (int i = 0; i < self.RankInfos.Count; i++)
            {
                self.RankInfos[i]?.Dispose();
            }
            self.RankInfos.Clear();
        }

        public static void Add(this RankComponent self, RankInfoProto rankInfoProto)
        {
            RankInfo rankInfo = self.AddChild<RankInfo>(true);
            rankInfo.FromMessage(rankInfoProto);
            self.RankInfos.Add(rankInfo);
        }

        /// <summary>
        /// 获取排行榜项目数
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetRankCount(this RankComponent self)
        {
            return self.RankInfos.Count;
        }

        public static RankInfo GetRankInfoByIndex(this RankComponent self, int index)
        {
            if (index < 0 || index >= self.RankInfos.Count)
            {
                return null;
            }
            return self.RankInfos[index];
        }
    }
}