using System.Net;

namespace ET.Server
{
    [HttpHandler(SceneType.RouterManager, "/get_router")]
    public class HttpGetRouterHandler: IHttpHandler
    {
        public async ETTask Handle(Entity domain, HttpListenerContext context)
        {
            HttpGetRouterResponse response = new();
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Realms.Values)
            {
                response.Realms.Add(startSceneConfig.InnerIPOutPort.ToString());
            }

            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Routers)
            {
                response.Routers.Add($"{startSceneConfig.StartProcessConfig.OuterIP}:{startSceneConfig.OuterPort}");
            }

            HttpHelper.Response(context, response);
            await ETTask.CompletedTask;
        }
    }
}