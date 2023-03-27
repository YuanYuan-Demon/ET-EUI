﻿using System;

namespace ET
{
    public interface IEvent
    {
        Type Type { get; }
    }

    public abstract class AEvent<EventType> : IEvent where EventType : struct
    {
        public Type Type
        {
            get
            {
                return typeof(EventType);
            }
        }

        protected abstract ETTask Run(Scene scene, EventType args);

        public async ETTask Handle(Scene scene, EventType args)
        {
            try
            {
                await Run(scene, args);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}