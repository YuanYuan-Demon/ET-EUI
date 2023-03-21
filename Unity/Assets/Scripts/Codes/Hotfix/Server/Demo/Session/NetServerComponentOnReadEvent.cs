namespace ET.Server
{
    [Event(SceneType.Process)]
    public class NetServerComponentOnReadEvent : AEvent<NetServerComponentOnRead>
    {
        protected override async ETTask Run(Scene scene, NetServerComponentOnRead args)
        {
            Session session = args.Session;
            object message = args.Message;

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
                    long unitId = session.GetComponent<SessionPlayerComponent>().PlayerId;
                    int rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
                    long instanceId = session.InstanceId;
                    IResponse iResponse = await ActorLocationSenderComponent.Instance.Call(unitId, actorLocationRequest);
                    iResponse.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }
                    break;
                }
                case IActorLocationMessage actorLocationMessage:
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().PlayerId;
                    ActorLocationSenderComponent.Instance.Send(unitId, actorLocationMessage);
                    break;
                }

                #region Rank服务器

                case IActorRankInfoMessage actorRankInfoMessage:
                {
                    long rankInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Rank").InstanceId;
                    ActorMessageSenderComponent.Instance.Send(rankInstanceId, actorRankInfoMessage);
                    break;
                }

                case IActorRankInfoRequest actorRankInfoRequest:
                {
                    long rankInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Rank").InstanceId;

                    int rpcId = actorRankInfoRequest.RpcId;
                    long instanceId = session.InstanceId;

                    var res = await ActorMessageSenderComponent.Instance.Call(rankInstanceId, actorRankInfoRequest);

                    res.RpcId = rpcId;

                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(res);
                    }
                    break;
                }

                #endregion Rank服务器

                #region Chat服务器

                case IActorChatInfoRequest actorChatInfoRequest:
                {
                    var player = Root.Instance.Get(session.GetComponent<SessionPlayerComponent>().PlayerInstanceId) as Player;
                    if (player is null || player.IsDisposed || player.ChatInfoInstanceId == 0)
                    {
                        break;
                    }

                    int rpcId = actorChatInfoRequest.RpcId; // 这里要保存客户端的rpcId
                    long instanceId = session.InstanceId;
                    IResponse respon = await ActorMessageSenderComponent.Instance.Call(player.ChatInfoInstanceId, actorChatInfoRequest);
                    respon.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(respon);
                    }
                    break;
                }
                case IActorChatInfoMessage actorChatInfoMessage:
                {
                    var player = Root.Instance.Get(session.GetComponent<SessionPlayerComponent>().PlayerInstanceId) as Player;
                    if (player is null || player.IsDisposed || player.ChatInfoInstanceId == 0)
                    {
                        break;
                    }

                    ActorMessageSenderComponent.Instance.Send(player.ChatInfoInstanceId, actorChatInfoMessage);
                    break;
                }

                #endregion Chat服务器

                case IActorRequest actorRequest:  // 分发IActorRequest消息，目前没有用到，需要的自己添加
                {
                    break;
                }
                case IActorMessage actorMessage:  // 分发IActorMessage消息，目前没有用到，需要的自己添加
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