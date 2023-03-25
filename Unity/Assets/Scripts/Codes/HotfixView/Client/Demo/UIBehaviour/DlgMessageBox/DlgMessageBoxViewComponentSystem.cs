namespace ET.Client
{
    [ObjectSystem]
    public class DlgMessageBoxViewComponentAwakeSystem: AwakeSystem<DlgMessageBoxViewComponent>
    {
        protected override void Awake(DlgMessageBoxViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }
    }

    [ObjectSystem]
    public class DlgMessageBoxViewComponentDestroySystem: DestroySystem<DlgMessageBoxViewComponent>
    {
        protected override void Destroy(DlgMessageBoxViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}