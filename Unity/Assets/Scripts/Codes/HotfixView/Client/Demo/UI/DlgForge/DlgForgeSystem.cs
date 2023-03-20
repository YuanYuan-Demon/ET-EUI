using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgForge))]
    public static class DlgForgeSystem
    {
        #region 定时任务

        [Invoke(TimerInvokeType.MakeQueueUI)]
        public class MakeQueueUITimer : ATimer<DlgForge>
        {
            protected override void Run(DlgForge t)
            {
                t?.RefreshMakeQueue();
            }
        }

        #endregion 定时任务

        public static void RegisterUIEvent(this DlgForge self)
        {
            self.RegisterCloseEvent<DlgForge>(self.View.EB_CloseButton);
            self.View.EL_ProductionsLoopVerticalScrollRect.AddItemRefreshListener(self.OnProductionRefreshHandler);
        }

        #region UI显示

        private static void Refresh(this DlgForge self)
        {
            self.RefreshMakeQueue();
            self.RefreshProduction();
            self.RefreshMaterailCount();
        }

        private static void RefreshProduction(this DlgForge self)
        {
            int unitLevel = self.GetMyNumericComponent().GetAsInt(NumericType.Level);
            int count = ForgeProductionConfigCategory.Instance.GetProductionConfigCount(unitLevel);
            self.AddUIScrollItems(ref self.ScrollItemProductions, count);
            self.View.EL_ProductionsLoopVerticalScrollRect.SetVisible(true, count);
        }

        private static void RefreshMaterailCount(this DlgForge self)
        {
            NumericComponent numericComponent = self.GetMyNumericComponent();
            int ironCount = numericComponent.GetAsInt(NumericType.IronStone);
            int furCount = numericComponent.GetAsInt(NumericType.Fur);
            self.View.ET_MaterialTextMeshProUGUI.SetText($"精铁:{ironCount,8}    毛皮:{furCount,8}");
        }

        public static void ShowWindow(this DlgForge self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void HideWindow(this DlgForge self)
        {
            TimerComponent.Instance.Remove(ref self.MakeQueueTimer);
            self.RemoveUIScrollItems(ref self.ScrollItemProductions);
        }

        public static void OnProductionRefreshHandler(this DlgForge self, Transform transform, int index)
        {
            Scroll_Item_Production scrollItemProduction = self.ScrollItemProductions[index].BindTrans(transform);
            NumericComponent numericComponent = self.GetMyNumericComponent();
            int unitLevel = numericComponent.GetAsInt(NumericType.Level);
            var config = ForgeProductionConfigCategory.Instance.GetProductionByLevelIndex(unitLevel, index);

            scrollItemProduction.ES_EquipItem.RefreshShowItem(config.ItemConfigId);
            scrollItemProduction.ET_NameTextMeshProUGUI.SetText(ItemConfigCategory.Instance.Get(config.ItemConfigId).Name);
            string materialType = config.ConsumId == NumericType.IronStone ? "精铁" : "皮革";
            scrollItemProduction.ET_CostTextMeshProUGUI.SetText($"{materialType}: {config.ConsumeCount,8}");

            int materialCount = numericComponent.GetAsInt(config.ConsumId);
            scrollItemProduction.EB_MakeButton.interactable = materialCount >= config.ConsumeCount;
            scrollItemProduction.EB_MakeButton.AddListenerAsync(() => OnStartProductionHandler(self, config.Id));
        }

        public static void RefreshMakeQueue(this DlgForge self)
        {
            ForgeComponent forgeComponent = self.ClientScene().GetComponent<ForgeComponent>();

            Production production = forgeComponent.GetProductionByIndex(0);
            self.View.ES_MakeQueue1.Refresh(production);

            production = forgeComponent.GetProductionByIndex(1);
            self.View.ES_MakeQueue2.Refresh(production);

            TimerComponent.Instance.Remove(ref self.MakeQueueTimer);

            int count = forgeComponent.GetMakingProductionQueueCount();
            if (count > 0)
            {
                //每过1秒刷新一次状态
                TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 1000, TimerInvokeType.MakeQueueUI, self);
            }
        }

        #endregion UI显示

        #region UI交互

        private static async ETTask OnStartProductionHandler(this DlgForge self, int productionConfigId)
        {
            try
            {
                int errorCode = await ForgeHelper.StartProduction(self.ClientScene(), productionConfigId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.Refresh();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        #endregion UI交互
    }
}