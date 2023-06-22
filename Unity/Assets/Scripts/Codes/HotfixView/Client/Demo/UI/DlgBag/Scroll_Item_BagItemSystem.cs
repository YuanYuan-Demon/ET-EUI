namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BagItem))]
    [FriendOf(typeof(Item))]
    [FriendOf(typeof(BagComponent))]
    public static class Scroll_Item_BagItemSystem
    {
        public static void Refresh(this Scroll_Item_BagItem self, long id)
        {
            Item item = self.ClientScene().GetComponent<BagComponent>().GetItemById(id);
            self.Refresh(item);
        }

        public static void Refresh(this Scroll_Item_BagItem self, Item item)
        {
            self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", item.Config.Icon);
            if (item.CanStack)
            {
                self.ET_Count_Text.gameObject.SetActive(true);
                self.ET_Count_Text.text = item.Count.ToString();
            }
            else
            {
                self.ET_Count_Text.gameObject.SetActive(false);
            }
            //self.EI_QualityImage.color = item.ItemQualityColor();
            self.EB_Select_Button.AddListenerWithId(self.OnShowItemEntryPopUpHandler, (long)item.ConfigId);
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_BagItem self, long Id)
        {
            //Item item = self.ClientScene().GetComponent<BagComponent>().GetItemById(Id);
            //ShowWindowData showData = new()
            //{
            //    contextData = new ItemPopUpData()
            //    {
            //        Item = item,
            //        ItemContainerType = ItemContainerType.Bag
            //    }
            //};
            //self.ShowWindow<DlgItemPopUp>(showData);
        }
    }
}