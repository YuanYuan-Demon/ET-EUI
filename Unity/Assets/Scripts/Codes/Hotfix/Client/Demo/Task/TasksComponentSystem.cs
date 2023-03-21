using System.Linq;
using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof(TaskComponent))]
    [FriendOf(typeof(TaskInfo))]
    public static class TasksComponentSystem
    {
        #region 生命周期

        public class TasksComponentDestroySystem : DestroySystem<TaskComponent>
        {
            protected override void Destroy(TaskComponent self)
            {
                foreach (TaskInfo taskInfo in self.TaskInfoDict.Values)
                {
                    taskInfo?.Dispose();
                }
                self.TaskInfoDict.Clear();
            }
        }

        #endregion 生命周期

        public static void AddOrUpdateTaskInfo(this TaskComponent self, TaskInfoProto taskInfoProto)
        {
            TaskInfo taskInfo = self.GetTaskInfoByConfigId(taskInfoProto.ConfigId);
            if (taskInfo == null)
            {
                taskInfo = self.AddChild<TaskInfo>();
                self.TaskInfoDict.Add(taskInfoProto.ConfigId, taskInfo);
            }
            taskInfo.FromMessage(taskInfoProto);

            EventSystem.Instance.Publish(self.ClientScene(), new UpdateTaskInfo());
        }

        public static TaskInfo GetTaskInfoByConfigId(this TaskComponent self, int configId)
        {
            self.TaskInfoDict.TryGetValue(configId, out TaskInfo taskInfo);
            return taskInfo;
        }

        public static int GetTaskInfoCount(this TaskComponent self)
        {
            self.TaskInfoList.Clear();
            self.TaskInfoList = self.TaskInfoDict.Values.Where(taskInfo => !taskInfo.IsTaskState(TaskState.Received)).ToList();
            self.TaskInfoList.Sort((a, b) => b.TaskState - a.TaskState);
            return self.TaskInfoList.Count;
        }

        public static TaskInfo GetTaskInfoByIndex(this TaskComponent self, int index)
        {
            return index < 0 || index >= self.TaskInfoList.Count
                ? null :
                self.TaskInfoList[index];
        }

        public static bool IsExistTaskComplete(this TaskComponent self)
        {
            return self.TaskInfoDict.Values.Any(taskInfo => taskInfo.IsTaskState(TaskState.Complete));

            ///foreach (var taskInfo in self.TaskInfoDict.Values)
            ///{
            ///    if (taskInfo.IsTaskState(TaskState.Complete))
            ///    {
            ///        return true;
            ///    }
            ///}
            ///return false;
        }
    }
}