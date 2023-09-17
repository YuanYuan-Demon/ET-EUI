using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AfterCreateClientScene_AddComponent : AEvent<AfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, AfterCreateClientScene args)
        {
            scene.AddComponent<ResourcesLoaderComponent>();

            scene.AddComponent<UIEventComponent>();
            scene.AddComponent<UIPathComponent>();
            scene.AddComponent<UIComponent>();
            scene.AddComponent<RedDotComponent>();
            scene.AddComponent<RoleShowComponent>();

            //Undone: AddComponent<FlyDamageValueViewComponent>();
            //scene.AddComponent<FlyDamageValueViewComponent>();

            scene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
            await ETTask.CompletedTask;
        }
    }
}