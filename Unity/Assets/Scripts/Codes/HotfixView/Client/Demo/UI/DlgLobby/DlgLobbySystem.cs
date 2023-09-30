namespace ET.Client
{
    [FriendOf(typeof (DlgLobby))]
    public static class DlgLobbySystem
    {
        public static void RegisterUIEvent(this DlgLobby self) => self.View.E_EnterMapButton.AddListenerAsync(self.EnterMap);

        public static void ShowWindow(this DlgLobby self, ShowWindowData windowData = null)
        {
        }

        public static async ETTask EnterMap(this DlgLobby self)
        {
            await EnterMapHelper.EnterMapAsync(self.ClientScene());
            UIComponent.Instance.HideWindow(WindowID.WindowID_Lobby);
        }
    }
}