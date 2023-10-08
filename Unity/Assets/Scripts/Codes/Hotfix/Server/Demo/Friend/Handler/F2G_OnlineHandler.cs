namespace ET.Server.Handler
{
    [ActorMessageHandler(SceneType.Gate)]
    public class F2G_OnlineHandler: AMActorRpcHandler<Scene, F2G_Online, G2F_Online>
    {
        protected override async ETTask Run(Scene scene, F2G_Online request, G2F_Online response)
        {
            response.Error = scene.GetComponent<PlayerComponent>().Contains(request.UnitId)? 0 : 1;
            await ETTask.CompletedTask;
        }
    }
}