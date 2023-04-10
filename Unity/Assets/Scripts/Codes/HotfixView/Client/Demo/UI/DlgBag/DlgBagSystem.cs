using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgBag))]
    [FriendOf(typeof (BagComponent))]
    public static class DlgBagSystem
    {
        public static void RegisterUIEvent(this DlgBag self)
        {
            self.RegisterCloseEvent<DlgBag>(self.View.EB_Close_Button);
            self.View.ETG_TabButton_ToggleGroup.AddListener(self.OnSelectTabGroup);
            self.View.EL_BagItem_LoopVerticalScrollRect.AddItemRefreshListener(self.OnRefreshBagItem);
            self.View.EB_Sort_Button.AddListener(self.OnSortBagItem);
        }

        public static void ShowWindow(this DlgBag self, ShowWindowData contextData = null) => self.View.ET_All_Toggle.IsSelected(true);

        public static void HideWindow(this DlgBag self) => self.RemoveUIScrollItems(ref self.ScrollItemBagItems);

        public static void OnSelectTabGroup(this DlgBag self, int index)
        {
            self.BagTab = (ItemType)index;
            self.Refresh();
        }

        public static void Refresh(this DlgBag self)
        {
            switch (self.BagTab)
            {
                case ItemType.All:
                    self.ItemList = self.ClientScene().GetComponent<BagComponent>().AllItemsDict.Values.ToList();
                    break;

                case ItemType.Equip:
                case ItemType.Consumable:
                case ItemType.Material:
                    self.ClientScene().GetComponent<BagComponent>().ItemTypeMap.TryGetValue(self.BagTab, out self.ItemList);
                    break;
            }

            if (self.ItemList != null && self.ItemList.Count != 0)
            {
                self.AddUIScrollItems(ref self.ScrollItemBagItems, self.ItemList.Count);
                self.View.EL_BagItem_LoopVerticalScrollRect.SetVisible(true, self.ItemList.Count);
            }
            else
            {
                self.View.EL_BagItem_LoopVerticalScrollRect.SetVisible(true);
            }
        }

        public static void OnRefreshBagItem(this DlgBag self, Transform transform, int index)
        {
            Scroll_Item_BagItem scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemBagItem.Refresh(self.ItemList[index]);
        }

        public static void OnSortBagItem(this DlgBag self)
        {
        }
    }
}