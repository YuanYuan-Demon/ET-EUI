namespace ET.Server
{
    [MessageHandler(SceneType.Account)]
    public class C2A_GetRealmKeyHandler: AMRpcHandler<C2A_GetRealmKey, A2C_GetRealmKey>
    {
        protected override async ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response)
        {
            Scene scene = session.DomainScene();

            #region 校验

            //重复请求校验
            if (session.GetComponent<SessionLoginComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect();
                return;
            }

            //令牌校验
            string token = scene.GetComponent<TokenComponent>().Get(request.AccountId);
            if (token is null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect();
                return;
            }

            #endregion 校验

            #region 获取RealmKey

            using (session.AddComponent<SessionLoginComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountId))
                {
                    StartSceneConfig realmStartSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);
                    var r2aResponse =
                            await MessageHelper.CallActor(realmStartSceneConfig.InstanceId,
                                new A2R_GetRealmKey() { AccountId = request.AccountId }) as R2A_GetRealmKey;
                    if (r2aResponse?.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = r2aResponse.Error;
                        session.Disconnect();
                        return;
                    }

                    response.RealmToken = r2aResponse.RealmToken;
                    response.RealmAddress = realmStartSceneConfig.OuterIPPort.ToString();
                    session.Disconnect();
                }
            }

            #endregion 获取RealmKey
        }
    }
}