namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class G2M_RequestEnterGameStatusHandler : AMActorLocationRpcHandler<Unit, G2M_RequestEnterGameStatus, M2G_RequestEnterGameStatus>
    {
        protected override async ETTask Run(Unit unit, G2M_RequestEnterGameStatus request, M2G_RequestEnterGameStatus response)
        {
            await ETTask.CompletedTask;
        }
    }
}