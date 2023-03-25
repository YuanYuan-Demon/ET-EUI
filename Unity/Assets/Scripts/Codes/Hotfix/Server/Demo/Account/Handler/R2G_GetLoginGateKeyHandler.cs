namespace ET.Server
{
    [ActorMessageHandler(SceneType.Gate)]
    public class R2G_GetLoginGateKeyHandler : AMActorRpcHandler<Scene, R2G_GetLoginGateKey, G2R_GetLoginGateKey>
    {
        protected override async ETTask Run(Scene scene, R2G_GetLoginGateKey request, G2R_GetLoginGateKey response)
        {
            #region 发放本Gate登陆令牌

            string key = RandomHelper.RandInt64().ToString() + TimeHelper.ServerNow().ToString();
            //scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
            scene.GetComponent<GateSessionKeyComponent>().Add(request.AccountId, key);
            response.GateSessionToken = key;

            #endregion 发放本Gate登陆令牌

            await ETTask.CompletedTask;
        }
    }
}