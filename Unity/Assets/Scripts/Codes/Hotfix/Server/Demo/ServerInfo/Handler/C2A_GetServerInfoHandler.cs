namespace ET.Server
{
    [MessageHandler(SceneType.Account)]
    public class C2A_GetServerInfoHandler: AMRpcHandler<C2A_GetServerInfos, A2C_GetServerInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfos request, A2C_GetServerInfos response)
        {
            Scene scene = session.DomainScene();
            //服务器校验
            if (scene.SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误,当前Scene为:{scene.SceneType}");
                response.Error = ErrorCode.ERR_RequestSceneTypeError;
                session.Disconnect();
                return;
            }

            //令牌校验
            string token = scene.GetComponent<TokenComponent>().Get(request.AccountId);
            if (token is null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session?.Disconnect();
                return;
            }

            //加载服务器信息
            foreach (ServerInfo serverInfo in scene.GetComponent<ServerInfoManagerComponent>().ServerInfos)
            {
                response.NServerInfos.Add(serverInfo.ToNServerInfo());
            }

            await ETTask.CompletedTask;
        }
    }
}