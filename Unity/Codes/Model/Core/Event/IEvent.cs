using System;

namespace ET.EventType
{
    public interface IEvent
    {
        Type GetEventType();
    }

    public interface IEventClass : IEvent
    {
        void Handle(object a);
    }

    [Event]
    public abstract class AEventClass<A> : IEventClass where A : class
    {
        public Type GetEventType()
        {
            return typeof(A);
        }

        public void Handle(object a)
        {
            try
            {
                Log.Debug($"HandleEvent: [{typeof(A)}]");
                Run(a as A);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        protected abstract void Run(A a);
    }

    [Event]
    public abstract class AEvent<A> : IEvent where A : struct
    {
        public Type GetEventType()
        {
            return typeof(A);
        }

        public void Handle(A a)
        {
            try
            {
                Log.Debug($"HandleEvent: [{typeof(A)}]");
                Run(a);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        protected abstract void Run(A args);
    }

    [Event]
    public abstract class AEventAsync<A> : IEvent where A : struct
    {
        public Type GetEventType()
        {
            return typeof(A);
        }

        public async ETTask Handle(A a)
        {
            try
            {
                Log.Debug($"HandleEvent: [{typeof(A)}]");
                await Run(a);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        protected abstract ETTask Run(A args);
    }
}