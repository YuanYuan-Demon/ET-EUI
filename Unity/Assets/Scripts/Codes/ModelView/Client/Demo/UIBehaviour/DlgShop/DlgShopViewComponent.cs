using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgShop))]
    [EnableMethod]
    public class DlgShopViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Buy_Button;

        private Button m_EB_Close_Button;
        private Image m_EB_Close_Image;
        private Toggle m_ET_All_Toggle;
        private Toggle m_ET_Consumables_Toggle;
        private Toggle m_ET_Equip_Toggle;
        private Toggle m_ET_Material_Toggle;
        private TextMeshProUGUI m_ET_Money_TextMeshProUGUI;
        private ToggleGroup m_ETG_TabButton_ToggleGroup;
        private LoopVList mElShopItemLoopVList;
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

        public ToggleGroup ETG_TabButton_ToggleGroup
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ETG_TabButton_ToggleGroup == null)
                {
                    this.m_ETG_TabButton_ToggleGroup = UIHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject, "Panel/ETG_TabButton");
                }

                return this.m_ETG_TabButton_ToggleGroup;
            }
        }

        public Toggle ET_All_Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_All_Toggle == null)
                {
                    this.m_ET_All_Toggle = UIHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject, "Panel/ETG_TabButton/ET_All");
                }

                return this.m_ET_All_Toggle;
            }
        }

        public Toggle ET_Equip_Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Equip_Toggle == null)
                {
                    this.m_ET_Equip_Toggle = UIHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject, "Panel/ETG_TabButton/ET_Equip");
                }

                return this.m_ET_Equip_Toggle;
            }
        }

        public Toggle ET_Consumables_Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Consumables_Toggle == null)
                {
                    this.m_ET_Consumables_Toggle = UIHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject, "Panel/ETG_TabButton/ET_Consumables");
                }

                return this.m_ET_Consumables_Toggle;
            }
        }

        public Toggle ET_Material_Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Material_Toggle == null)
                {
                    this.m_ET_Material_Toggle = UIHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject, "Panel/ETG_TabButton/ET_Material");
                }

                return this.m_ET_Material_Toggle;
            }
        }

        public LoopVList ElShopItemLoopVList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.mElShopItemLoopVList == null)
                {
                    this.mElShopItemLoopVList =
                            UIHelper.FindDeepChild<LoopVList>(this.uiTransform.gameObject, "Panel/EL_ShopItem");
                }

                return this.mElShopItemLoopVList;
            }
        }

        public TextMeshProUGUI ET_Money_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Money_TextMeshProUGUI == null)
                {
                    this.m_ET_Money_TextMeshProUGUI = UIHelper.FindDeepChild<TextMeshProUGUI>(this.uiTransform.gameObject, "Panel/Money/ET_Money");
                }

                return this.m_ET_Money_TextMeshProUGUI;
            }
        }

        public Button EB_Buy_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Buy_Button == null)
                {
                    this.m_EB_Buy_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/EB_Buy");
                }

                return this.m_EB_Buy_Button;
            }
        }

        public void DestroyWidget()
        {
            this.m_EB_Close_Button = null;
            this.m_EB_Close_Image = null;
            this.m_ETG_TabButton_ToggleGroup = null;
            this.m_ET_All_Toggle = null;
            this.m_ET_Equip_Toggle = null;
            this.m_ET_Consumables_Toggle = null;
            this.m_ET_Material_Toggle = null;
            this.mElShopItemLoopVList = null;
            this.m_ET_Money_TextMeshProUGUI = null;
            this.m_EB_Buy_Button = null;
            this.uiTransform = null;
        }
    }
}