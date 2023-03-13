using System.Collections.Generic;

namespace ET
{
    public partial class TaskConfigCategory
    {
        /// <summary>
        /// 前置任务配置表
        /// </summary>
        public Dictionary<int, List<int>> BeforeTaskConfigDictionary = new Dictionary<int, List<int>>();

        public override void AfterEndInit()
        {
            base.AfterEndInit();

            foreach (var config in this.list)
            {
                if (!this.BeforeTaskConfigDictionary.ContainsKey(config.TaskBeforeId))
                {
                    this.BeforeTaskConfigDictionary.Add(config.TaskBeforeId, new List<int>());
                }
                this.BeforeTaskConfigDictionary[config.TaskBeforeId].Add(config.Id);
            }
        }

        /// <summary>
        /// 获取该任务的后续任务
        /// </summary>
        /// <param name="beforeConfigId"></param>
        /// <returns></returns>
        public List<int> GetAfterTaskIdListByBeforeId(int beforeConfigId)
        {
            if (this.BeforeTaskConfigDictionary.TryGetValue(beforeConfigId, out List<int> configIdList))
            {
                return configIdList;
            }
            return null;
        }
    }
}