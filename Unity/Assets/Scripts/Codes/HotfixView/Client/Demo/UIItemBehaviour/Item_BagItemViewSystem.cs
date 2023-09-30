namespace ET.Client
{
    [ObjectSystem]
    public class Scroll_Item_BagItemDestroySystem: DestroySystem<Scroll_Item_BagItem>
    {
        protected override void Destroy(Scroll_Item_BagItem self)
        {
            self.DestroyWidget();
        }
    }
}