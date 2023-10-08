namespace ET.Server
{
    [Event(SceneType.Process)]
    public class NetServerComponentOnReadEvent: AEvent<NetServerComponentOnRead>
    {
        protected override async ETTask Run(Scene scene, NetServerComponentOnRead args)
        {
            var session = args.Session;
            var message = args.Message;

            if (message is IResponse response)
            {
                session.OnResponse(response);
                return;
            }

            // 根据消息接口判断是不是Actor消息，不同的接口做不同的处理,比如需要转发给Chat Scene，可以做一个IChatMessage接口
            switch (message)
            {
                case IActorLocationRequest actorLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
                {
                    var unitId = session.GetComponent<SessionPlayerComponent>().PlayerId;
                    var rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
                    var instanceId = session.InstanceId;
                    IResponse iResponse = await ActorLocationSenderComponent.Instance.Call(unitId, actorLocationRequest);
                    iResponse.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                        session.Send(iResponse);
                    break;
                }
                case IActorLocationMessage actorLocationMessage:
                {
                    var unitId = session.GetComponent<SessionPlayerComponent>().PlayerId;
                    ActorLocationSenderComponent.Instance.Send(unitId, actorLocationMessage);
                    break;
                }

#region Chat服务器

                case IActorChatRequest request:
                {
                    if (Root.Instance.Get(session.GetComponent<SessionPlayerComponent>().PlayerInstanceId) is not Player player
                        || player.IsDisposed
                        || player.ChatUnitInstanceId == 0)
                        break;

                    var rpcId = request.RpcId; // 这里要保存客户端的rpcId
                    var instanceId = session.InstanceId;
                    IResponse respon = await ActorMessageSenderComponent.Instance.Call(player.ChatUnitInstanceId, request);
                    respon.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                        session.Send(respon);
                    break;
                }
                case IActorChatMessage actorChatInfoMessage:
                {
                    if (Root.Instance.Get(session.GetComponent<SessionPlayerComponent>().PlayerInstanceId) is not Player player
                        || player.IsDisposed
                        || player.ChatUnitInstanceId == 0)
                        break;

                    ActorMessageSenderComponent.Instance.Send(player.ChatUnitInstanceId, actorChatInfoMessage);
                    break;
                }

#endregion Chat服务器

#region 好友服务器

                case IActorFriendRequest request:
                {
                    if (Root.Instance.Get(session.GetComponent<SessionPlayerComponent>().PlayerInstanceId) is not Player player
                        || player.IsDisposed
                        || player.ChatUnitInstanceId == 0)
                        break;

                    var rpcId = request.RpcId; // 这里要保存客户端的rpcId
                    var instanceId = session.InstanceId;
                    IResponse respon = await ActorMessageSenderComponent.Instance.Call(player.FriendUnitInstanceId, request);
                    respon.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                        session.Send(respon);
                    break;
                }
                case IActorFriendMessage friendMessage:
                {
                    if (Root.Instance.Get(session.GetComponent<SessionPlayerComponent>().PlayerInstanceId) is not Player player
                        || player.IsDisposed
                        || player.FriendUnitInstanceId == 0)
                        break;

                    ActorMessageSenderComponent.Instance.Send(player.FriendUnitInstanceId, friendMessage);
                    break;
                }

#endregion

                case IActorRequest actorRequest: // 分发IActorRequest消息，目前没有用到，需要的自己添加
                {
                    break;
                }
                case IActorMessage actorMessage: // 分发IActorMessage消息，目前没有用到，需要的自己添加
                {
                    break;
                }

                default:
                {
                    // 非Actor消息
                    MessageDispatcherComponent.Instance.Handle(session, message);
                    break;
                }
            }
        }
    }
}