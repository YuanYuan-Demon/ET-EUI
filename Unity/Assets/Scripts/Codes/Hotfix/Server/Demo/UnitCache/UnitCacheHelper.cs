using MongoDB.Bson;

namespace ET.Server
{
    public static class UnitCacheHelper
    {
        public static async ETTask<(bool, Unit)> LoadUnit(Player player)
        {
            var gateMapComponent = player.AddComponent<GateMapComponent>();
            gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateMap", SceneType.Map);
            // 获取玩家缓存
            var unit = await GetUnitCache(gateMapComponent.Scene, player.UnitId);
            var isNewUnit = unit is null;
            if (isNewUnit)
            {
                //创建新角色Unit
                var roleInfos = await DBManagerComponent.Instance.GetZoneDB(player.DomainZone()).Query<RoleInfo>(r => r.Id == player.UnitId);
                unit = UnitFactory.CreatePlayer(gateMapComponent.Scene, player.Id, UnitType.Player, roleInfos[0]);

                AddOrUpdateUnitAllCache(unit);
            }

            return (isNewUnit, unit);
        }

        /// <summary>
        ///     保存Unit及Unit身上的组件到缓存服务器和数据库中
        /// </summary>
        /// <param name="unit"> </param>
        public static void AddOrUpdateUnitAllCache(Unit unit)
        {
            var message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = unit.Id };
            message.EntityTypes.Add(typeof (Unit).FullName);
            message.EntityBytes.Add(MongoHelper.Serialize(unit));
            foreach (var (type, entity) in unit.Components)
            {
                if (!typeof (IUnitCache).IsAssignableFrom(type))
                {
                    continue;
                }

                message.EntityTypes.Add(type.FullName);
                message.EntityBytes.Add(MongoHelper.Serialize(entity));
            }

            MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Id).InstanceId, message).Coroutine();
        }

        /// <summary>
        ///     保存或更新玩家缓存
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="self"> </param>
        public static async void AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
        {
            var message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = self.Id };
            message.EntityTypes.Add(typeof (T).FullName);
            message.EntityBytes.Add(self.ToBson());
            await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(self.Id).InstanceId, message);
        }

        /// <summary>
        ///     删除玩家缓存
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="unitId"> </param>
        public static async void DeleteUnitCache<T>(long unitId) where T : Entity, IUnitCache
        {
            var message = new Other2UnitCache_DeleteUnit() { UnitId = unitId };
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            await MessageHelper.CallActor(instanceId, message);
        }

        /// <summary>
        ///     获取玩家缓存
        /// </summary>
        /// <param name="scene"> 存放位置 </param>
        /// <param name="unitId"> </param>
        /// <returns> </returns>
        public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
        {
            //从缓存服务器获取
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            var message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            var response = await MessageHelper.CallActor(instanceId, message) as UnitCache2Other_GetUnit;
            if (response.Error != ErrorCode.ERR_Success || response.Entities.Count <= 0)
            {
                return null;
            }

            //获取Unit
            var index = response.ComponentNames.IndexOf(nameof (Unit));
            if (response.Entities[index] is Unit unit)
            {
                scene.AddChild(unit);

                //添加Unit身上的组件
                foreach (var entity in response.Entities)
                {
                    if (entity is null || entity is Unit)
                    {
                        continue;
                    }

                    unit.AddComponent(entity);
                }

                return unit;
            }

            return null;
        }

        /// <summary>
        ///     获取玩家组件缓存
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="unitId"> </param>
        /// <returns> </returns>
        public static async ETTask<T> GetUnitComponentCache<T>(long unitId) where T : Entity, IUnitCache
        {
            var message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            message.ComponentNames.Add(typeof (T).Name);
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            var cacheResponse = await MessageHelper.CallActor(instanceId, message) as UnitCache2Other_GetUnit;
            if (cacheResponse.Error == ErrorCode.ERR_Success && cacheResponse.Entities.Count > 0)
            {
                return cacheResponse.Entities[0] as T;
            }

            return null;
        }
    }
}