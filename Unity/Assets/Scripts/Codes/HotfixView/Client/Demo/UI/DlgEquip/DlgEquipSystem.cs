using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgEquip))]
    [FriendOf(typeof (BagComponent))]
    [FriendOf(typeof (RoleInfosComponent))]
    [FriendOf(typeof (RoleInfo))]
    [FriendOf(typeof (EquipmentsComponent))]
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
                { EquipPosition.Helmet, self.View.ES_EquipSlot_头盔 },
                { EquipPosition.Cloth, self.View.ES_EquipSlot_衣服 },
                { EquipPosition.Shoe, self.View.ES_EquipSlot_鞋子 },
                { EquipPosition.Shoulder, self.View.ES_EquipSlot_护肩 },
                { EquipPosition.Weapon, self.View.ES_EquipSlot_武器 },
                { EquipPosition.OffHands, self.View.ES_EquipSlot_副手 },
                { EquipPosition.Pants, self.View.ES_EquipSlot_裤子 },
            };
            self.Refresh();
        }

        public static void ShowWindow(this DlgEquip self, ShowWindowData contextData = null)
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
            var rc = self.ClientScene().GetComponent<RoleInfosComponent>();
            DlgEquipViewComponent view = self.View;

            view.ET_CharName_Level_Text.text = $"{rc.CurrentRole.Name} Lv.{rc.CurrentRole.Level}"; //角色名称 等级
            NumericComponent nc = self.GetMyNumericComponent();
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

            view.ES_HpBar.ET_Desc_TextMeshProUGUI.text = $"{nc[NumericType.Hp].ToString()}/{nc[NumericType.MaxHp].ToString()}";
            view.ES_HpBar.ED_Slider_Slider.maxValue = nc[NumericType.MaxHp];
            view.ES_HpBar.ED_Slider_Slider.value = nc[NumericType.Hp];

            view.ES_MpBar.ET_Desc_TextMeshProUGUI.text = $"{nc[NumericType.MP].ToString()}/{nc[NumericType.MaxMp].ToString()}";
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

        private static void OnRefreshEquipItem(this DlgEquip self, Transform transform, int index)
        {
            Scroll_Item_Equip scrollItemEquip = self.ScrollItemEquipItems[index].BindTrans(transform);
            scrollItemEquip.Refresh(self.EquipList[index]);
        }

        public static void RefreshEquipList(this DlgEquip self)
        {
            List<Item> eqiups = self.ClientScene().GetComponent<BagComponent>().ItemTypeMap[ItemType.Equip].ToList();
            self.EquipList = self.EquipPosition switch
            {
                EquipPosition.None => eqiups,
                _ => eqiups.Where(e => e.EquipConfig.EquipPosition == self.EquipPosition).ToList(),
            };
            if (self.EquipList?.Count != 0)
            {
                self.AddUIScrollItems(ref self.ScrollItemEquipItems, self.EquipList.Count);
                self.View.EL_Equips_LoopVerticalScrollRect.SetVisible(true, self.EquipList.Count);
            }
            else
            {
                self.View.EL_Equips_LoopVerticalScrollRect.SetVisible(true, self.EquipList.Count);
            }
        }
    }
}