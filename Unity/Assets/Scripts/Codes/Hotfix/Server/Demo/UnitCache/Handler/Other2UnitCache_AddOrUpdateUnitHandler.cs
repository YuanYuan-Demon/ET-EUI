namespace ET.Server
{
    [ActorMessageHandler(SceneType.UnitCache)]
    public class Other2UnitCache_AddOrUpdateUnitHandler: AMActorRpcHandler<Scene, Other2UnitCache_AddOrUpdateUnit, UnitCache2Other_AddOrUpdateUnit>
    {
        private static async ETTask UpdateUnitCacheAsync(Scene scene, Other2UnitCache_AddOrUpdateUnit request,
        UnitCache2Other_AddOrUpdateUnit response)
        {
            var unitCacheCompnent = scene.GetComponent<UnitCacheComponent>();
            using (var entityList = ListComponent<Entity>.Create())
            {
                for (var i = 0; i < request.EntityTypes.Count; i++)
                {
                    var type = EventSystem.Instance.GetType(request.EntityTypes[i]);
                    var entity = MongoHelper.Deserialize(type, request.EntityBytes[i]) as Entity;
                    entityList.Add(entity);
                }

                await unitCacheCompnent.AddOrUpdate(request.UnitId, entityList);
            }
        }

        protected override async ETTask Run(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response)
        {
            UpdateUnitCacheAsync(scene, request, response).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}