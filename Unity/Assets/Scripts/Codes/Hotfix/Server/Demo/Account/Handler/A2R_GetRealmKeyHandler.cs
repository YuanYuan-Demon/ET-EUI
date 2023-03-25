namespace ET.Server
{
    [ActorMessageHandler(SceneType.Realm)]
    public class A2R_GetRealmKeyHandler: AMActorRpcHandler<Scene, A2R_GetRealmKey, R2A_GetRealmKey>
    {
        protected override async ETTask Run(Scene scene, A2R_GetRealmKey request, R2A_GetRealmKey response)
        {
            //发放登陆令牌
            string token = $"{TimeHelper.ServerNow()}{RandomHelper.RandInt64()}";
            //scene.GetComponent<TokenComponent>().Remove(request.AccountId);
            scene.GetComponent<TokenComponent>().AddOrModify(request.AccountId, token);
            response.RealmToken = token;
            await ETTask.CompletedTask;
        }
    }
}