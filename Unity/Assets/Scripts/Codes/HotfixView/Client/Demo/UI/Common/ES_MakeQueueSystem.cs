//using System;

//namespace ET.Client
//{
//    [FriendOf(typeof(ET.Production))]
//    [FriendOf(typeof(ET.ES_MakeQueue))]
//    public static class ES_MakeQueueSystem
//    {
//        public static void Refresh(this ES_MakeQueue self, Production production)
//        {
//            if (production == null || !production.IsMakingState())
//            {
//                self.uiTransform.SetVisible(false);
//                return;
//            }

//            self.uiTransform.SetVisible(true);

//            int itemConfigId = ForgeProductionConfigCategory.Instance.Get(production.ConfigId).ItemConfigId;
//            self.ES_EquipItem.RefreshShowItem(itemConfigId);

//            bool isCanReceive = production.IsMakeTimeOver() && production.IsMakingState();

//            self.ET_MakeTimeTextMeshProUGUI.SetText(production.GetRemainingTimeStr());
//            self.ED_ProcessBarSlider.value = production.GetProcess();

//            self.ED_ProcessBarSlider.SetVisible(!isCanReceive);
//            self.ET_MakeTimeTextMeshProUGUI.SetVisible(!isCanReceive);
//            self.ET_TipTextMeshProUGUI.SetText(isCanReceive ? "制作完成" : "距离制作完成还有");
//            self.EB_GetButton.SetVisible(isCanReceive);
//            self.EB_GetButton.AddListenerAsync(() => OnReceiveButtonHandler(self, production.Id));
//        }

//        public static async ETTask OnReceiveButtonHandler(this ES_MakeQueue self, long productionId)
//        {
//            try
//            {
//                int errorCode = await ForgeHelper.ReceivedProductionItem(self.ZoneScene(), productionId);
//                if (errorCode != ErrorCode.ERR_Success)
//                {
//                    Log.Error(errorCode.ToString());
//                    return;
//                }
//                self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgForge>().RefreshMakeQueue();
//            }
//            catch (Exception e)
//            {
//                Log.Error(e.ToString());
//            }
//        }
//    }
//}