namespace ET.Client
{
    [FriendOfAttribute(typeof (FriendInfo))]
    [FriendOfAttribute(typeof (Scroll_Item_Friend))]
    [FriendOfAttribute(typeof (DlgFriend))]
    public static class Scroll_Item_FriendSystem
    {
        public static void Init(this Scroll_Item_Friend self, FriendInfo friendInfo)
        {
            self.ET_Select_Toggle.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                    UIComponent.Instance.GetDlgLogic<DlgFriend>().SelctedFriend = friendInfo;
            });
            self.Refresh(friendInfo);
        }

        public static void Refresh(this Scroll_Item_Friend self, FriendInfo friendInfo)
        {
            self.ET_Name_TextMeshProUGUI.text = friendInfo.Name;
            self.ET_Level_TextMeshProUGUI.text = friendInfo.Level.ToString();
            self.ET_Class_TextMeshProUGUI.text = friendInfo.RoleClass.GetDisplayName();
            self.ET_Status_TextMeshProUGUI.text = friendInfo.Online? "在线" : "离线";
        }
    }
}