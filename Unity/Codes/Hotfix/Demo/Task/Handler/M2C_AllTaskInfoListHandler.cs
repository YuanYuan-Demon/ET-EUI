namespace ET
{
    public class M2C_AllTaskInfoListHandler : AMHandler<M2C_AllTaskInfoList>
    {
        protected override void Run(Session session, M2C_AllTaskInfoList message)
        {
            TasksComponent tasksComponent = session.ZoneScene().GetComponent<TasksComponent>();
            foreach (var taskInfoProto in message.TaskInfoProtoList)
            {
                tasksComponent.AddOrUpdateTaskInfo(taskInfoProto);
            }
        }
    }
}