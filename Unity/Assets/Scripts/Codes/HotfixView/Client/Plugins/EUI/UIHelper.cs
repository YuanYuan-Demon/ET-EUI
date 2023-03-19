namespace ET.Client
{
    public static class UIHelper
    {
        #region 打开界面

        public static void ShowWindow(this Entity self, WindowID windowId, ShowWindowData showData = null)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(windowId, showData);
        }

        public static async ETTask ShowWindowAsync(this Entity self, WindowID windowId, ShowWindowData showData = null)
        {
            await self.ClientScene().GetComponent<UIComponent>().ShowWindowAsync(windowId, showData);
        }

        public static void ShowStackWindow(this Entity self, WindowID windowId)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowStackWindow(windowId);
        }

        #endregion 打开界面

        #region 关闭界面

        public static void HideWindow(this Entity self, WindowID windowId)
        {
            self.ClientScene().GetComponent<UIComponent>().HideWindow(windowId);
        }

        public static void HideAllWindow(this Entity self)
        {
            self.ClientScene().GetComponent<UIComponent>().HideAllShownWindow();
        }

        public static void CloseWindow(this Entity self, WindowID windowId)
        {
            self.ClientScene().GetComponent<UIComponent>().CloseWindow(windowId);
        }

        public static void CloseAllWindow(this Entity self)
        {
            self.ClientScene().GetComponent<UIComponent>().CloseAllWindow();
        }

        #endregion 关闭界面
    }
}