namespace ET.Client
{
    [ObjectSystem]
    public class Scroll_Item_ChatDestroySystem: DestroySystem<Scroll_Item_Chat>
    {
        protected override void Destroy(Scroll_Item_Chat self)
        {
            self.DestroyWidget();
        }
    }
}