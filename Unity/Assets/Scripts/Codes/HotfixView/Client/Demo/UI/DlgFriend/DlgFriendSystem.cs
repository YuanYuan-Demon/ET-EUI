using ET.Client.EventType;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgFriend))]
    [FriendOfAttribute(typeof (CFriendComponent))]
    [FriendOfAttribute(typeof (FriendInfo))]
    public static class DlgFriendSystem
    {
        public static void RegisterUIEvent(this DlgFriend self)
        {
            var view = self.View;
            self.RegisterCloseEvent<DlgFriend>(view.EB_Close_Button);
            view.EToggle_Friends_Toggle.onValueChanged.AddListener(self.ShowFriendPanel);
            view.EToggle_FriendApply_Toggle.onValueChanged.AddListener(self.ShowApplyPanel);

            view.EL_Friend_LoopVList.AddItemRefreshListener(self.OnRefreshFriendItem);
            view.EL_Apply_LoopVList.AddItemRefreshListener(self.OnRefreshApplyItem);

            view.EB_Delete_Button.AddListener(() => self.OnDeleteFriend().Coroutine());
            view.EB_Chat_Button.AddListener(self.OnPrivateChat);
            view.EB_AddFriend_Button.AddListener(self.OnAddFriend);
        }

        public static void ShowWindow(this DlgFriend self, ShowWindowData windowData = null) => self.Refersh();

        public static void Refersh(this DlgFriend self)
        {
            self.ShowFriendPanel(self.View.EToggle_Friends_Toggle.isOn);
            self.ShowApplyPanel(self.View.EToggle_FriendApply_Toggle.isOn);
        }

        public static void ShowFriendPanel(this DlgFriend self, bool isShow)
        {
            if (isShow)
            {
                self.Friends.Clear();
                self.Friends.AddRange(self.ClientScene().GetComponent<CFriendComponent>().Friends.Values);
                self.AddUIScrollItems(ref self.ScrollItemFriends, self.Friends.Count);
            }

            self.View.EL_Friend_LoopVList.SetVisible(isShow, self.Friends.Count);
            self.View.EG_Friends_RectTransform.SetVisible(isShow);
        }

        public static void ShowApplyPanel(this DlgFriend self, bool isShow)
        {
            if (isShow)
            {
                self.Applys.Clear();
                self.Applys.AddRange(self.ClientScene().GetComponent<CFriendComponent>().FriendApplys.Values);
                self.AddUIScrollItems(ref self.ScrollItemApplys, self.Applys.Count);
            }

            self.View.EL_Apply_LoopVList.SetVisible(isShow, self.Applys.Count);
            self.View.EG_Apply_RectTransform.SetVisible(isShow);
        }

        public static void OnRefreshFriendItem(this DlgFriend self, Transform transform, int index)
        {
            var scrollItemFriend = self.ScrollItemFriends[index].BindTrans(transform);
            scrollItemFriend.Init(self.Friends[index]);
        }

        public static void OnRefreshApplyItem(this DlgFriend self, Transform transform, int index)
        {
            var friendApply = self.ScrollItemApplys[index].BindTrans(transform);
            friendApply.Init(self.Applys[index]);
        }

        private static void OnAddFriend(this DlgFriend self) => UIComponent.Instance.ShowWindow<DlgPopAddFriend>();

        public static async ETTask OnDeleteFriend(this DlgFriend self)
        {
            if (self.SelctedFriend is null)
            {
                UIComponent.Instance.ShowInfoBox("请选择要删除的好友");
                return;
            }

            var response = await self.ClientScene().Call(new C2F_DeleteFriend() { UnitId = self.SelctedFriend.Id });
            if (response?.Error != ErrorCode.ERR_Success)
            {
                Log.Error(response.ToString());
                UIComponent.Instance.ShowErrorBox(response.Message);
                return;
            }

            self.Refersh();
            UIComponent.Instance.ShowInfoBox("删除成功");
        }

        private static void OnPrivateChat(this DlgFriend self)
        {
            if (self.SelctedFriend is null)
            {
                UIComponent.Instance.ShowInfoBox("请选择要私聊的好友");
                return;
            }

            EventSystem.Instance.Publish(self.DomainScene(),
                new PrivateChat() { TargetId = self.SelctedFriend.Id, TargetName = self.SelctedFriend.Name });
        }
    }
}