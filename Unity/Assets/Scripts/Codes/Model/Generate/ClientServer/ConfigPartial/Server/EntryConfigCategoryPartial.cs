using System.Collections.Generic;

namespace ET
{
    public partial class EntryConfigCategory
    {
        /// <summary>
        ///     AttributeType: EntryType
        ///     AttributeValue: AttributeType: EntryLevel, AttributeValue: EntryConfig
        /// </summary>
        private Dictionary<int, MultiMap<int, EntryConfig>> EntryConfigsDict = new();

        protected override void PostResolve()
        {
            base.PostResolve();
            foreach (EntryConfig config in this._dataMap.Values)
            {
                if (!this.EntryConfigsDict.TryGetValue(config.EntryType, out var map))
                {
                    map = new();
                    this.EntryConfigsDict.Add(config.EntryType, map);
                }

                map.Add(config.EntryLevel, config);
            }
        }

        /// <summary>
        ///     根据 词条类型和词条等级 随机生成词条
        /// </summary>
        /// <param name="entryType">词条类型: 普通/特殊词条</param>
        /// <param name="level">词条等级</param>
        /// <returns></returns>
        public EntryConfig GetRandomEntryConfigByLevel(int entryType, int level)
        {
            if (!this.EntryConfigsDict.ContainsKey(entryType))
            {
                return null;
            }

            var entryConfigsMap = this.EntryConfigsDict[entryType];
            if (!entryConfigsMap.ContainsKey(level))
            {
                return null;
            }

            var configList = entryConfigsMap[level];
            return configList[RandomHelper.RandomInt32(configList.Count)];
        }
    }
}