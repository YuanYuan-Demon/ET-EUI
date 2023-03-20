namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BagItem))]
    [FriendOf(typeof(Item))]
    [FriendOf(typeof(BagComponent))]
    public static class Scroll_Item_bagItemSystem
    {
        public static void Refresh(this Scroll_Item_BagItem self, long id)
        {
            Item item = self.ClientScene().GetComponent<BagComponent>().GetItemById(id);

            self.EI_IconImage.overrideSprite = IconHelper.LoadIconSprite("Icons", item.Config.Icon);
            self.EI_QualityImage.color = item.ItemQualityColor();
            self.EB_SelectButton.AddListenerWithId(self.OnShowItemEntryPopUpHandler, id);
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_BagItem self, long Id)
        {
            Item item = self.ClientScene().GetComponent<BagComponent>().GetItemById(Id);
            ShowWindowData showData = new()
            {
                contextData = new ItemPopUpData()
                {
                    Item = item,
                    ItemContainerType = ItemContainerType.Bag
                }
            };
            self.ShowWindow<DlgItemPopUp>(showData);
        }
    }
}