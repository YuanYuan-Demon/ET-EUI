using ET.EventType;

namespace ET.Client
{
    [FriendOfAttribute(typeof (Scroll_Item_ShopItem))]
    public static class Scroll_Item_ShopItemSystem
    {
        public static void Refresh(this Scroll_Item_ShopItem self, int id)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(id);
            self.Refresh(itemConfig);
        }

        public static void Refresh(this Scroll_Item_ShopItem self, ItemConfig config)
        {
            self.RegisterEvent();

            self.Count = 1;
            self.DataId = config.Id;
            self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", config.Icon);
            self.ET_ItemTitle_TextMeshProUGUI.text = config.Name;
            self.ET_ItemDesc_TextMeshProUGUI.text = config.Desc;
            self.ET_ItemPrice_TextMeshProUGUI.text = $"￥{config.Price}";
            self.ET_BuyCount_TextMeshProUGUI.text = self.Count.ToString();
        }

        public static void RegisterEvent(this Scroll_Item_ShopItem self)
        {
            self.EB_Add_Button.AddListener(() =>
            {
                ++self.Count;
                self.ET_BuyCount_TextMeshProUGUI.text = self.Count.ToString();
            });
            self.EB_Minus_Button.AddListener(() =>
            {
                --self.Count;
                self.ET_BuyCount_TextMeshProUGUI.text = self.Count.ToString();
            });
            self.EB_Select_Button.AddListener(() =>
                    EventSystem.Instance.Publish(self.DomainScene(), new SelectShopItem() { Id = self.DataId, Count = self.Count }));
        }

        public static void UnRegisterEvent(this Scroll_Item_ShopItem self)
        {
            self.EB_Add_Button.onClick.RemoveAllListeners();
            self.EB_Minus_Button.onClick.RemoveAllListeners();
        }
    }
}