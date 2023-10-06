using Unity.Mathematics;

namespace ET.Client.EventType
{
#region 装备系统

    public struct ChangeEquipItem
    {
        public EquipPosition EquipPosition;
    }

#endregion

#region 任务系统

    public struct SelectTask
    {
        public TaskInfo TaskInfo;
    }

    public struct UpdateTaskInfo
    {
    }

#endregion 任务系统

#region 聊天系统

    public struct UpdateChat
    {
    }

    public struct ClickChatLink
    {
        public float3 ClickPoint;
        public string LinkInfo;
    }

#endregion 聊天系统
}