using System;

namespace ET.EventType
{
    public interface IEvent
    {
        Type GetEventType();
    }

    public interface IEventClass : IEvent
    {
        void Handle(object args);
    }

    [Event]
    public abstract class AEventClass<Event> : IEventClass where Event : class
    {
        protected abstract void Run(Event args);

        public Type GetEventType()
        {
            return typeof(Event);
        }

        public void Handle(object args)
        {
            try
            {
                Log.Debug($"HandleEvent: [{typeof(Event)}]");
                Run(args as Event);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }

    [Event]
    public abstract class AEvent<Event> : IEvent where Event : struct
    {
        protected abstract void Run(Event args);

        public Type GetEventType()
        {
            return typeof(Event);
        }

        public void Handle(Event args)
        {
            try
            {
                Log.Debug($"HandleEvent: [{typeof(Event)}]");
                Run(args);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }

    [Event]
    public abstract class AEventAsync<Event> : IEvent where Event : struct
    {
        protected abstract ETTask Run(Event args);

        public Type GetEventType()
        {
            return typeof(Event);
        }

        public async ETTask Handle(Event args)
        {
            try
            {
                Log.Debug($"HandleEvent: [{typeof(Event)}]");
                await Run(args);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}