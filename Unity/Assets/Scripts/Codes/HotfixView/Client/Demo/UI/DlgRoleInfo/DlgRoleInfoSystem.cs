using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoleInfo))]
    public static class DlgRoleInfoSystem
    {
        private static async ETTask OnClickConfirmAddPoint(this DlgRoleInfo self, bool isConfirm)
        {
            var addAttributeEvent = new EventType.AddAttributeConfirm()
            {
                ZoneScene = self.ClientScene(),
                ConfirmAdd = isConfirm,
                Attributes = self.AddingAttributes
            };
            await EventSystem.Instance.PublishAsync(self.ClientScene(), addAttributeEvent);
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

        public static void RegisterUIEvent(this DlgRoleInfo self)
        {
            self.RegisterCloseEvent<DlgRoleInfo>(self.View.EB_CloseButton);

            self.View.ES_AddAttribute1.RegisterNumericType(NumericType.Power);
            self.View.ES_AddAttribute2.RegisterNumericType(NumericType.PhysicalStrength);
            self.View.ES_AddAttribute3.RegisterNumericType(NumericType.Agile);
            self.View.ES_AddAttribute4.RegisterNumericType(NumericType.Spirit);

            self.View.EL_AttributeInfoLoopVerticalScrollRect.AddItemRefreshListener(
                (transform, index) => self.OnAttributeItemRefreshHandler(transform, index));

            self.View.EB_UpLevelButton.AddListenerAsync(self.OnClickUpRoleLevel);
            self.View.EB_ConfirmAddAttributeButton.AddListenerAsync(() => OnClickConfirmAddPoint(self, true));
            self.View.EB_CancelAddAttributeButton.AddListenerAsync(() => OnClickConfirmAddPoint(self, false));
            self.View.EB_CloseButton.onClick.AddListener(async () => await OnClickConfirmAddPoint(self, false));

            self.View.ES_Equip_Helmet.RegisterEventHandler(EquipPosition.Head);
            self.View.ES_Equip_Armor.RegisterEventHandler(EquipPosition.Clothes);
            self.View.ES_Equip_Shoe.RegisterEventHandler(EquipPosition.Shoes);
            self.View.ES_Equip_Ring.RegisterEventHandler(EquipPosition.Ring);
            self.View.ES_Equip_Offhand.RegisterEventHandler(EquipPosition.Shield);
            self.View.ES_Equip_Weapon.RegisterEventHandler(EquipPosition.Weapon);

            RedDotHelper.AddRedDotNodeView(self.ClientScene(), RedDotType.UpLevelButton, self.View.EB_UpLevelButton.gameObject, Vector3.one, new Vector3(90, 30, 0));
            RedDotHelper.AddRedDotNodeView(self.ClientScene(), RedDotType.AddAttribute, self.View.ET_AttributePointsText.gameObject, Vector3.one, new Vector3(150, 22, 0));
        }

        public static void OnUnLoadWindow(this DlgRoleInfo self)
        {
            RedDotHelper.RemoveRedDotView(self.ClientScene(), RedDotType.UpLevelButton, out _);
            RedDotHelper.RemoveRedDotView(self.ClientScene(), RedDotType.AddAttribute, out _);
        }

        public static void ShowWindow(this DlgRoleInfo self, Entity contextData = null)
        {
            self.Refresh();
            self.RefreshEquipShowItems();
        }

        public static void RefreshEquipShowItems(this DlgRoleInfo self)
        {
            self.View.ES_Equip_Helmet.RefreshShowItem(EquipPosition.Head);
            self.View.ES_Equip_Armor.RefreshShowItem(EquipPosition.Clothes);
            self.View.ES_Equip_Shoe.RefreshShowItem(EquipPosition.Shoes);
            self.View.ES_Equip_Ring.RefreshShowItem(EquipPosition.Ring);
            self.View.ES_Equip_Weapon.RefreshShowItem(EquipPosition.Weapon);
            self.View.ES_Equip_Offhand.RefreshShowItem(EquipPosition.Shield);
        }

        public static void Refresh(this DlgRoleInfo self)
        {
            //刷新基础属性
            self.View.ES_AddAttribute1.Refresh(NumericType.Power, self.IsDirtyAttribute(NumericType.Power));
            self.View.ES_AddAttribute2.Refresh(NumericType.PhysicalStrength, self.IsDirtyAttribute(NumericType.PhysicalStrength));
            self.View.ES_AddAttribute3.Refresh(NumericType.Agile, self.IsDirtyAttribute(NumericType.Agile));
            self.View.ES_AddAttribute4.Refresh(NumericType.Spirit, self.IsDirtyAttribute(NumericType.Spirit));

            //刷新可用属性点
            NumericComponent numericComponent = self.ClientScene().GetMyNumericComponent();
            //dlg.View..text = "战力值:" + numericComponent.GetAsLong(NumericType.CombatEffectiveness).ToString();
            int points = numericComponent.GetAsInt(NumericType.AttributePoints);
            self.View.ET_AttributePointsText.text = $"剩余点数: {points,3}";
            self.SetVisibleAddPointButton(points > 0);
            self.SetVisibleAddPointConfirmButton(self.AddingAttributes.Count != 0);

            int count = PlayerNumericConfigCategory.Instance.GetShowConfigCount();
            self.AddUIScrollItems(ref self.ScrollItem_Attribute, count);
            self.View.EL_AttributeInfoLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void OnAttributeItemRefreshHandler(this DlgRoleInfo self, Transform transform, int index)
        {
            var scrollItemAttribute = self.ScrollItem_Attribute[index].BindTrans(transform);
            PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.GetConfigByIndex(index);
            scrollItemAttribute.ET_AttributeNameText.text = $"{config.Name}: ";

            NumericComponent numericComponent = self.ClientScene().GetMyNumericComponent();
            string value = config.isPrecent == 0 ?
                numericComponent.GetAsLong(config.Id).ToString() :
                $"{numericComponent.GetAsFloat(config.Id):0.00}%";
            //判断数值是否通过加点发生变动
            if (self.IsDirtyAttribute(config.Id)) value = $"<color=#29BA29>{value}</color>";
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

        public static async ETTask OnClickUpRoleLevel(this DlgRoleInfo self)
        {
            try
            {
                int errorCode = await NumericHelper.ReqeustUpRoleLevel(self.ClientScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    return;
                }
            }
            catch (System.Exception e)
            {
                Log.Error(e);
            }
        }
    }
}