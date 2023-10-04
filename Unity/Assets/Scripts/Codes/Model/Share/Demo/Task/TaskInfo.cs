using System.Collections.Generic;

namespace ET
{
    public enum TaskState
    {
        None,       //未接取
        InProgress, //已接取,未完成
        Completed,  //已完成,未提交
        Finished,   //已完成,已提交
        Failed,     //放弃,或任务失败
    }

    [ChildOf]
    public class TaskInfo: Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        private TaskConfig config;

        public int ConfigId;

        public List<NTaskTarget> Process;
        public TaskState TaskState;
        public TaskConfig Config => this.config ??= TaskConfigCategory.Instance.Get(this.ConfigId);
    }
}