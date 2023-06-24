using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgShop : Entity, IAwake, IUILogic
    {
        public Dictionary<int, Scroll_Item_ShopItem> ScrollItemShopItems;
        public List<ItemConfig> ConfigList = new();

        public ItemType ShopTab;
        public DlgShopViewComponent View { get => this.GetComponent<DlgShopViewComponent>(); }
    }
}