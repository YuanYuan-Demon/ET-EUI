using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRank))]
    [FriendOfAttribute(typeof(ET.RankInfo))]
    public static class DlgRankSystem
    {
        #region 定时任务

        [Invoke(TimerInvokeType.RankUI)]
        public class RankUITimer : ATimer<DlgRank>
        {
            protected override void Run(DlgRank t)
            {
                t?.RefreshRankInfo().Coroutine();
            }
        }

        #endregion 定时任务

        public static void RegisterUIEvent(this DlgRank self)
        {
            self.RegisterCloseEvent<DlgRank>(self.View.EB_CloseButton);
            self.View.EL_RankLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankItemLoopHandler);
        }

        public static void ShowWindow(this DlgRank self, Entity contextData = null)
        {
            self.RefreshRankInfo().Coroutine();
            self.Timer = TimerComponent.Instance.NewRepeatedTimer(5000, TimerInvokeType.RankUI, self);
        }

        public static void HideWindow(this DlgRank self, Entity contextData = null)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
        }

        public static void OnRankItemLoopHandler(this DlgRank self, Transform transform, int index)
        {
            Scroll_Item_Rank scrollItemRank = self.ScrollItemRanks[index].BindTrans(transform);
            RankInfo rankInfo = self.ClientScene().GetComponent<RankComponent>().GetRankInfoByIndex(index);

            int order = index + 1;
            scrollItemRank.ET_RankTextMeshProUGUI.SetText($"第 {order} 名");
            scrollItemRank.ET_PlayerNameTextMeshProUGUI.SetText(rankInfo.Name);
            scrollItemRank.ET_LevelTextMeshProUGUI.SetText($"Lv.{rankInfo.Level}");
        }

        public static async ETTask RefreshRankInfo(this DlgRank self)
        {
            try
            {
                Scene ZoneScene = self.ClientScene();
                int errorCode = await RankHelper.GetRankInfo(ZoneScene);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                if (!ZoneScene.GetComponent<UIComponent>().IsWindowVisible(WindowID.WindowID_Rank))
                {
                    return;
                }

                int count = self.ClientScene().GetComponent<RankComponent>().GetRankCount();
                self.AddUIScrollItems(ref self.ScrollItemRanks, count);
                self.View.EL_RankLoopVerticalScrollRect.SetVisible(true, count);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}