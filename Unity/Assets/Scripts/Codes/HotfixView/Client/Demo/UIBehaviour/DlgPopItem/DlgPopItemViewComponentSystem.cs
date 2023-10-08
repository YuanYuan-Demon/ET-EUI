namespace ET.Client
{
    [ObjectSystem]
    public class DlgPopItemViewComponentAwakeSystem: AwakeSystem<DlgPopItemViewComponent>
    {
        protected override void Awake(DlgPopItemViewComponent self) => self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
    }

    [ObjectSystem]
    public class DlgPopItemViewComponentDestroySystem: DestroySystem<DlgPopItemViewComponent>
    {
        protected override void Destroy(DlgPopItemViewComponent self) => self.DestroyWidget();
    }
}