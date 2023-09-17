using ET.EventType;
namespace ET.Client
{
	[Event(SceneType.Client)]
	public class LoginFinish_CreateLobbyUI: AEvent<LoginFinish>
	{
		protected override async ETTask Run(Scene scene, LoginFinish args)
		{
			scene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
			await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Lobby);
		}
	}
}
