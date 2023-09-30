﻿namespace ET.Client
{
    [FriendOf(typeof (WindowCoreData))]
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_Lobby)]
    public class DlgLobbyEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow) => uiBaseWindow.WindowData.windowType = UIWindowType.Normal;

        public void OnInitComponent(UIBaseWindow uiBaseWindow) => uiBaseWindow.AddComponent<DlgLobby>().AddComponent<DlgLobbyViewComponent>();

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow) => uiBaseWindow.GetComponent<DlgLobby>().RegisterUIEvent();

        public void OnShowWindow(UIBaseWindow uiBaseWindow, ShowWindowData windowData = null) =>
                uiBaseWindow.GetComponent<DlgLobby>().ShowWindow(windowData);

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}