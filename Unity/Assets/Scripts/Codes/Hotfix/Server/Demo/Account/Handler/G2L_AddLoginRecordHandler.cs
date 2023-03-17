namespace ET.Server
{
    [ActorMessageHandler(SceneType.LoginCenter)]
    public class G2L_AddLoginRecordHandler : AMActorRpcHandler<Scene, G2L_AddLoginRecord, L2G_AddLoginRecord>
    {
        protected override async ETTask Run(Scene scene, G2L_AddLoginRecord request, L2G_AddLoginRecord response)
        {
            //服务器类型校验
            if (scene.SceneType != SceneType.LoginCenter)
            {
                Log.Error($"请求的Scene错误,当前Scene为:{scene.SceneType}");
                response.Error = ErrorCode.ERR_RequestSceneTypeError;
                return;
            }
            long accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountId))
            {
                scene.GetComponent<LoginInfoRecordComponent>().Add(accountId, request.ServerId);
            }
        }
    }
}