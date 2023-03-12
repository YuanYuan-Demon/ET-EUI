﻿namespace ET
{
    [FriendClass(typeof(Scroll_Item_BagItem))]
    [FriendClass(typeof(Item))]
    [FriendClass(typeof(BagComponent))]
    public static class Scroll_Item_bagItemSystem
    {
        public static void Refresh(this Scroll_Item_BagItem self, long id)
        {
            Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(id);

            self.EI_IconImage.overrideSprite = IconHelper.LoadIconSprite("Icons", item.Config.Icon);
            self.EI_QualityImage.color = item.ItemQualityColor();
            self.EB_SelectButton.AddListenerWithId(self.OnShowItemEntryPopUpHandler, id);
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_BagItem self, long Id)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ItemPopUp);
            Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(Id);
            self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgItemPopUp>().RefreshInfo(item, ItemContainerType.Bag);
        }
    }
}