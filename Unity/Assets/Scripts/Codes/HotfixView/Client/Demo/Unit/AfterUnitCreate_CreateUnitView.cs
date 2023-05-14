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
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset($"warrior.unity3d", "Warrior");
            GameObject prefab = bundleGameObject.Get<GameObject>("Warrior");

            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            go.transform.position = unit.Position;
            unit.AddComponent<GameObjectComponent>().GameObject = go;
            unit.GetComponent<ObjectWait>().Notify(new Wait_UnitAddGOComponent());
            unit.AddComponent<AnimatorComponent>();
            await ETTask.CompletedTask;
        }
    }
}