namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeFinish args)
        {
            await ETTask.CompletedTask;

            //UIComponent.Instance.HideWindow(WindowID.WindowID_Loading);
            UIComponent.Instance.ShowWindow(WindowID.WindowID_Main);
            scene.AddComponent<CameraComponent>();
        }
    }
}