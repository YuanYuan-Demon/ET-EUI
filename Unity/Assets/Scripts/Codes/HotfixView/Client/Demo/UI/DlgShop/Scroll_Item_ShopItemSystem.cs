namespace ET.Client
{
    public static class Scroll_Item_ShopItemSystem
    {
        public static void Refresh(this Scroll_Item_ShopItem self, int id)
        {
            var itemConfig = ItemConfigCategory.Instance.Get(id);
            self.RegisterEvent();
            self.Refresh(itemConfig);
        }

        public static void Refresh(this Scroll_Item_ShopItem self, ItemConfig config)
        {
            self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", config.Icon);
            self.ET_ItemTitle_TextMeshProUGUI.text = config.Name;
            self.ET_ItemDesc_TextMeshProUGUI.text = config.Desc;
            self.ET_ItemPrice_TextMeshProUGUI.text = $"{config.Price}";
            self.ET_BuyCount_TextMeshProUGUI.text = "1";
        }

        public static void RegisterEvent(this Scroll_Item_ShopItem self)
        {
            self.EB_Add_Button.onClick.AddListener(() => self.ET_BuyCount_TextMeshProUGUI.text = $"{int.Parse(self.ET_BuyCount_TextMeshProUGUI.text) + 1}");
            self.EB_Minus_Button.onClick.AddListener(() => self.ET_BuyCount_TextMeshProUGUI.text = $"{int.Parse(self.ET_BuyCount_TextMeshProUGUI.text) - 1}");
        }

        public static void UnRegisterEvent(this Scroll_Item_ShopItem self)
        {
            self.EB_Add_Button.onClick.RemoveAllListeners();
            self.EB_Minus_Button.onClick.RemoveAllListeners();
        }
    }
}