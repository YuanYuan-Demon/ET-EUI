namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AfterCreateClientScene_AddComponent : AEvent<EventType.AfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterCreateClientScene args)
        {
            scene.AddComponent<ResourcesLoaderComponent>();

            scene.AddComponent<UIEventComponent>();
            scene.AddComponent<UIPathComponent>();
            scene.AddComponent<UIComponent>();
            scene.AddComponent<RedDotComponent>();
            //Undone: AddComponent<FlyDamageValueViewComponent>();
            //scene.AddComponent<FlyDamageValueViewComponent>();

            scene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
            await ETTask.CompletedTask;
        }
    }
}