﻿namespace ET.Client
{
    [FriendOf(typeof (WindowCoreData))]
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_Login)]
    public class DlgLoginEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow) => uiBaseWindow.WindowData.windowType = UIWindowType.Normal;

        public void OnInitComponent(UIBaseWindow uiBaseWindow) => uiBaseWindow.AddComponent<DlgLogin>().AddComponent<DlgLoginViewComponent>();

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow) => uiBaseWindow.GetComponent<DlgLogin>().RegisterUIEvent();

        public void OnShowWindow(UIBaseWindow uiBaseWindow, ShowWindowData windowData = null) =>
                uiBaseWindow.GetComponent<DlgLogin>().ShowWindow(windowData);

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}