namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPopAddFriend: Entity, IAwake, IUILogic
    {
        public DlgPopAddFriendViewComponent View
        {
            get => this.GetComponent<DlgPopAddFriendViewComponent>();
        }
    }
}