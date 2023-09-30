using System;

namespace ET
{
    public interface IEvent
    {
        Type Type { get; }
    }

    public abstract class AEvent<Event>: IEvent where Event : struct
    {
        public Type Type => typeof (Event);

        protected abstract ETTask Run(Scene scene, Event args);

        public async ETTask Handle(Scene scene, Event args)
        {
            try
            {
                await this.Run(scene, args);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}