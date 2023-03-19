using UnityEngine;

namespace ET.Client
{
    public static class ES_EquipItemSystem
    {
        public static void RegisterEventHandler(this ES_EquipItem self, EquipPosition equipPosition)
        {
            self.EB_SelectButton.AddListenerWithId(self.OnSelectedHandler, (int)equipPosition);
        }

        public static void OnSelectedHandler(this ES_EquipItem self, int equipPosition)
        {
            Item item = self.ClientScene().GetComponent<EquipmentsComponent>().GetItemByPosition((EquipPosition)equipPosition);
            if (null == item)
            {
                return;
            }
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ItemPopUp);
            //self.ClientScene().GetComponent<UIComponent>().GetDlgLogic<DlgItemPopUp>().RefreshInfo(item, ItemContainerType.RoleInfo);
        }

        public static void RefreshShowItem(this ES_EquipItem self, EquipPosition equipPosition)
        {
            Item item = self.ClientScene().GetComponent<EquipmentsComponent>().GetItemByPosition(equipPosition);
            if (item is null)
            {
                self.EI_IconImage.sprite = null;
                self.EI_IconImage.overrideSprite = null;
                self.EI_QualityImage.color = Color.grey;
                self.ET_LabelTextMeshProUGUI.enabled = true;
            }
            else
            {
                self.EI_IconImage.overrideSprite = IconHelper.LoadIconSprite("Icons", item.Config.Icon);
                self.EI_QualityImage.color = item.ItemQualityColor();
                self.ET_LabelTextMeshProUGUI.enabled = false;
            }
        }

        public static void RefreshShowItem(this ES_EquipItem self, int itemConfigId)
        {
            self.EI_QualityImage.color = Color.grey;
            self.EI_IconImage.overrideSprite = IconHelper.LoadIconSprite("Icons", ItemConfigCategory.Instance.Get(itemConfigId).Icon);
            self.ET_LabelTextMeshProUGUI.enabled = false;
        }
    }
}