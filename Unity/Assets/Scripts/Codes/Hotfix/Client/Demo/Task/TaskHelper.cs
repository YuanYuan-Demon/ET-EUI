using System;

namespace ET.Client
{
    public static class TaskHelper
    {
        /// <summary>
        /// 获取任务奖励
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="taskConfigId"></param>
        /// <returns></returns>
        public static async ETTask<int> GetTaskReward(Scene ZoneScene, int taskConfigId)
        {
            TaskInfo taskInfo = ZoneScene.GetComponent<TaskComponent>().GetTaskInfoByConfigId(taskConfigId);

            if (taskInfo == null || taskInfo.IsDisposed)
            {
                return ErrorCode.ERR_NoTaskInfoExist;
            }

            if (!taskInfo.IsTaskState(TaskState.Complete))
            {
                return ErrorCode.ERR_TaskNoCompleted;
            }

            M2C_ReceiveTaskReward m2CReciveTaskReward;
            try
            {
                m2CReciveTaskReward = await ZoneScene.Call(new C2M_ReceiveTaskReward()
                {
                    TaskConfigId = taskConfigId
                }) as M2C_ReceiveTaskReward;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return m2CReciveTaskReward.Error;
        }
    }
}