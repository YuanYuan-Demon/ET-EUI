using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            await ETTask.CompletedTask;

            //UIComponent.Instance.HideWindow(WindowID.WindowID_Loading);
            UIComponent.Instance.ShowWindow(WindowID.WindowID_Main);
            scene.AddComponent<CameraComponent>();
        }
    }
}