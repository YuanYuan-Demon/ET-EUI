namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_UpdateTaskInfoHandler: AMHandler<M2C_UpdateTaskInfo>
    {
        protected override async ETTask Run(Session session, M2C_UpdateTaskInfo message)
        {
            await ETTask.CompletedTask;
            session.ClientScene().GetComponent<CTasksComponent>().AddOrUpdateTaskInfo(message.NTaskInfo);
        }
    }
}