namespace ET.Client
{
    [FriendOf(typeof(DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            DlgMainViewComponent view = self.View;

            view.EB_Setting_Button.AddListener(self.OnClickSetting);
            view.EB_Bag_Button.AddListener(self.OnClickBag);
            view.EB_Quest_Button.AddListener(self.OnClickQuest);
            view.EB_Equip_Button.AddListener(self.OnClickEquip);
            view.EB_Skill_Button.AddListener(self.OnClickSkill);
            view.EB_Friend_Button.AddListener(self.OnClickFriend);
            view.EB_Guild_Button.AddListener(self.OnClickGuild);
            view.EB_Ride_Button.AddListener(self.OnClickRide);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
        }

        #region 按钮响应

        private static void OnClickSetting(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Setting);

        private static void OnClickBag(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Bag);

        private static void OnClickQuest(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Quest);

        private static void OnClickEquip(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Equip);

        private static void OnClickSkill(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Skill);

        private static void OnClickFriend(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Friend);

        private static void OnClickGuild(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Guild);

        private static void OnClickRide(this DlgMain self) => UIComponent.Instance.ShowWindow(WindowID.WindowID_Ride);

        #endregion 按钮响应
    }
}