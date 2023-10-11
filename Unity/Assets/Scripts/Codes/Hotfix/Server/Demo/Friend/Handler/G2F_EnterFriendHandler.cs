namespace ET.Server
{
    [ActorMessageHandler(SceneType.Friend)]
    [FriendOfAttribute(typeof (FriendUnit))]
    public class G2F_EnterFriendHandler: AMActorRpcHandler<Scene, G2F_EnterFriend, F2G_EnterFriend>
    {
        protected override async ETTask Run(Scene scene, G2F_EnterFriend request, F2G_EnterFriend response)
        {
            var fuc = scene.GetComponent<FriendUnitComponent>();

            var friendUnit = await fuc.Get(request.UnitId);

            if (friendUnit?.IsDisposed == false)
            {
                //若已存在重新赋值
                friendUnit.Name = request.Name;
                friendUnit.GateSessionActorId = request.GateSessionActorId;
                response.FriendUnitInstanceId = friendUnit.InstanceId;
                fuc.Add(friendUnit);
            }
            else
            {
                //新建FriendUnit映射
                friendUnit = fuc.Create(request.UnitId, request.GateSessionActorId, request.Name);
                response.FriendUnitInstanceId = friendUnit.InstanceId;
            }

            friendUnit.Online = true;
            friendUnit.SyncAllFriendInfo();

            await ETTask.CompletedTask;
        }
    }
}