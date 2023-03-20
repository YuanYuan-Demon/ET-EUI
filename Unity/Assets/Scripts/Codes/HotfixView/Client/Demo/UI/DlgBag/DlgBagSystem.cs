using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgBag))]
    [FriendOfAttribute(typeof(ET.BagComponent))]
    public static class DlgBagSystem
    {
        public static void RegisterUIEvent(this DlgBag self)
        {
            self.RegisterCloseEvent<DlgBag>(self.View.EB_CloseButton);
            self.View.ETG_TabGroupToggleGroup.AddListener(self.OnSelectTabGroup);
            self.View.EL_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRefreshBagItem);
        }

        public static void ShowWindow(this DlgBag self, Entity contextData = null)
        {
            //self.OnSelectTabGroup(0);
            self.View.ET_WeaponToggle.IsSelected(true);
        }

        public static void HideWindow(this DlgBag self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemBagItems);
        }

        public static void OnSelectTabGroup(this DlgBag self, int index)
        {
            self.CurrentItemType = (ItemType)index;
            self.CurrentPageIndex = 0;
            self.Refresh();
        }

        public static void Refresh(this DlgBag self)
        {
            self.RefreshItems();
            //self.RefeshPageIndexInfo();
        }

        public static void RefreshItems(this DlgBag self)
        {
            if (self.ClientScene().GetComponent<BagComponent>().ItemsMap.TryGetValue((int)self.CurrentItemType, out List<Item> itemList))
            {
                self.AddUIScrollItems(ref self.ScrollItemBagItems, itemList.Count);
                self.View.EL_BagItemsLoopVerticalScrollRect.SetVisible(true, itemList.Count);
            }
        }

        public static void OnRefreshBagItem(this DlgBag self, Transform transform, int index)
        {
            self.ClientScene().GetComponent<BagComponent>().ItemsMap.TryGetValue((int)self.CurrentItemType, out List<Item> itemList);
            var scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);

            index = (self.CurrentPageIndex * 30) + index;
            scrollItemBagItem.Refresh(itemList[index].Id);
        }
    }
}