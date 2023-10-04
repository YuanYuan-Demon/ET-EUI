namespace ET.Client
{
    [ObjectSystem]
    public class DlgTaskViewComponentAwakeSystem: AwakeSystem<DlgTaskViewComponent>
    {
        protected override void Awake(DlgTaskViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }
    }

    [ObjectSystem]
    public class DlgTaskViewComponentDestroySystem: DestroySystem<DlgTaskViewComponent>
    {
        protected override void Destroy(DlgTaskViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}