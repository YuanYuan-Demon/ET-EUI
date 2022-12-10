using System;
using DG.Tweening;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(DlgAdventure))]
    public static class DlgAdventureSystem
    {
        public static void RegisterUIEvent(this DlgAdventure self)
        {
            self.RegisterCloseEvent<DlgAdventure>(self.View.EB_CloseButton);
            self.View.EL_LevelListLoopVerticalScrollRect.AddItemRefreshListener((transform, index) => self.OnBattleLevelItemRefresh(transform, index));
        }

        public static void ShowWindow(this DlgAdventure self, Entity contextData = null)
        {
            self.View.EG_PanelRectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0);
            self.View.EG_PanelRectTransform.DOScale(Vector3.one, 0.3f).onComplete += () => self.Refresh();
        }

        public static void HideWindow(this DlgAdventure self)
        {
            self.View.EG_PanelRectTransform.DOScale(Vector3.zero, 0.3f);
            self.View.EL_LevelListLoopVerticalScrollRect.SetVisible(false);
            self.RemoveUIScrollItems(ref self.ScrollItems_Level);
        }

        public static void Refresh(this DlgAdventure self)
        {
            int count = BattleLevelConfigCategory.Instance.GetAll().Count;
            self.AddUIScrollItems(ref self.ScrollItems_Level, count);
            self.View.EL_LevelListLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void OnBattleLevelItemRefresh(this DlgAdventure self, Transform transform, int index)
        {
            var itemLevel = self.ScrollItems_Level[index].BindTrans(transform);
            var config = BattleLevelConfigCategory.Instance.GetByIndex(index);
            var unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            var numericComponent = unit.GetComponent<NumericComponent>();
            int unitLevel = numericComponent.GetAsInt(NumericType.Level);
            bool isInAdventure = numericComponent.GetAsInt(NumericType.AdventureStatus) != 0;
            bool levelEnough = unitLevel >= config.MiniEnterLevel[0];

            itemLevel.EB_StartButton.SetVisible(levelEnough && !isInAdventure);
            itemLevel.ET_Tip_InAdventureText.SetVisible(levelEnough && isInAdventure);
            itemLevel.ET_Tip_LevelNotEnoughText.SetVisible(!levelEnough);
            itemLevel.ET_LevelNameText.text = config.Name;
            itemLevel.ET_LevelLimitText.text = $"Lv.{config.MiniEnterLevel[0]} ~ Lv.{config.MiniEnterLevel[1]}";

            itemLevel.EB_StartButton.AddListenerAsync(() => { return self.OnStartGameLevelClickHandler(config.Id); });
        }

        public static async ETTask OnStartGameLevelClickHandler(this DlgAdventure self, int levelId)
        {
            try
            {
                int errorCode = await AdventureHelper.RequestStartGameLevel(self.ZoneScene(), levelId);
                if (errorCode != ErrorCode.ERR_Success)
                    return;
                self.Refresh();
                Game.EventSystem.Publish(new EventType.StartGameLevel { ZoneScene = self.ZoneScene() });
                //self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Adventure);
                //self.ZoneScene().CurrentScene().GetComponent<ad>
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}