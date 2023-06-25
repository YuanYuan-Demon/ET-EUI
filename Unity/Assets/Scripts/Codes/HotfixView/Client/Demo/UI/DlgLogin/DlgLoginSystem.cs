using System;

namespace ET.Client
{
    [FriendOf(typeof(DlgLogin))]
    public static class DlgLoginSystem
    {
        private static void ShowLogin(this DlgLogin self, bool isLogin = true)
        {
            self.View.EG_LoginPanel_RectTransform.gameObject.SetActive(isLogin);
            self.View.EG_RegisterPanel_RectTransform.gameObject.SetActive(!isLogin);
        }

        public static void RegisterUIEvent(this DlgLogin self)
        {
            self.View.EB_Login_Button.AddListener(self.OnClickLogin);
            self.View.EB_ToRegister_Button.AddListener(self.OnClickToRegister);
            self.View.EB_Register_Button.AddListener(self.OnClickRegister);
            self.View.EB_Cancel_Button.AddListener(self.OnClickCancel);
        }

        public static void ShowWindow(this DlgLogin self, Entity contextData = null)
        {
            self.ShowLogin();
        }

        #region 按钮事件

        private static async void OnClickLogin(this DlgLogin self)
        {
            try
            {
                string account = self.View.EInput_LoginAccount_TMP_InputField.text;
                string password = self.View.EInput_LoginPassword_TMP_InputField.text;

                if (string.IsNullOrEmpty(account)
                    || string.IsNullOrEmpty(password))
                {
                    Log.Error("账号或密码不能为空");
                    UIComponent.Instance.ShowErrorBox("账号或密码不能为空");
                    return;
                }
                var response = await LoginHelper.Login(
                    self.ClientScene(),
                    account,
                    password);

                if (response?.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(response.ToString());
                    UIComponent.Instance.ShowErrorBox(response.Message);
                    return;
                }

                response = await LoginHelper.GetServerInfos(self.DomainScene());
                if (response?.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(response.ToString());
                    UIComponent.Instance.ShowErrorBox(response.Message);
                    return;
                }
                //显示登陆之后的页面逻辑
                UIComponent.Instance.HideWindow(WindowID.WindowID_Login);
                UIComponent.Instance.ShowWindow(WindowID.WindowID_Server);
            }
            catch (Exception e)
            {
                Log.Error(e);
                UIComponent.Instance.ShowErrorBox(e);
            }
        }

        private static void OnClickToRegister(this DlgLogin self)
        {
            self.ShowLogin(false);
        }

        private static async void OnClickRegister(this DlgLogin self)
        {
            try
            {
                string account = self.View.EInput_RegisterAccount_TMP_InputField.text;
                string password = self.View.EInput_RegisterPassword_TMP_InputField.text;
                string confirmPassword = self.View.EInput_RegisterPassword_Confirm_TMP_InputField.text;

                if (string.IsNullOrEmpty(account)
                    || string.IsNullOrEmpty(password)
                    || string.IsNullOrEmpty(confirmPassword))
                {
                    Log.Error("账号或密码不能为空");
                    UIComponent.Instance.ShowErrorBox("账号或密码不能为空");
                    return;
                }
                if (string.Compare(password, confirmPassword) != 0)
                {
                    Log.Error("两次密码不一致");
                    UIComponent.Instance.ShowErrorBox("两次密码不一致");
                    return;
                }
                var err = await LoginHelper.Register(
                    self.ClientScene(),
                    account,
                    password);

                if (err.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(err.ToString());
                    UIComponent.Instance.ShowErrorBox(err.Message);
                    return;
                }
                self.ShowLogin(true);
            }
            catch (Exception e)
            {
                Log.Error(e);
                UIComponent.Instance.ShowErrorBox(e);
            }
        }

        private static void OnClickCancel(this DlgLogin self)
        {
            self.ShowLogin();
        }

        #endregion 按钮事件
    }
}