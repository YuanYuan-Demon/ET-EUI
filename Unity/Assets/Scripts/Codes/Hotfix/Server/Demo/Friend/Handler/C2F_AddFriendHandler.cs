namespace ET.Server
{
    [ActorMessageHandler(SceneType.Friend)]
    public class C2F_AddFriendHandler: AMActorRpcHandler<FriendUnit, C2F_AddFriend, F2C_AddFriend>
    {
        protected override async ETTask Run(FriendUnit unit, C2F_AddFriend request, F2C_AddFriend response)
        {
            if (request.UnitId != default)
            {
                response.Error = await unit.GetParent<FriendUnitComponent>().SendAddFriendRequest(unit.Id, request.UnitId);
                return;
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                response.Error = await unit.GetParent<FriendUnitComponent>().SendAddFriendRequest(unit.Id, request.Name);
                return;
            }

            response.Error = ErrorCode.ERR_Friend_Id_Name_IsNull;
            await ETTask.CompletedTask;
        }
    }
}