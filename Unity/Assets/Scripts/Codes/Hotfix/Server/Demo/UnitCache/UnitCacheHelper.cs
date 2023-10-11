using MongoDB.Bson;

namespace ET.Server
{
    [FriendOfAttribute(typeof (RoleInfo))]
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
                var roleInfo = await GetUnitComponentCache<RoleInfo>(player.UnitId);
                roleInfo.Online = true;
                roleInfo.LastLoginTime = TimeHelper.ServerNow();

                unit = UnitFactory.CreatePlayer(gateMapComponent.Scene, player.Id, UnitType.Player, roleInfo);

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
                    continue;

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
                return null;

            //获取Unit
            var index = response.ComponentNames.IndexOf(typeof (Unit).FullName);
            if (response.Entities[index] is null)
                return null;
            if (MongoHelper.Deserialize<Unit>(response.Entities[index]) is { } unit)
            {
                scene.AddChild(unit);

                //添加Unit身上的组件
                for (var i = 0; i < response.Entities.Count; i++)
                {
                    var type = response.ComponentNames[i].ToType();
                    if (type == typeof (Unit))
                        continue;
                    var entity = (Entity)MongoHelper.Deserialize(type, response.Entities[i]);
                    if (entity is null or Unit)
                        continue;

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
            message.ComponentNames.Add(typeof (T).FullName);
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            var cacheResponse = await MessageHelper.CallActor(instanceId, message) as UnitCache2Other_GetUnit;
            if (cacheResponse.Error == ErrorCode.ERR_Success && cacheResponse.Entities.Count > 0)
                return MongoHelper.Deserialize<T>(cacheResponse.Entities[0]);

            return null;
        }
    }
}