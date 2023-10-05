using ET.EventType;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof (HeadHUDViewComponent))]
    [FriendOfAttribute(typeof (RoleInfo))]
    public class AfterUnitCreate_CreateUnitView: AEvent<AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {
            var unit = args.Unit;
            //unit.Config
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            var bundleUnitGO = ResourcesComponent.Instance.GetAsset($"Unit.unity3d", "Unit") as GameObject;
            var prefab = bundleUnitGO.Get<GameObject>(args.Prefab);

            var unitGO = UnityEngine.Object.Instantiate(bundleUnitGO, GlobalComponent.Instance.Unit, true);
            var modelGO = UnityEngine.Object.Instantiate(prefab, unitGO.transform, true);

            unitGO.transform.position = unit.Position;
            unit.AddComponent<GameObjectComponent>().GameObject = unitGO;
            unit.GetComponent<ObjectWait>().Notify(new Wait_UnitAddGOComponent());
            unit.AddComponent<AnimatorComponent>();
            unit.AddComponent<HeadHUDViewComponent, string>(unit.GetComponent<RoleInfo>().Name);

            await ETTask.CompletedTask;
        }
    }
}