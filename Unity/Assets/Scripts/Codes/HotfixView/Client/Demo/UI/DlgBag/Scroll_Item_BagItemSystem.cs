using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_BagItem))]
    [FriendOf(typeof (Item))]
    [FriendOf(typeof (BagComponent))]
    public static class Scroll_Item_BagItemSystem
    {
        public static void Refresh(this Scroll_Item_BagItem self, long id)
        {
            var item = self.ClientScene().GetComponent<BagComponent>().GetItemById(id);
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
            self.EB_Select_Button.AddListener(() => self.OnClickItem(item.Config));
        }

        private static void OnClickItem(this Scroll_Item_BagItem self, ItemConfig itemConfig)
        {
            var showData = new PopItemData() { ItemConfig = itemConfig, ClickPosition = Input.mousePosition };
            UIComponent.Instance.ShowWindow<DlgPopItem>(showData);
        }
    }
}