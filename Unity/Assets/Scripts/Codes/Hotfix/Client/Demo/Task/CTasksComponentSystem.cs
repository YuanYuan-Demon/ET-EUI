using System.Collections.Generic;
using System.Linq;
using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof (CTasksComponent))]
    [FriendOf(typeof (TaskInfo))]
    public static class CTasksComponentSystem
    {
        public static void AddOrUpdateTaskInfo(this CTasksComponent self, NTaskInfo nTaskInfo)
        {
            var taskInfo = self.GetTaskInfoByConfigId(nTaskInfo.ConfigId);
            taskInfo ??= self.AddNewTask(nTaskInfo.ConfigId);

            taskInfo.FromNTaskInfo(nTaskInfo);

            EventSystem.Instance.Publish(self.ClientScene(), new UpdateTaskInfo());
        }

        public static TaskInfo AddNewTask(this CTasksComponent self, int configId)
        {
            var taskInfo = self.AddChild<TaskInfo, int>(configId);
            self.AllTasks.Add(configId, taskInfo);
            return taskInfo;
        }

        public static TaskInfo GetTaskInfoByConfigId(this CTasksComponent self, int configId)
        {
            self.AllTasks.TryGetValue(configId, out var taskInfo);
            return taskInfo;
        }

        public static List<TaskInfo> GetAllTaskInfos(this CTasksComponent self)
        {
            self.TaskInfoList = self.AllTasks.Values.Where(taskInfo => taskInfo.TaskState < TaskState.Finished).ToList();
            self.TaskInfoList.Sort((a, b) => b.TaskState - a.TaskState);
            return self.TaskInfoList;
        }

        public static List<TaskInfo> GetMainTasks(this CTasksComponent self)
        {
            self.TaskInfoList = self.AllTasks.Values
                    .Where(taskInfo => taskInfo.TaskState < TaskState.Finished && taskInfo.Config.Type == TaskType.Main).ToList();
            self.TaskInfoList.Sort((a, b) => b.TaskState - a.TaskState);
            return self.TaskInfoList;
        }

        public static List<TaskInfo> GetBranchTasks(this CTasksComponent self)
        {
            self.TaskInfoList = self.AllTasks.Values
                    .Where(taskInfo => taskInfo.TaskState < TaskState.Finished && taskInfo.Config.Type == TaskType.Branch).ToList();
            self.TaskInfoList.Sort((a, b) => b.TaskState - a.TaskState);
            return self.TaskInfoList;
        }

        public static TaskInfo GetTaskInfoByIndex(this CTasksComponent self, int index) => index < 0 || index >= self.TaskInfoList.Count
                ? null :
                self.TaskInfoList[index];

        public static bool IsExistTaskComplete(this CTasksComponent self) =>
                self.AllTasks.Values.Any(taskInfo => taskInfo.IsTaskState(TaskState.Completed));

#region 生命周期

        public class CTasksComponentDestroySystem: DestroySystem<CTasksComponent>
        {
            protected override void Destroy(CTasksComponent self)
            {
                foreach (var taskInfo in self.AllTasks.Values)
                {
                    taskInfo?.Dispose();
                }

                self.AllTasks.Clear();
                self.TaskInfoList = default;
            }
        }

#endregion 生命周期
    }
}