namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_AllTaskInfoListHandler: AMHandler<M2C_AllTaskInfoList>
    {
        protected override async ETTask Run(Session session, M2C_AllTaskInfoList message)
        {
            await ETTask.CompletedTask;
            var cTasksesComponent = session.ClientScene().GetComponent<CTasksComponent>();
            foreach (var taskInfoProto in message.NTaskInfos)
            {
                cTasksesComponent.AddOrUpdateTaskInfo(taskInfoProto);
            }
        }
    }
}