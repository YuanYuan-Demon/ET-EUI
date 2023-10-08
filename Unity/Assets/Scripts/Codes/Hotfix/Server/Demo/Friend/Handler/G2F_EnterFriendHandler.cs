namespace ET.Server
{
    [ActorMessageHandler(SceneType.Friend)]
    [FriendOfAttribute(typeof (FriendUnit))]
    public class G2F_EnterFriendHandler: AMActorRpcHandler<Scene, G2F_EnterFriend, F2G_EnterFriend>
    {
        protected override async ETTask Run(Scene scene, G2F_EnterFriend request, F2G_EnterFriend response)
        {
            var fuc = scene.GetComponent<FriendUnitComponent>();

            var friendUnit = fuc.Get(request.UnitId);

            //若已存在重新赋值
            if (friendUnit is { IsDisposed: false })
            {
                friendUnit.Name = request.Name;
                friendUnit.GateSessionActorId = request.GateSessionActorId;
                response.FriendUnitInstanceId = friendUnit.InstanceId;
                return;
            }

            //新建ChatInfo映射
            friendUnit = fuc.Create(request.UnitId, request.GateSessionActorId, request.Name);
            response.FriendUnitInstanceId = friendUnit.InstanceId;

            await ETTask.CompletedTask;
        }
    }
}