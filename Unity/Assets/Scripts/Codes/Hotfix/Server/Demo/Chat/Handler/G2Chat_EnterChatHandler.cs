namespace ET.Server
{
    [FriendOf(typeof (ChatInfoUnit))]
    [ActorMessageHandler(SceneType.Chat)]
    public class G2Chat_EnterChatHandler: AMActorRpcHandler<Scene, G2Chat_EnterChat, Chat2G_EnterChat>
    {
        protected override async ETTask Run(Scene scene, G2Chat_EnterChat request, Chat2G_EnterChat response)
        {
            var chatInfoUnitsComponent = scene.GetComponent<ChatInfoUnitsComponent>();

            var unitChatInfo = chatInfoUnitsComponent.Get(request.UnitId);

            //若已存在重新赋值
            if (unitChatInfo is { IsDisposed: false })
            {
                unitChatInfo.Name = request.Name;
                unitChatInfo.GateSessionActorId = request.GateSessionActorId;
                response.ChatInfoUnitInstanceId = unitChatInfo.InstanceId;
                return;
            }

            //新建ChatInfo映射
            unitChatInfo = chatInfoUnitsComponent.Create(request.UnitId, request.Name, request.GateSessionActorId);
            response.ChatInfoUnitInstanceId = unitChatInfo.InstanceId;

            await ETTask.CompletedTask;
        }
    }
}