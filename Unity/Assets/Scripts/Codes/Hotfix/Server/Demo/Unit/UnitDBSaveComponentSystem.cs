using System;

namespace ET.Server
{
    [FriendOf(typeof (UnitDBSaveComponent))]
    public static class UnitDBSaveComponentSystem
    {
#region 生命周期

        public class UnitDBSaveComponentAwakeSystem: AwakeSystem<UnitDBSaveComponent>
        {
            protected override void Awake(UnitDBSaveComponent self) =>
                    //开启定时器任务,自动保存数据
                    self.Timer = TimerComponent.Instance.NewRepeatedTimer(10 * TimeHelper.Second, TimerInvokeType.UnitDBSave, self);
        }

        public class UnitDBSaveComponentDestroySystem: DestroySystem<UnitDBSaveComponent>
        {
            protected override void Destroy(UnitDBSaveComponent self) => TimerComponent.Instance.Remove(ref self.Timer);
        }

        public class UnitAddComponentSystem: AddComponentSystem<Unit>
        {
            protected override void AddComponent(Unit self, Entity component)
            {
                if (component is IUnitCache)
                    self.GetComponent<UnitDBSaveComponent>()?.AddChange(component.GetType());
            }
        }

        public class UnitGetComponentSystem: GetComponentSystem<Unit>
        {
            protected override void GetComponent(Unit self, Entity component)
            {
                if (component is IUnitCache)
                    self.GetComponent<UnitDBSaveComponent>()?.AddChange(component.GetType());
            }
        }

#endregion 生命周期

#region 定时任务

        [Invoke(TimerInvokeType.UnitDBSave)]
        public class UnitDBSaveTimer: ATimer<UnitDBSaveComponent>
        {
            protected override void Run(UnitDBSaveComponent self)
            {
                try
                {
                    if (self is null || self.IsDisposed)
                        return;
                    if (self.DomainScene() is null)
                        return;
                    self.SaveChange();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

#endregion 定时任务

        public static void AddChange(this UnitDBSaveComponent self, Type type) => self.ChangedComponents.Add(type);

        public static void SaveChange(this UnitDBSaveComponent self)
        {
            if (self.ChangedComponents.Count <= 0)
                return;
            var unit = self.GetParent<Unit>();
            Other2UnitCache_AddOrUpdateUnit request = new();
            request.UnitId = unit.Id;
            request.EntityTypes.Add(unit.GetType().FullName);
            request.EntityBytes.Add(MongoHelper.Serialize(unit));
            foreach (var type in self.ChangedComponents)
            {
                var component = unit.GetComponent(type);
                if (component is null || component.IsDisposed)
                    continue;
                Log.Debug($"开始保存变化的Component数据: [{type.Name}]");
                request.EntityTypes.Add(type.FullName);
                request.EntityBytes.Add(MongoHelper.Serialize(component));
            }

            self.ChangedComponents.Clear();
            var unitCacheSeverId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Id).InstanceId;
            MessageHelper.CallActor(unitCacheSeverId, request).Coroutine();
        }
    }
}