namespace ET.Client
{
    [ObjectSystem]
    public class DlgRegisterViewComponentAwakeSystem: AwakeSystem<DlgRegisterViewComponent>
    {
        protected override void Awake(DlgRegisterViewComponent self) => self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
    }

    [ObjectSystem]
    public class DlgRegisterViewComponentDestroySystem: DestroySystem<DlgRegisterViewComponent>
    {
        protected override void Destroy(DlgRegisterViewComponent self) => self.DestroyWidget();
    }
}