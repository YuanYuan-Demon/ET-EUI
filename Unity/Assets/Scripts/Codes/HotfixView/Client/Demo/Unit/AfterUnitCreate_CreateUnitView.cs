using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView : AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterUnitCreate args)
        {
            Unit unit = args.Unit;
            //unit.Config
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            GameObject bundleUnitGO = ResourcesComponent.Instance.GetAsset($"Unit.unity3d", "Unit") as GameObject;
            GameObject prefab = bundleUnitGO.Get<GameObject>("Warrior");

            GameObject unitGO = UnityEngine.Object.Instantiate(bundleUnitGO, GlobalComponent.Instance.Unit, true);
            GameObject modelGO = UnityEngine.Object.Instantiate(prefab, unitGO.transform, true);

            unitGO.transform.position = unit.Position;
            unit.AddComponent<GameObjectComponent>().GameObject = unitGO;
            unit.GetComponent<ObjectWait>().Notify(new Wait_UnitAddGOComponent());
            unit.AddComponent<AnimatorComponent>();
            unit.AddComponent<HeadHUDViewComponent>();
            await ETTask.CompletedTask;
        }
    }
}