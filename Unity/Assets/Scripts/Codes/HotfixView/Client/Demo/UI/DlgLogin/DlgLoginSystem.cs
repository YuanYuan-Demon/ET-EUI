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
            //await LoginHelper.LoginExample(self.ClientScene(), self.View.EInput_AccountInputField.text, self.View.EInput_PasswordInputField.text);
            //return;
            try
            {
                if (string.IsNullOrEmpty(self.View.EInput_AccountInputField.text)
                    || string.IsNullOrEmpty(self.View.EInput_PasswordInputField.text))
                {
                    Log.Error("账号或密码不能为空");
                    self.ClientScene().GetComponent<UIComponent>()
                        .ShowErrorBox("账号或密码不能为空");
                    return;
                }
                var err = await LoginHelper.Login(
                    self.ClientScene(),
                    self.View.EInput_AccountInputField.text,
                    self.View.EInput_PasswordInputField.text);

                if (err.Code != ErrorCode.ERR_Success)
                {
                    Log.Error(err.ToString());
                    self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(err.Message);
                    return;
                }

                err = await LoginHelper.GetServerInfos(self.DomainScene());
                if (err.Code != ErrorCode.ERR_Success)
                {
                    Log.Error(err.ToString());
                    self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(err.Message);
                    return;
                }
                //显示登陆之后的页面逻辑
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Server);
            }
            catch (Exception e)
            {
                Log.Error(e);
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(e);
            }
        }
    }
}