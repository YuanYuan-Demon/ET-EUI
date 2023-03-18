using System;

namespace ET.Client
{
    [FriendOf(typeof(DlgLogin))]
    public static class DlgLoginSystem
    {
        public static void RegisterUIEvent(this DlgLogin self)
        {
            self.View.EB_LoginButton.onClick.AddListener(self.OnClickLogin);
        }

        public static void ShowWindow(this DlgLogin self, Entity contextData = null)
        {
        }

        public static async void OnClickLogin(this DlgLogin self)
        {
            try
            {
                int errorCode = await LoginHelper.Login(
                    self.ClientScene(),
                    self.View.EInput_AccountInputField.text,
                    self.View.EInput_PasswordInputField.text);

                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.GetServerInfos(self.DomainScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                //显示登陆之后的页面逻辑
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Server);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}