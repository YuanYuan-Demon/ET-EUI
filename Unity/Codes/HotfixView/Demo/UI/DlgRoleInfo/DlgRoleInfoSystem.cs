﻿using UnityEngine;

namespace ET
{
    [FriendClass(typeof(DlgRoleInfo))]
    public static class DlgRoleInfoSystem
    {
        public static void RegisterUIEvent(this DlgRoleInfo self)
        {
            self.RegisterCloseEvent<DlgRoleInfo>(self.View.EB_CloseButton);

            self.View.ES_AddAttribute1.RegisterNumericType(NumericType.Power);
            self.View.ES_AddAttribute2.RegisterNumericType(NumericType.PhysicalStrength);
            self.View.ES_AddAttribute3.RegisterNumericType(NumericType.Agile);
            self.View.ES_AddAttribute4.RegisterNumericType(NumericType.Spirit);

            self.View.EL_AttributeInfoLoopVerticalScrollRect.AddItemRefreshListener(
                (transform, index) => self.OnAttributeItemRefreshHandler(transform, index));

            self.View.EB_ConfirmAddAttributeButton.AddListenerAsync(() => OnConfirmAddPoint(self, true));
            self.View.EB_CancelAddAttributeButton.AddListenerAsync(() => OnConfirmAddPoint(self, false));
            self.View.EB_CloseButton.onClick.AddListener(async () => await OnConfirmAddPoint(self, false));
        }

        public static void ShowWindow(this DlgRoleInfo self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void Refresh(this DlgRoleInfo self)
        {
            //刷新基础属性
            self.View.ES_AddAttribute1.Refresh(NumericType.Power, self.IsDirtyAttribute(NumericType.Power));
            self.View.ES_AddAttribute2.Refresh(NumericType.PhysicalStrength, self.IsDirtyAttribute(NumericType.PhysicalStrength));
            self.View.ES_AddAttribute3.Refresh(NumericType.Agile, self.IsDirtyAttribute(NumericType.Agile));
            self.View.ES_AddAttribute4.Refresh(NumericType.Spirit, self.IsDirtyAttribute(NumericType.Spirit));

            //刷新可用属性点
            NumericComponent numericComponent = UnitHelper.GetMyUnitNumericComponentFromCurScene(self.ZoneScene().CurrentScene());
            //dlg.View..text = "战力值:" + numericComponent.GetAsLong(NumericType.CombatEffectiveness).ToString();
            int points = numericComponent.GetAsInt(NumericType.AttributePoints);
            self.View.ET_AttributePointsText.text = $"剩余点数: {points:d3}";
            self.SetVisibleAddPointButton(points > 0);
            self.SetVisibleAddPointConfirmButton(self.AddingAttributes.Count != 0);

            int count = PlayerNumericConfigCategory.Instance.GetShowConfigCount();
            self.AddUIScrollItems(ref self.ScrollItemAttributes, count);
            self.View.EL_AttributeInfoLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void OnAttributeItemRefreshHandler(this DlgRoleInfo self, Transform transform, int index)
        {
            var scrollItemAttribute = self.ScrollItemAttributes[index].BindTrans(transform);
            PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.GetConfigByIndex(index);
            scrollItemAttribute.ET_AttributeNameText.text = $"{config.Name}: ";
            NumericComponent numericComponent = UnitHelper.GetMyUnitNumericComponentFromCurScene(self.ZoneScene().CurrentScene());
            string value = config.isPrecent == 0 ?
                numericComponent.GetAsLong(config.Id).ToString() :
                $"{numericComponent.GetAsFloat(config.Id):0.00}%";
            if (self.IsDirtyAttribute(config.Id))
                value = $"<color=#29BA29>{value}</color>";
            scrollItemAttribute.ET_AttributeValueText.text = value;
        }

        public static void SetVisibleAddPointButton(this DlgRoleInfo self, bool isShow)
        {
            self.View.ES_AddAttribute1.EB_AddAttributeButton.SetVisible(isShow);
            self.View.ES_AddAttribute2.EB_AddAttributeButton.SetVisible(isShow);
            self.View.ES_AddAttribute3.EB_AddAttributeButton.SetVisible(isShow);
            self.View.ES_AddAttribute4.EB_AddAttributeButton.SetVisible(isShow);
        }

        public static void SetVisibleAddPointConfirmButton(this DlgRoleInfo self, bool isShow)
        {
            self.View.EB_ConfirmAddAttributeButton.SetVisible(isShow);
            self.View.EB_CancelAddAttributeButton.SetVisible(isShow);
        }

        private static async ETTask OnConfirmAddPoint(this DlgRoleInfo self, bool isConfirm)
        {
            var addAttributeEvent = new EventType.AddAttributeConfirm()
            {
                ZoneScene = self.ZoneScene(),
                ConfirmAdd = isConfirm,
                Attributes = self.AddingAttributes
            };
            await Game.EventSystem.PublishAsync(addAttributeEvent);
            self.AddingAttributes.Clear();
            self.Refresh();
            //self.SetVisibleAddPointConfirmButton(false);
        }

        private static bool IsDirtyAttribute(this DlgRoleInfo self, int numericType)
        {
            switch (numericType)
            {
                case NumericType.Power:
                case NumericType.PhysicalStrength:
                case NumericType.Agile:
                case NumericType.Spirit:
                    return self.AddingAttributes.ContainsKey(numericType);

                case NumericType.DamageValue:
                case NumericType.MaxHp:
                case NumericType.Dodge:
                case NumericType.MaxMp:
                    return self.AddingAttributes.ContainsKey(NumericHelper.GetRelativeAttribute(numericType));

                default:
                    return false;
            }
        }
    }
}