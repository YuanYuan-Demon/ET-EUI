namespace ET.Client
{
    [ObjectSystem]
    public class Scroll_Item_TaskRewardItemDestroySystem: DestroySystem<Scroll_Item_TaskRewardItem>
    {
        protected override void Destroy(Scroll_Item_TaskRewardItem self)
        {
            self.DestroyWidget();
        }
    }
}