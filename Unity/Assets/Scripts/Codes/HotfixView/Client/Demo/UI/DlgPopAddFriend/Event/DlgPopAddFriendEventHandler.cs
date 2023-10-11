namespace ET.Client
{
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_PopAddFriend)]
    public class DlgPopAddFriendEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.windowType = UIWindowType.Normal;
        }

        public void OnInitComponent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.AddComponent<DlgPopAddFriend>().AddComponent<DlgPopAddFriendViewComponent>();
        }

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgPopAddFriend>().RegisterUIEvent();
        }

        public void OnShowWindow(UIBaseWindow uiBaseWindow, ShowWindowData windowData = null)
        {
            uiBaseWindow.GetComponent<DlgPopAddFriend>().ShowWindow(windowData);
        }

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}