using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView : AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterUnitCreate args)
        {
            // Unit View层 这里可以改成异步加载，demo就不搞了
            await ResourcesComponent.Instance.LoadBundleAsync($"{args.Unit.Config.PrefabName}.unity3d");
            GameObject bundleGameObject = ResourcesComponent.Instance.GetAsset($"{args.Unit.Config.PrefabName}.unity3d", args.Unit.Config.PrefabName) as GameObject;
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            go.transform.SetParent(GlobalComponent.Instance.Unit, true);

            var goComponent = args.Unit.AddComponent<GameObjectComponent>();
            goComponent.GameObject = go;
            goComponent.SpriteRenderer = go.GetComponent<SpriteRenderer>();
            args.Unit.AddComponent<AnimatorComponent>();
            args.Unit.AddComponent<HeadHpViewComponent>();

            args.Unit.Position = args.Unit.Type == UnitType.Player
                ? new float3(-3f, 1, 0)
                : new float3(3f, RandomHelper.RandomFloat(-2f, 2f), 0);
            //goComponent.SpriteRenderer.sortingOrder = (int)args.Unit.Id;
            await ETTask.CompletedTask;
        }
    }
}