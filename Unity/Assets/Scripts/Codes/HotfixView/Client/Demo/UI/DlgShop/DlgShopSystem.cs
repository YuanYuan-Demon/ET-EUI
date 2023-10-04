using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgShop))]
    public static class DlgShopSystem
    {
        public static void RegisterUIEvent(this DlgShop self)
        {
            self.RegisterCloseEvent<DlgShop>(self.View.EB_Close_Button);
            self.View.ETG_TabButton_ToggleGroup.AddListener(self.OnSelectTabGroup);
            self.View.ElShopItemLoopVList.AddItemRefreshListener(self.OnRefreshShopItem);
            self.View.EB_Buy_Button.onClick.AddListener(self.OnClickBuy);
        }

        public static void ShowWindow(this DlgShop self, ShowWindowData contextData = null) => self.View.ET_All_Toggle.IsSelected(true);

        public static void HideWindow(this DlgShop self) => self.RemoveUIScrollItems(ref self.ScrollItemShopItems);

        public static async void OnClickBuy(this DlgShop self)
        {
            var response = await ShopHelper.BuyItem(self.ClientScene(), self.SelectItem.ConfigId, self.SelectItem.Count);
            if (response?.Error != ErrorCode.ERR_Success)
            {
                Log.Error(response.ToString());
                UIComponent.Instance.ShowErrorBox(response.Message);
                return;
            }

            UIComponent.Instance.ShowInfoBox("购买成功");
        }

        public static void OnSelectTabGroup(this DlgShop self, int index)
        {
            self.ShopTab = (ItemType)index;
            self.Refresh();
        }

        public static void Refresh(this DlgShop self)
        {
            var itemConfigs = ItemConfigCategory.Instance.GetAll().Values;
            self.ConfigList.Clear();
            if (self.ShopTab == ItemType.All)
            {
                self.ConfigList.AddRange(itemConfigs);
            }
            else
            {
                self.ConfigList.AddRange(itemConfigs.Where(config => config.Type == self.ShopTab));
            }

            if (self.ConfigList != null && self.ConfigList.Count != 0)
            {
                self.AddUIScrollItems(ref self.ScrollItemShopItems, self.ConfigList.Count);
                self.View.ElShopItemLoopVList.SetVisible(true, self.ConfigList.Count);
            }
        }

        public static void OnRefreshShopItem(this DlgShop self, Transform transform, int index)
        {
            var scrollItemBagItem = self.ScrollItemShopItems[index].BindTrans(transform);
            scrollItemBagItem.Refresh(self.ConfigList[index]);
        }
    }
}