namespace ET.Server
{
    [FriendOf(typeof (UnitCache))]
    public static class UnitCacheSystem
    {
#region 生命周期

        public class UnitCacheAwakeSystem: AwakeSystem<UnitCache>
        {
            protected override void Awake(UnitCache self)
            {
                foreach (var entity in self.CacheComponents.Values)
                {
                    entity.Dispose();
                }

                self.CacheComponents.Clear();
                self.ComponentType = null;
            }
        }

#endregion 生命周期

        public static void AddOrUpdate(this UnitCache self, Entity entity)
        {
            if (entity is null)
                return;
            if (self.CacheComponents.TryGetValue(entity.Id, out var oldEntity))
            {
                if (oldEntity != entity)
                    oldEntity.Dispose();

                self.CacheComponents.Remove(entity.Id);
            }

            self.CacheComponents[entity.Id] = entity;
        }

        public static void Delete(this UnitCache self, long unitId)
        {
            if (self.CacheComponents.TryGetValue(unitId, out var entity))
            {
                entity.Dispose();
                self.CacheComponents.Remove(unitId);
            }
        }

        public static async ETTask<Entity> Get(this UnitCache self, long unitId)
        {
            if (!self.CacheComponents.TryGetValue(unitId, out var entity))
            {
                entity = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<Entity>(unitId, self.ComponentType.Name);
                if (entity != null)
                    self.AddOrUpdate(entity);
            }

            return entity;
        }
    }
}