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

            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            args.Unit.GetComponent<GameObjectComponent>().SpriteRenderer = go.GetComponent<SpriteRenderer>();
            args.Unit.AddComponent<AnimatorComponent>();
            //args.Unit.AddComponent<HeadHpViewComponent>();

            args.Unit.Position = Vector3.zero;
            args.Unit.Position = args.Unit.Type == UnitType.Player ? new Vector3(-1.5f, 0, 0)
                : new Vector3(1.5f, RandomGenerator.RandomNumber(-1, 1), 0);
            await ETTask.CompletedTask;
        }
    }
}