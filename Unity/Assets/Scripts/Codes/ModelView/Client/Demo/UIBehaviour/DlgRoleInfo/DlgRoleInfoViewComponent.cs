
using UnityEngine;
namespace ET.Client
{
    [ComponentOf(typeof(DlgRoleInfo))]
    [EnableMethod]
    public class DlgRoleInfoViewComponent : Entity, IAwake, IDestroy
    {
        public UnityEngine.UI.Button EB_CloseButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EB_CloseButton == null)
                {
                    this.m_EB_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "Panel/EB_Close");
                }
                return this.m_EB_CloseButton;
            }
        }

        public UnityEngine.RectTransform EG_EquipsRectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EG_EquipsRectTransform == null)
                {
                    this.m_EG_EquipsRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips");
                }
                return this.m_EG_EquipsRectTransform;
            }
        }

        public ES_EquipItem ES_Equip_Helmet
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_equip_helmet == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips/ES_Equip_Helmet");
                    this.m_es_equip_helmet = this.AddChild<ES_EquipItem, Transform>(subTrans);
                }
                return this.m_es_equip_helmet;
            }
        }

        public ES_EquipItem ES_Equip_Armor
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_equip_armor == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips/ES_Equip_Armor");
                    this.m_es_equip_armor = this.AddChild<ES_EquipItem, Transform>(subTrans);
                }
                return this.m_es_equip_armor;
            }
        }

        public ES_EquipItem ES_Equip_Shoe
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_equip_shoe == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips/ES_Equip_Shoe");
                    this.m_es_equip_shoe = this.AddChild<ES_EquipItem, Transform>(subTrans);
                }
                return this.m_es_equip_shoe;
            }
        }

        public ES_EquipItem ES_Equip_Ring
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_equip_ring == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips/ES_Equip_Ring");
                    this.m_es_equip_ring = this.AddChild<ES_EquipItem, Transform>(subTrans);
                }
                return this.m_es_equip_ring;
            }
        }

        public ES_EquipItem ES_Equip_Offhand
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_equip_offhand == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips/ES_Equip_Offhand");
                    this.m_es_equip_offhand = this.AddChild<ES_EquipItem, Transform>(subTrans);
                }
                return this.m_es_equip_offhand;
            }
        }

        public ES_EquipItem ES_Equip_Weapon
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_equip_weapon == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/RoleView/EG_Equips/ES_Equip_Weapon");
                    this.m_es_equip_weapon = this.AddChild<ES_EquipItem, Transform>(subTrans);
                }
                return this.m_es_equip_weapon;
            }
        }

        public UnityEngine.UI.Button EB_UpLevelButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EB_UpLevelButton == null)
                {
                    this.m_EB_UpLevelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "Panel/Content/RoleView/EB_UpLevel");
                }
                return this.m_EB_UpLevelButton;
            }
        }

        public UnityEngine.UI.Text ET_AttributePointsText
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_ET_AttributePointsText == null)
                {
                    this.m_ET_AttributePointsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/ET_AttributePoints");
                }
                return this.m_ET_AttributePointsText;
            }
        }

        public UnityEngine.UI.Button EB_CancelAddAttributeButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EB_CancelAddAttributeButton == null)
                {
                    this.m_EB_CancelAddAttributeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/ET_AttributePoints/EB_CancelAddAttribute");
                }
                return this.m_EB_CancelAddAttributeButton;
            }
        }

        public UnityEngine.UI.Button EB_ConfirmAddAttributeButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EB_ConfirmAddAttributeButton == null)
                {
                    this.m_EB_ConfirmAddAttributeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/ET_AttributePoints/EB_ConfirmAddAttribute");
                }
                return this.m_EB_ConfirmAddAttributeButton;
            }
        }

        public ES_AddAttribute ES_AddAttribute1
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_addattribute1 == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/AttributePoints/ES_AddAttribute1");
                    this.m_es_addattribute1 = this.AddChild<ES_AddAttribute, Transform>(subTrans);
                }
                return this.m_es_addattribute1;
            }
        }

        public ES_AddAttribute ES_AddAttribute2
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_addattribute2 == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/AttributePoints/ES_AddAttribute2");
                    this.m_es_addattribute2 = this.AddChild<ES_AddAttribute, Transform>(subTrans);
                }
                return this.m_es_addattribute2;
            }
        }

        public ES_AddAttribute ES_AddAttribute3
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_addattribute3 == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/AttributePoints/ES_AddAttribute3");
                    this.m_es_addattribute3 = this.AddChild<ES_AddAttribute, Transform>(subTrans);
                }
                return this.m_es_addattribute3;
            }
        }

        public ES_AddAttribute ES_AddAttribute4
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_es_addattribute4 == null)
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/Content/AttributePointsPannel/AttributePoints/ES_AddAttribute4");
                    this.m_es_addattribute4 = this.AddChild<ES_AddAttribute, Transform>(subTrans);
                }
                return this.m_es_addattribute4;
            }
        }

        public UnityEngine.UI.LoopVerticalScrollRect EL_AttributeInfoLoopVerticalScrollRect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EL_AttributeInfoLoopVerticalScrollRect == null)
                {
                    this.m_EL_AttributeInfoLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject, "Panel/Content/EL_AttributeInfo");
                }
                return this.m_EL_AttributeInfoLoopVerticalScrollRect;
            }
        }

        public void DestroyWidget()
        {
            this.m_EB_CloseButton = null;
            this.m_EG_EquipsRectTransform = null;
            this.m_es_equip_helmet?.Dispose();
            this.m_es_equip_helmet = null;
            this.m_es_equip_armor?.Dispose();
            this.m_es_equip_armor = null;
            this.m_es_equip_shoe?.Dispose();
            this.m_es_equip_shoe = null;
            this.m_es_equip_ring?.Dispose();
            this.m_es_equip_ring = null;
            this.m_es_equip_offhand?.Dispose();
            this.m_es_equip_offhand = null;
            this.m_es_equip_weapon?.Dispose();
            this.m_es_equip_weapon = null;
            this.m_EB_UpLevelButton = null;
            this.m_ET_AttributePointsText = null;
            this.m_EB_CancelAddAttributeButton = null;
            this.m_EB_ConfirmAddAttributeButton = null;
            this.m_es_addattribute1?.Dispose();
            this.m_es_addattribute1 = null;
            this.m_es_addattribute2?.Dispose();
            this.m_es_addattribute2 = null;
            this.m_es_addattribute3?.Dispose();
            this.m_es_addattribute3 = null;
            this.m_es_addattribute4?.Dispose();
            this.m_es_addattribute4 = null;
            this.m_EL_AttributeInfoLoopVerticalScrollRect = null;
            this.uiTransform = null;
        }

        private UnityEngine.UI.Button m_EB_CloseButton = null;
        private UnityEngine.RectTransform m_EG_EquipsRectTransform = null;
        private ES_EquipItem m_es_equip_helmet = null;
        private ES_EquipItem m_es_equip_armor = null;
        private ES_EquipItem m_es_equip_shoe = null;
        private ES_EquipItem m_es_equip_ring = null;
        private ES_EquipItem m_es_equip_offhand = null;
        private ES_EquipItem m_es_equip_weapon = null;
        private UnityEngine.UI.Button m_EB_UpLevelButton = null;
        private UnityEngine.UI.Text m_ET_AttributePointsText = null;
        private UnityEngine.UI.Button m_EB_CancelAddAttributeButton = null;
        private UnityEngine.UI.Button m_EB_ConfirmAddAttributeButton = null;
        private ES_AddAttribute m_es_addattribute1 = null;
        private ES_AddAttribute m_es_addattribute2 = null;
        private ES_AddAttribute m_es_addattribute3 = null;
        private ES_AddAttribute m_es_addattribute4 = null;
        private UnityEngine.UI.LoopVerticalScrollRect m_EL_AttributeInfoLoopVerticalScrollRect = null;
        public Transform uiTransform = null;
    }
}
