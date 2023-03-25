namespace ET.Client
{
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_Helper)]
    public class DlgHelperEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow) => uiBaseWindow.windowType = UIWindowType.Normal;

        public void OnInitComponent(UIBaseWindow uiBaseWindow) => uiBaseWindow.AddComponent<DlgHelper>().AddComponent<DlgHelperViewComponent>();

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow) => uiBaseWindow.GetComponent<DlgHelper>().RegisterUIEvent();

        public void OnShowWindow(UIBaseWindow uiBaseWindow, ShowWindowData windowData = null) =>
                uiBaseWindow.GetComponent<DlgHelper>().ShowWindow(windowData);

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}