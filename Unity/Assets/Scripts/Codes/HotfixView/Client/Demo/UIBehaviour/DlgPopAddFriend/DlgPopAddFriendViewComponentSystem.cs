namespace ET.Client
{
    [ObjectSystem]
    public class DlgPopAddFriendViewComponentAwakeSystem: AwakeSystem<DlgPopAddFriendViewComponent>
    {
        protected override void Awake(DlgPopAddFriendViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }
    }

    [ObjectSystem]
    public class DlgPopAddFriendViewComponentDestroySystem: DestroySystem<DlgPopAddFriendViewComponent>
    {
        protected override void Destroy(DlgPopAddFriendViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}