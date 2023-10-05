namespace ET.Client
{
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_PopItem)]
    public class DlgPopItemEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow) => uiBaseWindow.windowType = UIWindowType.PopUp;

        public void OnInitComponent(UIBaseWindow uiBaseWindow) => uiBaseWindow.AddComponent<DlgPopItem>().AddComponent<DlgPopItemViewComponent>();

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow) => uiBaseWindow.GetComponent<DlgPopItem>().RegisterUIEvent();

        public void OnShowWindow(UIBaseWindow uiBaseWindow, ShowWindowData windowData = null) =>
                uiBaseWindow.GetComponent<DlgPopItem>().ShowWindow(windowData);

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}