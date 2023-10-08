namespace ET.Client
{
    [ObjectSystem]
    public class DlgShopViewComponentAwakeSystem: AwakeSystem<DlgShopViewComponent>
    {
        protected override void Awake(DlgShopViewComponent self) => self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
    }

    [ObjectSystem]
    public class DlgShopViewComponentDestroySystem: DestroySystem<DlgShopViewComponent>
    {
        protected override void Destroy(DlgShopViewComponent self) => self.DestroyWidget();
    }
}