namespace ET.Client
{
    [FriendOf(typeof (DlgPopAddFriend))]
    public static class DlgPopAddFriendSystem
    {
        public static void RegisterUIEvent(this DlgPopAddFriend self)
        {
            var view = self.View;
            self.RegisterCloseEvent<DlgPopAddFriend>(view.EB_Close_Button);
            view.EB_Add_Button.AddListenerAsync(self.OnAddFriend);
            view.EB_Cancel_Button.AddListener(UIComponent.Instance.HideWindow<DlgPopAddFriend>);
        }

        public static void ShowWindow(this DlgPopAddFriend self, ShowWindowData windowData = null)
        {
        }

        public static async ETTask OnAddFriend(this DlgPopAddFriend self)
        {
            if (string.IsNullOrEmpty(self.View.EInput_NameOrId_TMP_InputField.text))
            {
                UIComponent.Instance.ShowInfoBox("请输入玩家名称或ID");
                return;
            }

            var response = await self.ClientScene().Call(new C2F_AddFriend() { Name = self.View.EInput_NameOrId_TMP_InputField.text });
            if (response?.Error != ErrorCode.ERR_Success)
            {
                Log.Error(response.ToString());
                UIComponent.Instance.ShowErrorBox(response.Message);
                return;
            }

            UIComponent.Instance.ShowInfoBox("已发送好友申请");
        }
    }
}