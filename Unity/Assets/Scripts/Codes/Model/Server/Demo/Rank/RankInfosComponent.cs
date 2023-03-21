using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class RankInfosComponent : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 排行榜列表
        /// Key: RankInfo
        /// Value: UnitId
        /// </summary>
        [BsonIgnore]
        public SortedList<RankInfo, long> SortedRankInfoList = new(new RankInfoCompare());

        /// <summary>
        /// 排行榜信息字典
        /// Key: UnitId
        /// Value: RankInfo
        /// </summary>
        [BsonIgnore]
        public Dictionary<long, RankInfo> RankInfosDictionary = new();
    }

    /// <summary>
    /// RankInfo比较器
    /// 按照等级降序排列，等级相同时按照UnitId降序排列
    /// </summary>
    [FriendOf(typeof(ET.RankInfo))]
    public class RankInfoCompare : IComparer<RankInfo>
    {
        public int Compare(RankInfo a, RankInfo b)
        {
            int result = b.Level - a.Level;
            if (result != 0) return result;

            if (a.Id > b.Id) return 1;
            else if (a.Id < b.Id) return -1;
            return 0;
        }
    }
}