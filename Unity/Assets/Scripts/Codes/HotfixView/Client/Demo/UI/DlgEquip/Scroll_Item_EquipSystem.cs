using System;
using ET.Client.EventType;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.Scroll_Item_Equip))]
    public static class Scroll_Item_EquipSystem
    {
        private static async void OnDoubleClick(this Scroll_Item_Equip self)
        {
            var clickTime = TimeHelper.ClientNow();
            try
            {
                //两百毫秒内鼠标双击双击
                if (clickTime - self.LastClick < 200)
                {
                    EquipPosition equipPosition = (EquipPosition)self.Equip.EquipConfig.EquipPosition;
                    int errorCode = await ItemApplyHelper.EquipItem(self.ClientScene(), self.DataId);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        Log.Error(errorCode.ToString());
                        return;
                    }

                    EventSystem.Instance.Publish(self.ClientScene(), new EquipItem
                    {
                        EquipPosition = equipPosition,
                    });
                    UIComponent.Instance.GetDlgLogic<DlgEquip>().RefreshEquipList();
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            finally
            {
                self.LastClick = clickTime;
            }
        }

        public static void Refresh(this Scroll_Item_Equip self, Item equip)
        {
            if (!equip.IsEquip)
                throw new Exception("当前道具不是装备");

            self.Equip = equip;
            var itemConfig = equip.Config;
            var equipConfig = equip.EquipConfig;

            self.DataId = equip.Id;
            self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", itemConfig.Icon);
            self.ET_Name_TextMeshProUGUI.text = itemConfig.Name;
            self.ET_Level_TextMeshProUGUI.text = $"Lv.{itemConfig.Level}";
            self.ET_Type_TextMeshProUGUI.text = Enum.GetName(typeof(EquipPosition), equipConfig.EquipPosition);

            self.EB_Select_Button.AddListener(self.OnDoubleClick);
        }
    }
}