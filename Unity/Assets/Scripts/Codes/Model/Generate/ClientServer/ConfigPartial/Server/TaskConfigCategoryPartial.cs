using System.Collections.Generic;

namespace ET
{
    public partial class TaskConfigCategory
    {
        /// <summary>
        ///     前置任务配置表
        /// </summary>
        public Dictionary<int, List<TaskConfig>> PreTasks = new();

        protected override void PostResolve()
        {
            foreach (var config in this._dataList)
            {
                if (!this.PreTasks.ContainsKey(config.PreTask))
                {
                    this.PreTasks.Add(config.PreTask, new());
                }

                this.PreTasks[config.PreTask].Add(config);
            }
        }

        /// <summary>
        ///     获取该任务的后续任务
        /// </summary>
        /// <param name="preTaskId"></param>
        /// <returns></returns>
        public List<TaskConfig> GetPostTasksByPreId(int preTaskId) => this.PreTasks.TryGetValue(preTaskId, out var configIdList)? configIdList : null;
    }
}