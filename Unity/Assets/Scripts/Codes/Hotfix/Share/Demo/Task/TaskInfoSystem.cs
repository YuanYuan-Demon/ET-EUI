using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET
{
    [FriendOf(typeof (TaskInfo))]
    public static class TaskInfoSystem
    {
        public static void FromNTaskInfo(this TaskInfo self, NTaskInfo nTaskInfo)
        {
            self.ConfigId = nTaskInfo.ConfigId;
            for (var i = 0; i < self.Process.Count; i++)
            {
                var local = self.Process[i];
                var net = nTaskInfo.Process[i];
                local.Count = net.Count;
            }

            self.TaskState = nTaskInfo.TaskState;
        }

        public static NTaskInfo ToNTaskInfo(this TaskInfo self)
        {
            var TaskInfoProto = new NTaskInfo() { ConfigId = self.Config.Id, Process = self.Process, TaskState = self.TaskState };
            return TaskInfoProto;
        }

        public static string GetTargetString(this TaskInfo self)
        {
            if (self.Config.Targets.Count == 0)
            {
                return self.Config.Overview;
            }

            StringBuilder sb = new();
            for (var i = 0; i < self.Process.Count; i++)
            {
                sb.AppendLine($"{self.Process[i].GetTargetName()}: {self.Process[i].Count}/{self.Config.Targets[i].Count}");
            }

            return sb.ToString();
        }

        public static string GetTargetName(this NTaskTarget target)
        {
            switch (target.Type)
            {
                case TaskTargetType.Kill:
                    return UnitConfigCategory.Instance.Get(target.Target).Name;
                case TaskTargetType.Item:
                    return ItemConfigCategory.Instance.Get(target.Target).Name;
                case TaskTargetType.Dialogue:
                    return UnitConfigCategory.Instance.Get(target.Target).Name;
                case TaskTargetType.UpLevel:
                    return "升级";
                case TaskTargetType.None:
                default:
                    return string.Empty;
            }
        }

        public static string GetTargetName(this TaskTarget target) => ((NTaskTarget)target).GetTargetName();

        public static void SetTaskState(this TaskInfo self, TaskState taskState) => self.TaskState = taskState;

        public static bool IsTaskState(this TaskInfo self, TaskState taskState) => self.TaskState == taskState;

        public static void UpdateProgress(this TaskInfo self, NTaskTarget process)
        {
            foreach (var p in self.Process.Where(p => p.Target == process.Target && p.Type == process.Type))
            {
                var processConfig = TaskActionConfigCategory.Instance.Get(p.Type);
                switch (processConfig.ProcessAction)
                {
                    case TaskProgressType.Add:
                        p.Count += process.Count;
                        break;

                    case TaskProgressType.Sub:
                        p.Count -= process.Count;
                        break;

                    case TaskProgressType.Update:
                        p.Count = process.Count;
                        break;
                }
            }
        }

        public static void UpdateProgress(this TaskInfo self, List<NTaskTarget> process)
        {
            for (var i = 0; i < self.Process.Count; i++)
            {
                var p = self.Process[i];
                var processConfig = TaskActionConfigCategory.Instance.Get(p.Type);
                switch (processConfig.ProcessAction)
                {
                    case TaskProgressType.Add:
                        p.Count += process[i].Count;
                        break;

                    case TaskProgressType.Sub:
                        p.Count -= process[i].Count;
                        break;

                    case TaskProgressType.Update:
                        p.Count = process[i].Count;
                        break;
                }
            }
        }

        /// <summary>
        ///     是否可以被完成
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static void TryCompleteTask(this TaskInfo self)
        {
            if (!self.IsComplete() || !self.IsTaskState(TaskState.InProgress))
            {
                return;
            }

            self.TaskState = TaskState.Completed;
        }

        /// <summary>
        ///     是否达到任务目标数量
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsComplete(this TaskInfo self)
        {
            for (var i = 0; i < self.Process.Count; i++)
            {
                var process = self.Process[i];
                var target = self.Config.Targets;
                if (process.Count < target.Count)
                {
                    return false;
                }
            }

            return true;
        }

#region 生命周期

        public class TaskInfoAwakeSystem: AwakeSystem<TaskInfo, int>
        {
            protected override void Awake(TaskInfo self, int configId)
            {
                self.ConfigId = configId;
                self.Process = new(self.Config.Targets.Count);
                foreach (var target in self.Config.Targets)
                {
                    var process = target.ToNTaskTarget();
                    process.Count = 0;
                    self.Process.Add(process);
                }

                self.TaskState = TaskState.None;
            }
        }

        public class TaskInfoDestroySystem: DestroySystem<TaskInfo>
        {
            protected override void Destroy(TaskInfo self)
            {
                self.ConfigId = default;
                self.Process.Clear();
                self.TaskState = TaskState.None;
            }
        }

#endregion 生命周期
    }
}