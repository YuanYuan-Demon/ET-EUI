using ET.EventType;

namespace ET
{
    public class SceneChangeFinishAsync_ShowCurrentSceneUI : AEventAsync<EventType.SceneChangeFinishAsync>
    {
        protected override async ETTask Run(EventType.SceneChangeFinishAsync args)
        {
            args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Loading);
            args.ZoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
            //args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Loading);
            await ETTask.CompletedTask;
        }
    }
}