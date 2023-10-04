namespace ET.Client
{
    [ObjectSystem]
    public class Scroll_Item_TaskDestroySystem: DestroySystem<Scroll_Item_Task>
    {
        protected override void Destroy(Scroll_Item_Task self)
        {
            self.DestroyWidget();
        }
    }
}