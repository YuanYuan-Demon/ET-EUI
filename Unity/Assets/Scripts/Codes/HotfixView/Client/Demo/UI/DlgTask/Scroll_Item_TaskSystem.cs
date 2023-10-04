using ET.Client.EventType;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOfAttribute(typeof (TaskInfo))]
    [FriendOfAttribute(typeof (Scroll_Item_Task))]
    public static class Scroll_Item_TaskSystem
    {
        public static void Register(this Scroll_Item_Task self, UnityAction<bool> action = default) => self.ET_Task_Toggle.AddListener(isOn =>
        {
            action?.Invoke(isOn);
            if (isOn)
            {
                EventSystem.Instance.Publish(self.DomainScene(), new SelectTask() { TaskInfo = self.TaskInfo });
            }
        });

        public static void Init(this Scroll_Item_Task self, TaskInfo taskInfo, ToggleGroup group, UnityAction<bool> action = default)
        {
            self.DataId = taskInfo.ConfigId;
            self.TaskInfo = taskInfo;
            self.ET_TaskName_TextMeshProUGUI.text = taskInfo.Config.Name;
            self.Register(action);
            self.ET_Task_Toggle.group = group;
        }
    }
}