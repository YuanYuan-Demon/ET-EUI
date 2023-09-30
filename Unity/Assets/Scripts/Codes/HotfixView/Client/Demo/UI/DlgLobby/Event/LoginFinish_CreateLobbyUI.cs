using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class LoginFinish_CreateLobbyUI: AEvent<LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            UIComponent.Instance.HideWindow(WindowID.WindowID_Login);
            await UIComponent.Instance.ShowWindowAsync(WindowID.WindowID_Lobby);
        }
    }
}