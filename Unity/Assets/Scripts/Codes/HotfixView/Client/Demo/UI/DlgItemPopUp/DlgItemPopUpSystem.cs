using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgItemPopUp))]
    [FriendOf(typeof(EquipInfoComponent))]
    [FriendOf(typeof(AttributeEntry))]
    [FriendOf(typeof(ItemPopUpData))]
    public static class DlgItemPopUpSystem
    {
        private static void RefreshInfo(this DlgItemPopUp self, Item item, ItemContainerType itemContainerType)
        {
            self.ItemId = item.Id;
            self.ItemContainerType = itemContainerType;

            self.View.EI_IconImage.overrideSprite = IconHelper.LoadIconSprite("Icons", item.Config.Icon);
            self.View.EI_QualityImage.color = item.ItemQualityColor();
            self.View.ET_NameText.text = item.Config.Name;
            self.View.ET_DescText.text = item.Config.Desc;
            int sellPrice = item.Config.SellBasePrice;
            int score = 0;

            if (item.Config.Type == (int)ItemType.Prop)
            {
                self.View.EB_EquipButton.SetVisible(false);
                self.View.EB_UnEquipButton.SetVisible(false);
                self.View.EB_SellButton.SetVisible(false);
                self.View.EL_EntrysLoopVerticalScrollRect.SetVisible(true, 0);
                self.View.EB_SellButton.SetVisible(itemContainerType == ItemContainerType.Bag);
            }
            else
            {
                score = item.GetComponent<EquipInfoComponent>().Score;
                int count = item.GetComponent<EquipInfoComponent>().EntryList.Count;
                self.AddUIScrollItems(ref self.ScrollItemEntries, count);
                self.View.EL_EntrysLoopVerticalScrollRect.SetVisible(true, count);

                self.View.EB_EquipButton.SetVisible(itemContainerType == ItemContainerType.Bag);
                self.View.EB_UnEquipButton.SetVisible(itemContainerType == ItemContainerType.RoleInfo);
                self.View.EB_SellButton.SetVisible(itemContainerType == ItemContainerType.Bag);
            }
            self.View.ET_EvaluationTextMeshProUGUI.text = $"评分:{score,8}  出售价格:{sellPrice,9}";
        }

        public static void RegisterUIEvent(this DlgItemPopUp self)
        {
            self.RegisterCloseEvent<DlgItemPopUp>(self.View.EB_CloseButton);
            self.View.EL_EntrysLoopVerticalScrollRect.AddItemRefreshListener(self.OnEntryLoopHandler);
            self.View.EB_EquipButton.AddListenerAsync(self.OnClickEquip);
            self.View.EB_UnEquipButton.AddListenerAsync(self.OnClickUnEquip);
            self.View.EB_SellButton.AddListenerAsync(self.OnClickSell);
        }

        public static void ShowWindow(this DlgItemPopUp self, Entity contextData = null)
        {
            var itemPopUpData = contextData as ItemPopUpData;
            self.RefreshInfo(itemPopUpData.Item, itemPopUpData.ItemContainerType);
        }

        public static void HideWindow(this DlgItemPopUp self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemEntries);
        }

        #region 按钮响应

        public static void OnEntryLoopHandler(this DlgItemPopUp self, Transform transform, int index)
        {
            Scroll_Item_Entry scrollItemEntry = self.ScrollItemEntries[index].BindTrans(transform);
            Item item = ItemHelper.GetItem(self.ClientScene(), self.ItemId, self.ItemContainerType);
            AttributeEntry entry = item.GetComponent<EquipInfoComponent>().EntryList[index];
            scrollItemEntry.ET_EntryNameText.text = PlayerNumericConfigCategory.Instance.Get(entry.AttributeType).Name + ":";
            bool isPrcent = PlayerNumericConfigCategory.Instance.Get(entry.AttributeType).isPrecent > 0;
            scrollItemEntry.ET_EntryValueText.text = $"+{(isPrcent ? $"{entry.AttributeValue / 10000.0f:0.00}%" : entry.AttributeValue.ToString())}";
        }

        public static async ETTask OnClickEquip(this DlgItemPopUp self)
        {
            try
            {
                int errorCode = await ItemApplyHelper.EquipItem(self.ClientScene(), self.ItemId);

                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.ClientScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_ItemPopUp);
                self.ClientScene().GetComponent<UIComponent>().GetDlgLogic<DlgBag>().Refresh();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnClickUnEquip(this DlgItemPopUp self)
        {
            try
            {
                int errorCode = await ItemApplyHelper.UnloadEquipItem(self.ClientScene(), self.ItemId);

                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.ClientScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_ItemPopUp);
                self.ClientScene().GetComponent<UIComponent>().GetDlgLogic<DlgRoleInfo>().RefreshEquipShowItems();
                self.ClientScene().GetComponent<UIComponent>().GetDlgLogic<DlgRoleInfo>().Refresh();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnClickSell(this DlgItemPopUp self)
        {
            try
            {
                int errorCode = await ItemApplyHelper.SellBagItem(self.ClientScene(), self.ItemId);

                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.ClientScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_ItemPopUp);
                self.ClientScene().GetComponent<UIComponent>().GetDlgLogic<DlgBag>().Refresh();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        #endregion 按钮响应
    }
}