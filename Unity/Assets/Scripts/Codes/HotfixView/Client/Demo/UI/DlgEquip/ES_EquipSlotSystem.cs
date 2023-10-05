using System;
using ET.Client.EventType;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ES_EquipSlot))]
    public static class ES_EquipSlotSystem
    {
        public static void Init(this ES_EquipSlot self, EquipPosition equipPosition)
        {
            self.EquipPosition = equipPosition;
            self.RefreshEquip();
            self.EB_Click_Button.onClick.AddListener(self.OnDoubleClick);
        }

        public static void RefreshEquip(this ES_EquipSlot self)
        {
            var ec = self.ClientScene().GetComponent<EquipmentsComponent>();
            var equip = ec.GetItemByPosition(self.EquipPosition);
            if (equip != null)
            {
                self.EI_Icon_Image.enabled = true;
                self.Equip = equip;
                self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", equip.Config.Icon);
            }
            else
            {
                self.Equip = null;
                self.EI_Icon_Image.enabled = false;
            }
        }

        private static async void OnDoubleClick(this ES_EquipSlot self)
        {
            var clickTime = TimeHelper.ClientNow();
            try
            {
                //两百毫秒内鼠标双击双击
                if (clickTime - self.LastClick < 200)
                {
                    var equipPosition = self.EquipPosition;
                    var errorCode = await ItemApplyHelper.UnEquipItem(self.ClientScene(), self.Equip.Id);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        Log.Error(errorCode.ToString());
                        return;
                    }

                    EventSystem.Instance.PublishAsync(self.ClientScene(), new ChangeEquipItem() { EquipPosition = equipPosition }, true).Coroutine();
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
    }
}