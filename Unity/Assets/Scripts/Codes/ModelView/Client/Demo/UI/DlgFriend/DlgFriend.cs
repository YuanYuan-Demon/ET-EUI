using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgFriend: Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_Friend> ScrollItemFriends;
        public List<Scroll_Item_FriendApply> ScrollItemApplys;
        public List<FriendInfo> Friends = new();
        public List<FriendInfo> Applys = new();
        public FriendInfo SelctedFriend;

        public DlgFriendViewComponent View => this.GetComponent<DlgFriendViewComponent>();
    }
}