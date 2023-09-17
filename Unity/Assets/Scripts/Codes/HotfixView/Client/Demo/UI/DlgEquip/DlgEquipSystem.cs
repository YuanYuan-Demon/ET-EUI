﻿using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgEquip))]
    [FriendOfAttribute(typeof(ET.BagComponent))]
    [FriendOfAttribute(typeof(ET.Client.RoleInfosComponent))]
    [FriendOfAttribute(typeof(ET.RoleInfo))]
    [FriendOfAttribute(typeof(ET.EquipmentsComponent))]
    public static class DlgEquipSystem
    {
        public static void RegisterUIEvent(this DlgEquip self)
        {
            self.RegisterCloseEvent<DlgEquip>(self.View.EB_Close_Button);
            self.View.EL_Equips_LoopVerticalScrollRect.AddItemRefreshListener(self.OnRefreshEquipItem);
            self.View.ED_EqiupTab_Dropdown.AddListener((a) =>
            {
                self.EquipPosition = (EquipPosition)a;
                self.RefreshEquipList();
            });
            self.EquipSlots = new()
            {
                { EquipPosition.头盔,self.View.ES_EquipSlot_头盔 },
                { EquipPosition.衣服,self.View.ES_EquipSlot_衣服 },
                { EquipPosition.鞋子,self.View.ES_EquipSlot_鞋子 },
                { EquipPosition.护肩,self.View.ES_EquipSlot_护肩 },
                { EquipPosition.武器,self.View.ES_EquipSlot_武器 },
                { EquipPosition.副手,self.View.ES_EquipSlot_副手 },
                { EquipPosition.裤子,self.View.ES_EquipSlot_裤子 },
            };
        }

        public static void ShowWindow(this DlgEquip self, Entity contextData = null)
        {
            self.View.ED_EqiupTab_Dropdown.value = (int)self.EquipPosition;
            self.Refresh();
        }

        public static void Refresh(this DlgEquip self)
        {
            self.RefreshRoleInfo();
            self.RefreshEquipList();
            self.RefreshEquipSlot();
        }

        public static void RefreshRoleInfo(this DlgEquip self)
        {
            RoleInfosComponent rc = self.ClientScene().GetComponent<RoleInfosComponent>();
            DlgEquipViewComponent view = self.View;

            view.ET_CharName_Level_Text.text = $"{rc.CurrentRole.Name} Lv.{rc.CurrentRole.Level}"; //角色名称 等级
            var nc = self.GetMyNumericComponent();
            view.ES_STR.ET_Value_Text.text = nc.GetAsInt(NumericType.STR).ToString();
            view.ES_INT.ET_Value_Text.text = nc.GetAsInt(NumericType.INT).ToString();
            view.ES_DEX.ET_Value_Text.text = nc.GetAsInt(NumericType.DEX).ToString();
            view.ES_STA.ET_Value_Text.text = nc.GetAsInt(NumericType.STA).ToString();

            view.ES_AD.ET_Value_Text.text = nc.GetAsInt(NumericType.AD).ToString();
            view.ES_AP.ET_Value_Text.text = nc.GetAsInt(NumericType.AP).ToString();
            view.ES_DEF.ET_Value_Text.text = nc.GetAsInt(NumericType.DEX).ToString();
            view.ES_MDEF.ET_Value_Text.text = nc.GetAsInt(NumericType.MDEF).ToString();
            view.ES_SPD.ET_Value_Text.text = nc.GetAsFloat(NumericType.Speed).ToString();
            view.ES_CRI.ET_Value_Text.text = nc.GetAsFloat(NumericType.CRI).ToString();

            view.ES_HpBar.ET_Text_TextMeshProUGUI.text = $"{nc[NumericType.Hp]}/{nc[NumericType.MaxHp]}";
            view.ES_HpBar.ED_Slider_Slider.maxValue = nc[NumericType.MaxHp];
            view.ES_HpBar.ED_Slider_Slider.value = nc[NumericType.Hp];

            view.ES_MpBar.ET_Text_TextMeshProUGUI.text = $"{nc[NumericType.MP]}/{nc[NumericType.MaxMp]}";
            view.ES_MpBar.ED_Slider_Slider.maxValue = nc[NumericType.MaxMp];
            view.ES_MpBar.ED_Slider_Slider.value = nc[NumericType.MP];
        }

        public static void RefreshEquipSlot(this DlgEquip self)
        {
            foreach ((EquipPosition slot, ES_EquipSlot es_slot) in self.EquipSlots)
            {
                es_slot.Init(slot);
            }
        }

        public static void OnRefreshEquipItem(this DlgEquip self, Transform transform, int index)
        {
            var scrollItemEquip = self.ScrollItemEquipItems[index].BindTrans(transform);
            scrollItemEquip.Refresh(self.EquipList[index]);
        }

        public static void RefreshEquipList(this DlgEquip self)
        {
            var eqiups = self.ClientScene().GetComponent<BagComponent>().ItemTypeMap[ItemType.Equip].ToList();
            self.EquipList = self.EquipPosition switch
            {
                EquipPosition.无 => eqiups,
                _ => eqiups.Where(e => e.EquipConfig.EquipPosition == ((int)self.EquipPosition)).ToList(),
            };
            if (self.EquipList?.Count != 0)
            {
                self.AddUIScrollItems(ref self.ScrollItemEquipItems, self.EquipList.Count);
                self.View.EL_Equips_LoopVerticalScrollRect.SetVisible(true, self.EquipList.Count);
            }
        }
    }
}