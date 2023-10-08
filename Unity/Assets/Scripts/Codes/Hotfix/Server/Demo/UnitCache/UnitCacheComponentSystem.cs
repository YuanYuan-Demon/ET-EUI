using System;

namespace ET.Server
{
    [FriendOf(typeof (UnitCache))]
    [FriendOf(typeof (UnitCacheComponent))]
    public static class UnitCacheComponentSystem
    {
#region 生命周期

        [FriendOf(typeof (UnitCache))]
        public class UnitCacheComponentAwakeSystem: AwakeSystem<UnitCacheComponent>
        {
            protected override void Awake(UnitCacheComponent self)
            {
                self.NeedCacheTypes.Clear();
                //读取所有需要缓存的类型名称
                foreach (var type in EventSystem.Instance.GetTypes().Values)
                {
                    if (type != typeof (IUnitCache) && typeof (IUnitCache).IsAssignableFrom(type))
                        self.NeedCacheTypes.Add(type);
                }

                //初始化所有缓存
                foreach (var type in self.NeedCacheTypes)
                {
                    var unitCache = self.AddChild<UnitCache>();
                    unitCache.ComponentType = type;
                    self.UnitCaches.Add(type, unitCache);
                }
            }
        }

        public class UnitCacheComponentDestroySystem: DestroySystem<UnitCacheComponent>
        {
            protected override void Destroy(UnitCacheComponent self)
            {
                foreach (var unitCache in self.UnitCaches.Values)
                {
                    unitCache?.Dispose();
                }

                self.UnitCaches.Clear();
            }
        }

#endregion 生命周期

        public static async ETTask AddOrUpdate(this UnitCacheComponent self, long unitId, ListComponent<Entity> entityList)
        {
            //using ListComponent<Entity> newList = ListComponent<Entity>.Create();
            foreach (var entity in entityList)
            {
                var type = entity.GetType();
                if (!self.UnitCaches.TryGetValue(type, out var unitCache))
                {
                    unitCache = self.AddChild<UnitCache>();
                    unitCache.ComponentType = type;
                    self.UnitCaches[type] = unitCache;
                }

                unitCache.AddOrUpdate(entity);
                //newList.Add(entity);
            }

            //if (newList.Level > 0)
            //{
            //await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(unitId, newList);
            //}
            await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(unitId, entityList);
        }

        public static void Delete(this UnitCacheComponent self, long unitId)
        {
            foreach (var cache in self.UnitCaches.Values)
            {
                cache.Delete(unitId);
            }
        }

        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, Type type)
        {
            if (!self.UnitCaches.TryGetValue(type, out var unitCache))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.ComponentType = type;
                self.UnitCaches[type] = unitCache;
            }

            return await unitCache.Get(unitId);
        }

        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, string type)
        {
            var entity = await self.Get(unitId, type.ToType());
            return entity;
        }
    }
}