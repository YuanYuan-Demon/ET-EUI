using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgShop: Entity, IAwake, IUILogic
    {
        public List<ItemConfig> ConfigList = new();
        public Dictionary<int, Scroll_Item_ShopItem> ScrollItemShopItems;
        public (int ConfigId, int Count) SelectItem;
        public ItemType ShopTab;
        public DlgShopViewComponent View => this.GetComponent<DlgShopViewComponent>();
    }
}