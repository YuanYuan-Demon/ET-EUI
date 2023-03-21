using System;
using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof(Production))]
    [FriendOf(typeof(ES_MakeQueue))]    //[FriendOf(typeof(ES_MakeQueue))]
    public static class ES_MakeQueueSystem
    {
        private static async ETTask OnReceiveButtonHandler(this ES_MakeQueue self, long productionId)
        {
            try
            {
                int errorCode = await ForgeHelper.ReceivedProductionItem(self.ClientScene(), productionId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                EventSystem.Instance.Publish(self.ClientScene(), new ReceiveProduct());
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static void Refresh(this ES_MakeQueue self, Production production)
        {
            if (production == null || !production.IsMakingState())
            {
                self.uiTransform.SetVisible(false);
                return;
            }

            self.uiTransform.SetVisible(true);

            int itemConfigId = ForgeProductionConfigCategory.Instance.Get(production.ConfigId).ItemConfigId;
            self.ES_EquipItem.RefreshShowItem(itemConfigId);

            bool isCanReceive = production.IsMakeTimeOver() && production.IsMakingState();

            self.ED_ProcessBarSlider.value = production.GetProcess();

            self.ED_ProcessBarSlider.SetVisible(!isCanReceive);
            self.ET_TipTextMeshProUGUI.alignment = isCanReceive ? TMPro.TextAlignmentOptions.Right : TMPro.TextAlignmentOptions.Flush;
            self.ET_TipTextMeshProUGUI.SetText(isCanReceive ? "制作完成" : $"剩余时间: {production.GetRemainingTimeStr()}");
            self.EB_GetButton.SetVisible(isCanReceive);
            self.EB_GetButton.AddListenerAsync(() => OnReceiveButtonHandler(self, production.Id));
        }
    }
}