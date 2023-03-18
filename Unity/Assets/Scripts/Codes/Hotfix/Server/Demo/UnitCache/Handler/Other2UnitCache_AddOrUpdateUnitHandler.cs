﻿using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.UnitCache)]
    public class Other2UnitCache_AddOrUpdateUnitHandler : AMActorRpcHandler<Scene, Other2UnitCache_AddOrUpdateUnit, UnitCache2Other_AddOrUpdateUnit>
    {
        private static async ETTask UpdateUnitCacheAsync(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response)
        {
            var unitCacheCompnent = scene.GetComponent<UnitCacheComponent>();
            using (ListComponent<Entity> entityList = ListComponent<Entity>.Create())
            {
                for (int i = 0; i < request.EntityTypes.Count; i++)
                {
                    Type type = EventSystem.Instance.GetType(request.EntityTypes[i]);
                    Entity entity = MongoHelper.Deserialize(type, request.EntityBytes[i]) as Entity;
                    entityList.Add(entity);
                }
                await unitCacheCompnent.AddOrUpdate(request.UnitId, entityList);
            }
        }

        protected override async ETTask Run(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response)
        {
            await UpdateUnitCacheAsync(scene, request, response);
        }
    }
}