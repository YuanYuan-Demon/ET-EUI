namespace ET.Server
{
    [FriendOf(typeof(ChatInfoUnit))]
    [ActorMessageHandler(SceneType.Chat)]
    public class G2Chat_EnterChatHandler : AMActorRpcHandler<Scene, G2Chat_EnterChat, Chat2G_EnterChat>
    {
        protected override async ETTask Run(Scene scene, G2Chat_EnterChat request, Chat2G_EnterChat response)
        {
            ChatInfoUnitsComponent chatInfoUnitsComponent = scene.GetComponent<ChatInfoUnitsComponent>();

            ChatInfoUnit chatInfoUnit = chatInfoUnitsComponent.Get(request.UnitId);

            //若已存在重新赋值
            if (chatInfoUnit != null && !chatInfoUnit.IsDisposed)
            {
                chatInfoUnit.Name = request.Name;
                chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
                response.ChatInfoUnitInstanceId = chatInfoUnit.InstanceId;
                return;
            }
            else
            {
                //新建ChatInfo映射

                chatInfoUnit = chatInfoUnitsComponent.AddChildWithId<ChatInfoUnit>(request.UnitId);
                chatInfoUnit.AddComponent<MailBoxComponent>();

                chatInfoUnit.Name = request.Name;
                chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
                response.ChatInfoUnitInstanceId = chatInfoUnit.InstanceId;
                chatInfoUnitsComponent.Add(chatInfoUnit);
            }
            await ETTask.CompletedTask;
        }
    }
}