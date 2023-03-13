using System;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(DlgTask))]
    [FriendClassAttribute(typeof(ET.TaskInfo))]
    public static class DlgTaskSystem
    {
        public static void RegisterUIEvent(this DlgTask self)
        {
            self.RegisterCloseEvent<DlgTask>(self.View.EB_CloseButton);
            self.View.EL_TasksLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskItemLoopHandler);
        }

        public static void ShowWindow(this DlgTask self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void Refresh(this DlgTask self)
        {
            int count = self.ZoneScene().GetComponent<TasksComponent>().GetTaskInfoCount();
            self.AddUIScrollItems(ref self.ScrollItemTasks, count);
            self.View.EL_TasksLoopVerticalScrollRect.SetVisible(true, count);
        }

        /// <summary>
        /// 任务滚动列表项刷新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transform"></param>
        /// <param name="index"></param>
        public static void OnTaskItemLoopHandler(this DlgTask self, Transform transform, int index)
        {
            Scroll_Item_Task scrollItemTask = self.ScrollItemTasks[index].BindTrans(transform);
            TaskInfo taskInfo = self.ZoneScene().GetComponent<TasksComponent>().GetTaskInfoByIndex(index);

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskInfo.ConfigId);

            scrollItemTask.ET_TaskNameTextMeshProUGUI.SetText(taskConfig.TaskName);
            scrollItemTask.ET_TaskDescTextMeshProUGUI.SetText($"任务描述:\n<indent=2em><line-indent=2em>{taskConfig.TaskDesc}</line-indent></indent>");
            scrollItemTask.ET_TaskProcessTextMeshProUGUI.SetText($"任务进度: {taskInfo.TaskPogress} / {taskConfig.TaskTargetCount}");
            scrollItemTask.ET_TaskRewardTextMeshProUGUI.SetText($"任务奖励: {taskConfig.RewardGoldCount}");
            scrollItemTask.ET_LabelTextMeshProUGUI.SetText(taskInfo.IsTaskState(TaskState.Complete) ? "领取奖励" : "未完成");
            scrollItemTask.EB_SubmitButton.interactable = taskInfo.IsTaskState(TaskState.Complete);
            scrollItemTask.EB_SubmitButton.AddListenerAsyncWithId(self.OnClickSubmit, taskInfo.ConfigId);
        }

        /// <summary>
        /// 点击提交按钮响应
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskConfigId"></param>
        /// <returns></returns>
        public static async ETTask OnClickSubmit(this DlgTask self, int taskConfigId)
        {
            try
            {
                int errorCode = await TaskHelper.GetTaskReward(self.ZoneScene(), taskConfigId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.Refresh();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}