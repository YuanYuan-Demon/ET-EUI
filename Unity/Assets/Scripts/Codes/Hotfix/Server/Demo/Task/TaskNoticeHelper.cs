﻿namespace ET.Server
{
    [FriendOf(typeof (TasksComponent))]
    public static class TaskNoticeHelper
    {
        public static void SyncTaskInfo(Unit unit, TaskInfo taskInfo)
        {
            M2C_UpdateTaskInfo updateTaskInfo = new() { NTaskInfo = taskInfo.ToNTaskInfo() };
            MessageHelper.SendToClient(unit, updateTaskInfo);
        }

        public static void SyncAllTaskInfo(Unit unit)
        {
            var tc = unit.GetComponent<TasksComponent>();
            tc ??= unit.AddComponent<TasksComponent>();
            var m2CAllTaskInfoList = new M2C_AllTaskInfoList();

            foreach (var taskInfo in tc.TaskInfos.Values)
            {
                m2CAllTaskInfoList.NTaskInfos.Add(taskInfo.ToNTaskInfo());
            }

            MessageHelper.SendToClient(unit, m2CAllTaskInfoList);
        }
    }
}