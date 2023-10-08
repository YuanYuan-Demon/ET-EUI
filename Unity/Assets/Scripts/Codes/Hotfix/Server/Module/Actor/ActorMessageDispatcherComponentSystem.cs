using System;
using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    ///     Actor消息分发组件
    /// </summary>
    [FriendOf(typeof (ActorMessageDispatcherComponent))]
    public static class ActorMessageDispatcherComponentHelper
    {
        [ObjectSystem]
        public class ActorMessageDispatcherComponentAwakeSystem: AwakeSystem<ActorMessageDispatcherComponent>
        {
            protected override void Awake(ActorMessageDispatcherComponent self)
            {
                ActorMessageDispatcherComponent.Instance = self;
                self.Awake();
            }
        }

        [ObjectSystem]
        public class ActorMessageDispatcherComponentLoadSystem: LoadSystem<ActorMessageDispatcherComponent>
        {
            protected override void Load(ActorMessageDispatcherComponent self) => self.Load();
        }

        [ObjectSystem]
        public class ActorMessageDispatcherComponentDestroySystem: DestroySystem<ActorMessageDispatcherComponent>
        {
            protected override void Destroy(ActorMessageDispatcherComponent self)
            {
                self.ActorMessageHandlers.Clear();
                ActorMessageDispatcherComponent.Instance = null;
            }
        }

        private static void Awake(this ActorMessageDispatcherComponent self) => self.Load();

        private static void Load(this ActorMessageDispatcherComponent self)
        {
            self.ActorMessageHandlers.Clear();

            var types = EventSystem.Instance.GetTypes(typeof (ActorMessageHandlerAttribute));
            foreach (var type in types)
            {
                var obj = Activator.CreateInstance(type);

                var imHandler = obj as IMActorHandler;
                if (imHandler == null)
                    throw new($"message handler not inherit IMActorHandler abstract class: {obj.GetType().FullName}");

                var attrs = type.GetCustomAttributes(typeof (ActorMessageHandlerAttribute), false);

                foreach (var attr in attrs)
                {
                    var actorMessageHandlerAttribute = attr as ActorMessageHandlerAttribute;

                    var messageType = imHandler.GetRequestType();

                    var handleResponseType = imHandler.GetResponseType();
                    if (handleResponseType != null)
                    {
                        var responseType = OpcodeTypeComponent.Instance.GetResponseType(messageType);
                        if (handleResponseType != responseType)
                            throw new($"message handler response type error: {messageType.FullName}");
                    }

                    ActorMessageDispatcherInfo actorMessageDispatcherInfo = new(actorMessageHandlerAttribute.SceneType, imHandler);

                    self.RegisterHandler(messageType, actorMessageDispatcherInfo);
                }
            }
        }

        private static void RegisterHandler(this ActorMessageDispatcherComponent self, Type type, ActorMessageDispatcherInfo handler)
        {
            if (!self.ActorMessageHandlers.ContainsKey(type))
                self.ActorMessageHandlers.Add(type, new());

            self.ActorMessageHandlers[type].Add(handler);
        }

        public static async ETTask Handle(this ActorMessageDispatcherComponent self, Entity entity, int fromProcess, object message)
        {
            List<ActorMessageDispatcherInfo> list;
            if (!self.ActorMessageHandlers.TryGetValue(message.GetType(), out list))
                throw new($"not found message handler: {message}");

            var sceneType = entity.DomainScene().SceneType;
            foreach (var actorMessageDispatcherInfo in list)
            {
                if (actorMessageDispatcherInfo.SceneType != sceneType)
                    continue;
                await actorMessageDispatcherInfo.IMActorHandler.Handle(entity, fromProcess, message);
            }
        }
    }
}