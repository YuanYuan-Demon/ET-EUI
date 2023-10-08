using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof (UnitCacheComponent))]
    [ActorMessageHandler(SceneType.UnitCache)]
    public class Other2UnitCache_GetUnitHandler: AMActorRpcHandler<Scene, Other2UnitCache_GetUnit, UnitCache2Other_GetUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_GetUnit request, UnitCache2Other_GetUnit response)
        {
            var unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            var dictionary = ObjectPool.Instance.Fetch(typeof (Dictionary<string, Entity>)) as Dictionary<string, Entity>;
            try
            {
                //若未填写组件名,默认获取所有需要缓存的实体
                if (request.ComponentNames.Count == 0)
                {
                    dictionary.Add(typeof (Unit).FullName!, null);
                    foreach (var type in unitCacheComponent.NeedCacheTypes)
                    {
                        dictionary.Add(type.FullName!, null);
                    }
                }
                //根据请求的组件列表获取缓存
                else
                {
                    foreach (var name in request.ComponentNames)
                    {
                        dictionary.Add(name, null);
                    }
                }

                foreach (var typeName in dictionary.Keys.ToArray())
                {
                    var entity = await unitCacheComponent.Get(request.UnitId, typeName.ToType());
                    dictionary[typeName] = entity;
                    response.ComponentNames.Add(typeName);
                    response.Entities.Add(MongoHelper.Serialize(entity));
                }
            }
            finally
            {
                dictionary.Clear();
                ObjectPool.Instance.Recycle(dictionary);
            }

            await ETTask.CompletedTask;
        }
    }
}