namespace ET.Server
{
    [ActorMessageHandler(SceneType.LoginCenter)]
    public class G2L_RemoveLoginRecordHandler : AMActorRpcHandler<Scene, G2L_RemoveLoginRecord, L2G_RemoveLoginRecord>
    {
        protected override async ETTask Run(Scene scene, G2L_RemoveLoginRecord request, L2G_RemoveLoginRecord response)
        {
            long accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountId))
            {
                var loginInfoRecordComponent = scene.GetComponent<LoginInfoRecordComponent>();
                int zone = loginInfoRecordComponent.Get(accountId);
                if (request.ServerId == zone)
                {
                    loginInfoRecordComponent.Remove(accountId);
                }
            }
        }
    }
}