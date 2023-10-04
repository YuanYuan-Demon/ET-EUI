namespace ET.Client.EventType
{
#region 装备系统

    public struct EquipItem
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
}