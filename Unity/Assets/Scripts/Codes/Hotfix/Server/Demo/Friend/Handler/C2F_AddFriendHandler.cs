namespace ET.Server.Handler
{
    [ActorMessageHandler(SceneType.Friend)]
    public class C2F_AddFriendHandler: AMActorRpcHandler<FriendUnit, C2F_AddFriend, F2C_AddFriend>
    {
        protected override async ETTask Run(FriendUnit unit, C2F_AddFriend request, F2C_AddFriend response)
        {
            await unit.GetParent<FriendUnitComponent>().SendAddFriendRequest(unit.Id, request.UnitId);
            await ETTask.CompletedTask;
        }
    }
}