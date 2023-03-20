﻿namespace ET.Client
{
    [FriendOf(typeof(WindowCoreData))]
    [FriendOf(typeof(UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_ItemPopUp)]
    public class DlgItemPopUpEventHandler : IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.WindowData.windowType = UIWindowType.PopUp;
        }

        public void OnInitComponent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.AddComponent<DlgItemPopUp>().AddComponent<DlgItemPopUpViewComponent>();
        }

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgItemPopUp>().RegisterUIEvent();
        }

        public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
        {
            uiBaseWindow.GetComponent<DlgItemPopUp>().ShowWindow(contextData);
        }

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}