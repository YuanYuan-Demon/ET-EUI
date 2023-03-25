using System;

namespace ET.Client
{
    [FriendOf(typeof(DlgLogin))]
    public static class DlgLoginSystem
    {
        private static void ShowLogin(this DlgLogin self, bool isLogin = true)
        {
            self.View.EG_LoginPanelRectTransform.gameObject.SetActive(isLogin);
            self.View.EG_RegisterPanelRectTransform.gameObject.SetActive(!isLogin);
        }

        public static void RegisterUIEvent(this DlgLogin self)
        {
            self.View.EB_LoginButton.AddListener(self.OnClickLogin);
            self.View.EB_ToRegisterButton.AddListener(self.OnClickToRegister);
            self.View.EB_RegisterButton.AddListener(self.OnClickRegister);
            self.View.EB_CancelButton.AddListener(self.OnClickCancel);
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
                if (string.IsNullOrEmpty(self.View.EInput_LoginAccountTMP_InputField.text)
                    || string.IsNullOrEmpty(self.View.EInput_LoginPasswordTMP_InputField.text))
                {
                    Log.Error("账号或密码不能为空");
                    UIComponent.Instance.ShowErrorBox("账号或密码不能为空");
                    return;
                }
                var err = await LoginHelper.Login(
                    self.ClientScene(),
                    self.View.EInput_LoginAccountTMP_InputField.text,
                    self.View.EInput_LoginPasswordTMP_InputField.text);

                if (err.Code != ErrorCode.ERR_Success)
                {
                    Log.Error(err.ToString());
                    UIComponent.Instance.ShowErrorBox(err.Message);
                    return;
                }

                err = await LoginHelper.GetServerInfos(self.DomainScene());
                if (err.Code != ErrorCode.ERR_Success)
                {
                    Log.Error(err.ToString());
                    UIComponent.Instance.ShowErrorBox(err.Message);
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
                if (string.IsNullOrEmpty(self.View.EInput_LoginAccountTMP_InputField.text)
                    || string.IsNullOrEmpty(self.View.EInput_LoginPasswordTMP_InputField.text))
                {
                    Log.Error("账号或密码不能为空");
                    UIComponent.Instance.ShowErrorBox("账号或密码不能为空");
                    return;
                }
                var err = await LoginHelper.Register(
                    self.ClientScene(),
                    self.View.EInput_LoginAccountTMP_InputField.text,
                    self.View.EInput_LoginPasswordTMP_InputField.text);

                if (err.Code != ErrorCode.ERR_Success)
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