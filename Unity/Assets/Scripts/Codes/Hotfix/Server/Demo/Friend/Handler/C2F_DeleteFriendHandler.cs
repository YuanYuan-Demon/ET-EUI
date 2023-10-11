namespace ET.Server
{
    [ActorMessageHandler(SceneType.Friend)]
    public class C2F_DeleteFriendHandler: AMActorRpcHandler<FriendUnit, C2F_DeleteFriend, F2C_DeleteFriend>
    {
        protected override async ETTask Run(FriendUnit unit, C2F_DeleteFriend request, F2C_DeleteFriend response)
        {
            var friend = await unit.GetParent<FriendUnitComponent>().Get(request.UnitId);
            unit.DeleteFriend(request.UnitId);
            friend.DeleteFriend(unit.Id);
            await ETTask.CompletedTask;
        }
    }
}