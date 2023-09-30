using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgEquip))]
    [EnableMethod]
    public class DlgEquipViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Close_Button;
        private Image m_EB_Close_Image;
        private Dropdown m_ED_EqiupTab_Dropdown;
        private Image m_ED_EqiupTab_Image;
        private LoopVerticalScrollRect m_EL_Equips_LoopVerticalScrollRect;
        private ES_Attribute m_es_ad;
        private ES_Attribute m_es_ap;
        private ES_Attribute m_es_cri;
        private ES_Attribute m_es_def;
        private ES_Attribute m_es_dex;
        private ES_EquipSlot m_es_equipslot_副手;
        private ES_EquipSlot m_es_equipslot_护肩;
        private ES_EquipSlot m_es_equipslot_裤子;
        private ES_EquipSlot m_es_equipslot_时装;
        private ES_EquipSlot m_es_equipslot_头盔;
        private ES_EquipSlot m_es_equipslot_武器;
        private ES_EquipSlot m_es_equipslot_鞋子;
        private ES_EquipSlot m_es_equipslot_衣服;
        private ES_Slider m_es_hpbar;
        private ES_Attribute m_es_int;
        private ES_Attribute m_es_mdef;
        private ES_Slider m_es_mpbar;
        private ES_Attribute m_es_spd;
        private ES_Attribute m_es_sta;
        private ES_Attribute m_es_str;
        private Text m_ET_CharName_Level_Text;
        public Transform uiTransform;

        public Button EB_Close_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Close_Button == null)
                {
                    this.m_EB_Close_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Title/EB_Close");
                }

                return this.m_EB_Close_Button;
            }
        }

        public Image EB_Close_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Close_Image == null)
                {
                    this.m_EB_Close_Image = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "Panel/Title/EB_Close");
                }

                return this.m_EB_Close_Image;
            }
        }

        public Dropdown ED_EqiupTab_Dropdown
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ED_EqiupTab_Dropdown == null)
                {
                    this.m_ED_EqiupTab_Dropdown =
                            UIHelper.FindDeepChild<Dropdown>(this.uiTransform.gameObject, "Panel/Content/S_EquipList/ED_EqiupTab");
                }

                return this.m_ED_EqiupTab_Dropdown;
            }
        }

        public Image ED_EqiupTab_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ED_EqiupTab_Image == null)
                {
                    this.m_ED_EqiupTab_Image = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "Panel/Content/S_EquipList/ED_EqiupTab");
                }

                return this.m_ED_EqiupTab_Image;
            }
        }

        public LoopVerticalScrollRect EL_Equips_LoopVerticalScrollRect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_Equips_LoopVerticalScrollRect == null)
                {
                    this.m_EL_Equips_LoopVerticalScrollRect =
                            UIHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject, "Panel/Content/S_EquipList/EL_Equips");
                }

                return this.m_EL_Equips_LoopVerticalScrollRect;
            }
        }

        public ES_EquipSlot ES_EquipSlot_武器
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_武器 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/LeftArea/ES_EquipSlot_武器");
                    this.m_es_equipslot_武器 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_武器;
            }
        }

        public ES_EquipSlot ES_EquipSlot_头盔
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_头盔 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/LeftArea/ES_EquipSlot_头盔");
                    this.m_es_equipslot_头盔 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_头盔;
            }
        }

        public ES_EquipSlot ES_EquipSlot_裤子
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_裤子 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/LeftArea/ES_EquipSlot_裤子");
                    this.m_es_equipslot_裤子 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_裤子;
            }
        }

        public ES_EquipSlot ES_EquipSlot_鞋子
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_鞋子 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/LeftArea/ES_EquipSlot_鞋子");
                    this.m_es_equipslot_鞋子 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_鞋子;
            }
        }

        public ES_EquipSlot ES_EquipSlot_副手
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_副手 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/RightArea/ES_EquipSlot_副手");
                    this.m_es_equipslot_副手 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_副手;
            }
        }

        public ES_EquipSlot ES_EquipSlot_衣服
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_衣服 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/RightArea/ES_EquipSlot_衣服");
                    this.m_es_equipslot_衣服 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_衣服;
            }
        }

        public ES_EquipSlot ES_EquipSlot_护肩
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_护肩 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/RightArea/ES_EquipSlot_护肩");
                    this.m_es_equipslot_护肩 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_护肩;
            }
        }

        public ES_EquipSlot ES_EquipSlot_时装
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_equipslot_时装 == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,
                        "Panel/Content/_EquipSlotPannel/RightArea/ES_EquipSlot_时装");
                    this.m_es_equipslot_时装 = this.AddChild<ES_EquipSlot, Transform>(subTrans);
                }

                return this.m_es_equipslot_时装;
            }
        }

        public Text ET_CharName_Level_Text
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_CharName_Level_Text == null)
                {
                    this.m_ET_CharName_Level_Text =
                            UIHelper.FindDeepChild<Text>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/ET_CharName_Level");
                }

                return this.m_ET_CharName_Level_Text;
            }
        }

        public ES_Slider ES_HpBar
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_hpbar == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/HPBar/ES_HpBar");
                    this.m_es_hpbar = this.AddChild<ES_Slider, Transform>(subTrans);
                }

                return this.m_es_hpbar;
            }
        }

        public ES_Slider ES_MpBar
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_mpbar == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/MPBar/ES_MpBar");
                    this.m_es_mpbar = this.AddChild<ES_Slider, Transform>(subTrans);
                }

                return this.m_es_mpbar;
            }
        }

        public ES_Attribute ES_STR
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_str == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/基础属性/属性/ES_STR");
                    this.m_es_str = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_str;
            }
        }

        public ES_Attribute ES_INT
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_int == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/基础属性/属性/ES_INT");
                    this.m_es_int = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_int;
            }
        }

        public ES_Attribute ES_DEX
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_dex == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/基础属性/属性/ES_DEX");
                    this.m_es_dex = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_dex;
            }
        }

        public ES_Attribute ES_STA
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_sta == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/基础属性/属性/ES_STA");
                    this.m_es_sta = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_sta;
            }
        }

        public ES_Attribute ES_AD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_ad == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/其他属性/属性/ES_AD");
                    this.m_es_ad = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_ad;
            }
        }

        public ES_Attribute ES_DEF
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_def == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/其他属性/属性/ES_DEF");
                    this.m_es_def = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_def;
            }
        }

        public ES_Attribute ES_AP
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_ap == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/其他属性/属性/ES_AP");
                    this.m_es_ap = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_ap;
            }
        }

        public ES_Attribute ES_MDEF
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_mdef == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/其他属性/属性/ES_MDEF");
                    this.m_es_mdef = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_mdef;
            }
        }

        public ES_Attribute ES_SPD
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_spd == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/其他属性/属性/ES_SPD");
                    this.m_es_spd = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_spd;
            }
        }

        public ES_Attribute ES_CRI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_cri == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/StatusPannel/其他属性/属性/ES_CRI");
                    this.m_es_cri = this.AddChild<ES_Attribute, Transform>(subTrans);
                }

                return this.m_es_cri;
            }
        }

        public void DestroyWidget()
        {
            this.m_EB_Close_Button = null;
            this.m_EB_Close_Image = null;
            this.m_ED_EqiupTab_Dropdown = null;
            this.m_ED_EqiupTab_Image = null;
            this.m_EL_Equips_LoopVerticalScrollRect = null;
            this.m_es_equipslot_武器?.Dispose();
            this.m_es_equipslot_武器 = null;
            this.m_es_equipslot_头盔?.Dispose();
            this.m_es_equipslot_头盔 = null;
            this.m_es_equipslot_裤子?.Dispose();
            this.m_es_equipslot_裤子 = null;
            this.m_es_equipslot_鞋子?.Dispose();
            this.m_es_equipslot_鞋子 = null;
            this.m_es_equipslot_副手?.Dispose();
            this.m_es_equipslot_副手 = null;
            this.m_es_equipslot_衣服?.Dispose();
            this.m_es_equipslot_衣服 = null;
            this.m_es_equipslot_护肩?.Dispose();
            this.m_es_equipslot_护肩 = null;
            this.m_es_equipslot_时装?.Dispose();
            this.m_es_equipslot_时装 = null;
            this.m_ET_CharName_Level_Text = null;
            this.m_es_hpbar?.Dispose();
            this.m_es_hpbar = null;
            this.m_es_mpbar?.Dispose();
            this.m_es_mpbar = null;
            this.m_es_str?.Dispose();
            this.m_es_str = null;
            this.m_es_int?.Dispose();
            this.m_es_int = null;
            this.m_es_dex?.Dispose();
            this.m_es_dex = null;
            this.m_es_sta?.Dispose();
            this.m_es_sta = null;
            this.m_es_ad?.Dispose();
            this.m_es_ad = null;
            this.m_es_def?.Dispose();
            this.m_es_def = null;
            this.m_es_ap?.Dispose();
            this.m_es_ap = null;
            this.m_es_mdef?.Dispose();
            this.m_es_mdef = null;
            this.m_es_spd?.Dispose();
            this.m_es_spd = null;
            this.m_es_cri?.Dispose();
            this.m_es_cri = null;
            this.uiTransform = null;
        }
    }
}