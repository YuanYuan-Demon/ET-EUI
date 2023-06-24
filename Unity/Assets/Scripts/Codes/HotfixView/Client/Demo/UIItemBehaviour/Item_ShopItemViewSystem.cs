namespace ET.Client
{
    [ObjectSystem]
    public class Scroll_Item_ShopItemDestroySystem : DestroySystem<Scroll_Item_ShopItem>
    {
        protected override void Destroy(Scroll_Item_ShopItem self)
        {
            self.DestroyWidget();
        }
    }
}