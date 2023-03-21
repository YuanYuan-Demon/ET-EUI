namespace ET
{
    [FriendOf(typeof(ET.TaskInfo))]
    public static class TaskInfoSystem
    {
        #region 生命周期

        public class TaskInfoAwakeSystem : AwakeSystem<TaskInfo, int>
        {
            protected override void Awake(TaskInfo self, int configId)
            {
                self.ConfigId = configId;
                self.TaskPogress = 0;
                self.TaskState = TaskState.Doing;
            }
        }

        public class TaskInfoDestroySystem : DestroySystem<TaskInfo>
        {
            protected override void Destroy(TaskInfo self)
            {
                self.ConfigId = 0;
                self.TaskPogress = 0;
                self.TaskState = TaskState.None;
            }
        }

        #endregion 生命周期

        public static void FromMessage(this TaskInfo self, TaskInfoProto taskInfoProto)
        {
            self.ConfigId = taskInfoProto.ConfigId;
            self.TaskPogress = taskInfoProto.TaskPogress;
            self.TaskState = (TaskState)taskInfoProto.TaskState;
        }

        public static TaskInfoProto ToMessage(this TaskInfo self)
        {
            TaskInfoProto TaskInfoProto = new TaskInfoProto()
            {
                ConfigId = self.ConfigId,
                TaskPogress = self.TaskPogress,
                TaskState = (int)self.TaskState
            };
            return TaskInfoProto;
        }

        public static void SetTaskState(this TaskInfo self, TaskState taskState)
        {
            self.TaskState = taskState;
        }

        public static bool IsTaskState(this TaskInfo self, TaskState taskState)
        {
            return self.TaskState == taskState;
        }

        public static void UpdateProgress(this TaskInfo self, int count)
        {
            var taskActionType = TaskConfigCategory.Instance.Get(self.ConfigId).TaskActionType;
            var config = TaskActionConfigCategory.Instance.Get(taskActionType);
            switch (config.TaskProgressType)
            {
                case (int)TaskProgressType.Add:
                    self.TaskPogress += count;
                    break;

                case (int)TaskProgressType.Sub:
                    self.TaskPogress -= count;
                    break;

                case (int)TaskProgressType.Update:
                    self.TaskPogress = count;
                    break;
            }
        }

        /// <summary>
        /// 是否可以被完成
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static void TryCompleteTask(this TaskInfo self)
        {
            if (!self.IsCompleteProgress() || !self.IsTaskState(TaskState.Doing))
            {
                return;
            }

            self.TaskState = TaskState.Complete;
        }

        /// <summary>
        /// 是否达到任务目标数量
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsCompleteProgress(this TaskInfo self)
        {
            return self.TaskPogress >= TaskConfigCategory.Instance.Get(self.ConfigId).TaskTargetCount;
        }
    }
}