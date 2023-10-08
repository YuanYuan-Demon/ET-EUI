using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof (TasksComponent))]
    [FriendOf(typeof (TaskInfo))]
    [FriendOfAttribute(typeof (RoleInfo))]
    public static class TasksComponentSystem
    {
#region 生命周期

        public class TasksComponentAwakeSystem: AwakeSystem<TasksComponent>
        {
            protected override void Awake(TasksComponent self) => self.Init();
        }

        public class TasksComponentDestroySystem: DestroySystem<TasksComponent>
        {
            protected override void Destroy(TasksComponent self)
            {
                foreach (var taskInfo in self.TaskInfos.Values)
                {
                    taskInfo?.Dispose();
                }

                self.TaskInfos.Clear();
                self.CurrentTaskSet.Clear();
            }
        }

        [FriendOf(typeof (TaskInfo))]
        public class TasksComponentDeserializeSystem: DeserializeSystem<TasksComponent>
        {
            protected override void Deserialize(TasksComponent self)
            {
                foreach (var taskInfo in self.Children.Values.Select(entity => entity as TaskInfo))
                {
                    self.TaskInfos.Add(taskInfo.Config.Id, taskInfo);

                    if (taskInfo.TaskState < TaskState.Finished)
                        self.CurrentTaskSet.Add(taskInfo.Config.Id, taskInfo.Config);
                }
            }
        }

#endregion 生命周期

#region 任务管理

        /// <summary>
        ///     初始化任务列表
        /// </summary>
        /// <param name="self"></param>
        private static void Init(this TasksComponent self)
        {
            if (self.TaskInfos.Count == 0)
                self.UpdateAfterTaskInfo(0, false);
        }

        /// <summary>
        ///     更新(接取)后续任务信息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="preTaskId"></param>
        /// <param name="isNoticeClient"></param>
        private static void UpdateAfterTaskInfo(this TasksComponent self, int preTaskId, bool isNoticeClient = true)
        {
            self.CurrentTaskSet.Remove(preTaskId);
            var roleClass = self.GetParent<Unit>().GetComponent<RoleInfo>().RoleClass;
            var tasks = TaskConfigCategory.Instance.GetPostTasksByPreId(preTaskId)
                    .Where(config => config.LimitClass == roleClass || config.LimitClass == RoleClass.None);

            foreach (var task in tasks)
            {
                self.CurrentTaskSet.Add(task.Id, task);
                self.AddTaskInfo(task, isNoticeClient);
            }
        }

        /// <summary>
        ///     增加任务信息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="task"></param>
        /// <param name="process"></param>
        /// <param name="isNoticeClient"></param>
        public static void AddTaskInfo(this TasksComponent self, TaskConfig task, bool isNoticeClient = true)
        {
            if (!self.TaskInfos.TryGetValue(task.Id, out var taskInfo))
                taskInfo = self.AddNewTask(task);

            if (isNoticeClient)
                TaskNoticeHelper.SyncTaskInfo(self.GetParent<Unit>(), taskInfo);
        }

        /// <summary>
        ///     新建任务数据
        /// </summary>
        /// <param name="self"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        public static TaskInfo AddNewTask(this TasksComponent self, TaskConfig task)
        {
            var taskInfo = self.AddChild<TaskInfo, int>(task.Id);
            self.TaskInfos.Add(task.Id, taskInfo);
            foreach (var process in taskInfo.Process)
            {
                if (process.Type == TaskTargetType.UpLevel)
                    process.Count = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.Level);
            }

            return taskInfo;
        }

#endregion

#region 任务进度更新

        /// <summary>
        ///     触发任务行为,更新任务进度
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskTargetType"></param>
        /// <param name="count"></param>
        /// <param name="targetId"></param>
        public static void TriggerTaskAction(this TasksComponent self, TaskTargetType taskTargetType, int count, int targetId = 0)
        {
            foreach (var configId in self.CurrentTaskSet.Keys)
            {
                if (!self.TaskInfos.TryGetValue(configId, out var taskInfo))
                    continue;

                foreach (var process in taskInfo.Process)
                {
                    if (process.Type == taskTargetType && process.Target == targetId)
                        self.UpdateTaskInfo(taskInfo, process, count);
                }
            }
        }

        /// <summary>
        ///     更新任务信息,下发任务更新消息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskInfo"></param>
        /// <param name="process"></param>
        /// <param name="count"></param>
        /// <param name="isNoticeClient"></param>
        private static void UpdateTaskInfo(this TasksComponent self, TaskInfo taskInfo, NTaskTarget process, int count, bool isNoticeClient = true)
        {
            UpdateProcess(process, count);
            taskInfo.TryCompleteTask();
            if (isNoticeClient)
                TaskNoticeHelper.SyncTaskInfo(self.GetParent<Unit>(), taskInfo);
        }

        /// <summary>
        ///     更新任务进度
        /// </summary>
        /// <param name="process"></param>
        /// <param name="count"></param>
        private static void UpdateProcess(NTaskTarget process, int count)
        {
            var actionConfig = TaskActionConfigCategory.Instance.Get(process.Type);

            switch (actionConfig.ProcessAction)
            {
                case TaskProgressType.Add:
                    process.Count += count;
                    break;

                case TaskProgressType.Sub:
                    process.Count -= count;
                    break;

                case TaskProgressType.Update:
                    process.Count = count;
                    break;
            }
        }

        /// <summary>
        ///     提交任务, 结算任务奖励
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unit"></param>
        /// <param name="taskId"></param>
        public static void SubmitTask(this TasksComponent self, Unit unit, int taskId)
        {
            if (!self.TaskInfos.TryGetValue(taskId, out var taskInfo))
            {
                Log.Error($"任务不存在: {taskId}");
                return;
            }

            taskInfo.SetTaskState(TaskState.Finished);
            TaskNoticeHelper.SyncTaskInfo(unit, taskInfo);
            self.UpdateAfterTaskInfo(taskId);
        }

        /// <summary>
        ///     校验是否可以提交任务
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskConfigId"></param>
        /// <returns></returns>
        public static int CanSubmitTask(this TasksComponent self, int taskConfigId)
        {
            if (!TaskConfigCategory.Instance.Contain(taskConfigId))
                return ErrorCode.ERR_NoTaskExist;

            self.TaskInfos.TryGetValue(taskConfigId, out var taskInfo);

            if (taskInfo == null || taskInfo.IsDisposed)
                return ErrorCode.ERR_NoTaskInfoExist;

            if (!self.IsPreTaskFinished(taskConfigId))
                return ErrorCode.ERR_BeforeTaskNoOver;

            if (taskInfo.IsTaskState(TaskState.Finished))
                return ErrorCode.ERR_TaskFinished;

            if (!taskInfo.IsTaskState(TaskState.Completed))
                return ErrorCode.ERR_TaskNoCompleted;

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        ///     前置任务是否完成
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskConfigId"></param>
        /// <returns></returns>
        public static bool IsPreTaskFinished(this TasksComponent self, int taskConfigId)
        {
            var config = TaskConfigCategory.Instance.Get(taskConfigId);

            if (config.PreTask == 0)
                return true;

            if (!self.TaskInfos.TryGetValue(config.PreTask, out var beforeTaskInfo))
                return false;

            return beforeTaskInfo.IsTaskState(TaskState.Finished);
        }

#endregion
    }
}