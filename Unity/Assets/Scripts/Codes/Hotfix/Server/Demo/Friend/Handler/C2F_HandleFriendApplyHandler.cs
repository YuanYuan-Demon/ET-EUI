namespace ET.Server
{
    [ActorMessageHandler(SceneType.Friend)]
    [FriendOfAttribute(typeof (FriendUnit))]
    public class C2F_HandleFriendApplyHandler: AMActorRpcHandler<FriendUnit, C2F_HandleFriendApply, F2C_HandleFriendApply>
    {
        protected override async ETTask Run(FriendUnit unit, C2F_HandleFriendApply request, F2C_HandleFriendApply response)
        {
            if (request.Accept)
            {
                var friend = await unit.GetParent<FriendUnitComponent>().Get(request.UnitId);
                unit.AddFriend(request.UnitId).Coroutine();
                friend.AddFriend(unit.Id).Coroutine();
            }
            else
            {
                unit.DeleteApply(request.UnitId);
            }

            await ETTask.CompletedTask;
        }
    }
}