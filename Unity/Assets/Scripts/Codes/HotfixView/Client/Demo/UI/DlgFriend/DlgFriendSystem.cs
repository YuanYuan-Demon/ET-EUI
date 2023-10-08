using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgFriend))]
    [FriendOfAttribute(typeof (CFriendComponent))]
    public static class DlgFriendSystem
    {
        public static void RegisterUIEvent(this DlgFriend self)
        {
            var view = self.View;
            self.RegisterCloseEvent<DlgFriend>(view.EB_Close_Button);
            view.EToggle_Friends_Toggle.onValueChanged.AddListener(isOn => view.EG_Friends_RectTransform.SetVisible(isOn));
            view.EToggle_FriendApply_Toggle.onValueChanged.AddListener(isOn => view.EG_Apply_RectTransform.SetVisible(isOn));
            view.EToggle_Friends_Toggle.isOn = true;

            view.EL_Friend_LoopVList.AddItemRefreshListener(self.OnRefreshFriendItem);
            view.EL_Apply_LoopVList.AddItemRefreshListener(self.OnRefreshFriendItem);
        }

        public static void ShowWindow(this DlgFriend self, ShowWindowData windowData = null) => self.Refersh();

        public static void Refersh(this DlgFriend self)
        {
            if (self.View.EToggle_Friends_Toggle.isOn)
            {
                self.Friends.Clear();
                self.Friends.AddRange(self.ClientScene().GetComponent<CFriendComponent>().Friends.Values);
                self.AddUIScrollItems(ref self.ScrollItemFriends, self.Friends.Count);
                self.View.EL_Friend_LoopVList.SetVisible(true, self.Friends.Count);
            }
            else
            {
                self.Applys.Clear();
                self.Applys.AddRange(self.ClientScene().GetComponent<CFriendComponent>().FriendApplys.Values);
                self.AddUIScrollItems(ref self.ScrollItemApplys, self.Applys.Count);
                self.View.EL_Apply_LoopVList.SetVisible(true, self.Applys.Count);
            }
        }

        public static void OnRefreshFriendItem(this DlgFriend self, Transform transform, int index)
        {
            var scrollItemFriend = self.ScrollItemFriends[index].BindTrans(transform);
            scrollItemFriend.Refresh(self.Friends[index]);
        }

        public static void OnRefreshApplyItem(this DlgFriend self, Transform transform, int index)
        {
            var friendApply = self.ScrollItemApplys[index].BindTrans(transform);
            friendApply.Refresh(self.Applys[index]);
        }
    }
}