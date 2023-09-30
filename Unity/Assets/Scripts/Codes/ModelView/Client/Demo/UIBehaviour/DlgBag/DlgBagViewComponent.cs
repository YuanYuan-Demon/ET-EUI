using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgBag))]
    [EnableMethod]
    public class DlgBagViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Close_Button;
        private Image m_EB_Close_Image;
        private Button m_EB_Sort_Button;
        private LoopVerticalScrollRect m_EL_BagItem_LoopVerticalScrollRect;
        private Toggle m_ET_All_Toggle;
        private Toggle m_ET_Consumables_Toggle;
        private Toggle m_ET_Equip_Toggle;
        private Toggle m_ET_Material_Toggle;
        private TextMeshProUGUI m_ET_Money_TextMeshProUGUI;
        private ToggleGroup m_ETG_TabButton_ToggleGroup;
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

        public LoopVerticalScrollRect EL_BagItem_LoopVerticalScrollRect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_BagItem_LoopVerticalScrollRect == null)
                {
                    this.m_EL_BagItem_LoopVerticalScrollRect =
                            UIHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject, "Panel/EL_BagItem");
                }

                return this.m_EL_BagItem_LoopVerticalScrollRect;
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

        public Button EB_Sort_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Sort_Button == null)
                {
                    this.m_EB_Sort_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/EB_Sort");
                }

                return this.m_EB_Sort_Button;
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
            this.m_EL_BagItem_LoopVerticalScrollRect = null;
            this.m_ET_Money_TextMeshProUGUI = null;
            this.m_EB_Sort_Button = null;
            this.uiTransform = null;
        }
    }
}