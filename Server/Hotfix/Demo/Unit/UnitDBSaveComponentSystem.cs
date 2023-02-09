﻿using System;

namespace ET
{
    [FriendClassAttribute(typeof(ET.UnitDBSaveComponent))]
    public static class UnitDBSaveComponentSystem
    {
        public class UnitDBSaveComponentAwakeSystem : AwakeSystem<UnitDBSaveComponent>
        {
            public override void Awake(UnitDBSaveComponent self)
            {
                //开启定时器任务,自动保存数据
                self.Timer = TimerComponent.Instance.NewRepeatedTimer(10 * TimeHelper.Second, TimerType.UnitDBSave, self);
            }
        }

        public class UnitDBSaveComponentDestroySystem : DestroySystem<UnitDBSaveComponent>
        {
            public override void Destroy(UnitDBSaveComponent self)
            {
                TimerComponent.Instance.Remove(ref self.Timer);
            }
        }

        [Timer(TimerType.UnitDBSave)]
        public class UnitDBSaveTimer : ATimer<UnitDBSaveComponent>
        {
            public override void Run(UnitDBSaveComponent self)
            {
                try
                {
                    if (self is null || self.IsDisposed)
                        return;
                    if (self.DomainScene() is null)
                        return;
                    self?.SaveChange();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public static void AddChange(this UnitDBSaveComponent self, Type type)
        {
            if (!self.EntityChangeTypes.Contains(type))
                self.EntityChangeTypes.Add(type);
        }

        public static void SaveChange(this UnitDBSaveComponent self)
        {
            if (self.EntityChangeTypes.Count <= 0)
                return;
            Unit unit = self.GetParent<Unit>();
            Other2UnitCache_AddOrUpdateUnit request = new Other2UnitCache_AddOrUpdateUnit();
            request.UnitId = unit.Id;
            request.EntityTypes.Add(unit.GetType().FullName);
            request.EntityBytes.Add(MongoHelper.ToBson(unit));
            foreach (var type in self.EntityChangeTypes)
            {
                var component = unit.GetComponent(type);
                if (component is null || component.IsDisposed)
                    continue;
                Log.Debug($"开始保存变化的Component数据: [{type.Name}]");
                request.EntityTypes.Add(type.FullName);
                request.EntityBytes.Add(MongoHelper.ToBson(component));
            }
            self.EntityChangeTypes.Clear();
            var unitCacheSeverId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Id).InstanceId;
            MessageHelper.CallActor(unitCacheSeverId, request).Coroutine();
        }
    }

    public class UnitAddComponentSystem : AddComponentSystem<Unit>
    {
        public override void AddComponent(Unit self, Entity component)
        {
            if (component is IUnitCache)
                self.GetComponent<UnitDBSaveComponent>()?.AddChange(component.GetType());
        }
    }

    public class UnitGetComponentSystem : GetComponentSystem<Unit>
    {
        public override void GetComponent(Unit self, Entity component)
        {
            if (component is IUnitCache)
                self.GetComponent<UnitDBSaveComponent>()?.AddChange(component.GetType());
        }
    }
}