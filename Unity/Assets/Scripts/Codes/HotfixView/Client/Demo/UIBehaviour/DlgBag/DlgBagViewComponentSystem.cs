﻿namespace ET.Client
{
    [ObjectSystem]
    public class DlgBagViewComponentAwakeSystem: AwakeSystem<DlgBagViewComponent>
    {
        protected override void Awake(DlgBagViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }
    }

    [ObjectSystem]
    public class DlgBagViewComponentDestroySystem: DestroySystem<DlgBagViewComponent>
    {
        protected override void Destroy(DlgBagViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}