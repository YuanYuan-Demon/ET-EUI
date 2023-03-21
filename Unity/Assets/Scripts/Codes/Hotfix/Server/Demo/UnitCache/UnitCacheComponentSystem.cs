namespace ET.Server
{
    [FriendOf(typeof(UnitCache))]
    [FriendOf(typeof(UnitCacheComponent))]
    public static class UnitCacheComponentSystem
    {
        #region 生命周期

        [FriendOf(typeof(UnitCache))]
        public class UnitCacheComponentAwakeSystem : AwakeSystem<UnitCacheComponent>
        {
            protected override void Awake(UnitCacheComponent self)
            {
                self.UnitCacheNames.Clear();
                //读取所有需要缓存的类型名称
                foreach (var type in EventSystem.Instance.GetTypes().Values)
                {
                    if (type != typeof(IUnitCache) && typeof(IUnitCache).IsAssignableFrom(type))
                    {
                        self.UnitCacheNames.Add(type.Name);
                    }
                }
                //初始化所有缓存
                foreach (var key in self.UnitCacheNames)
                {
                    var unitCache = self.AddChild<UnitCache>();
                    unitCache.EntityName = key;
                    self.UnitCaches.Add(key, unitCache);
                }
            }
        }

        public class UnitCacheComponentDestroySystem : DestroySystem<UnitCacheComponent>
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
                string key = entity.GetType().Name;
                if (!self.UnitCaches.TryGetValue(key, out UnitCache unitCache))
                {
                    unitCache = self.AddChild<UnitCache>();
                    unitCache.EntityName = key;
                    self.UnitCaches[key] = unitCache;
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

        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, string key)
        {
            if (!self.UnitCaches.TryGetValue(key, out var unitCache))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.EntityName = key;
                self.UnitCaches[key] = unitCache;
            }
            return await unitCache.Get(unitId);
        }
    }
}