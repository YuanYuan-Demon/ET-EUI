using System;

namespace ET.Client
{
    [FriendOfAttribute(typeof (FriendInfo))]
    [FriendOfAttribute(typeof (Scroll_Item_FriendApply))]
    [FriendOfAttribute(typeof (DlgFriend))]
    public static class Scroll_Item_FriendApplySystem
    {
        public static void Init(this Scroll_Item_FriendApply self, FriendInfo friendInfo)
        {
            var isApply = friendInfo.IsApply;
            self.EB_Agree_Button.SetVisible(isApply);
            self.EB_Refuse_Button.SetVisible(isApply);
            self.ET_Result_TextMeshProUGUI.SetVisible(!isApply);
            self.EB_Agree_Button.AddListener(() => self.OnHandleApply(friendInfo.Id, true).Coroutine());
            self.EB_Refuse_Button.AddListener(() => self.OnHandleApply(friendInfo.Id, false).Coroutine());
            self.Refresh(friendInfo);
        }

        public static void Refresh(this Scroll_Item_FriendApply self, FriendInfo friendInfo)
        {
            self.ET_Name_TextMeshProUGUI.text = friendInfo.Name;
            self.ET_Level_TextMeshProUGUI.text = friendInfo.Level.ToString();
            self.ET_Class_TextMeshProUGUI.text = friendInfo.RoleClass.GetDisplayName();
        }

        private static async ETTask OnHandleApply(this Scroll_Item_FriendApply self, long unitId, bool result)
        {
            try
            {
                var errorCode = await FriendHelper.SendAgreeFriend(self.ClientScene(), unitId, result);
                if (errorCode != ErrorCode.ERR_Success)
                    Log.Error(errorCode.ToString());
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            self.EB_Agree_Button.SetVisible(false);
            self.EB_Refuse_Button.SetVisible(false);
            self.ET_Result_TextMeshProUGUI.SetVisible(true);
            self.ET_Result_TextMeshProUGUI.text = result? "已同意" : "已拒绝";
        }
    }
}