using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (DlgPopItem))]
    [EnableMethod]
    public class DlgPopItemViewComponent: Entity, IAwake, IDestroy
    {
        private UnityEngine.UI.Button m_EB_Close_Button = null;
        private UnityEngine.UI.Image m_EB_Close_Image = null;
        private UnityEngine.UI.Button m_EB_Sell_Button = null;
        private UnityEngine.UI.Button m_EB_Show_Button = null;
        private UnityEngine.UI.Button m_EB_Use_Button = null;
        private UnityEngine.RectTransform m_EG_Buttons_RectTransform = null;
        private UnityEngine.RectTransform m_EG_Panel_RectTransform = null;
        private UnityEngine.UI.Image m_EI_Icon_Image = null;
        private TMPro.TextMeshProUGUI m_ET_Class_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_Desc_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_Level_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_Name_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_Price_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_Type_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_Use_TextMeshProUGUI = null;
        public Transform uiTransform = null;

        public UnityEngine.UI.Button EB_Close_Button
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
                    this.m_EB_Close_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EB_Close");
                }

                return this.m_EB_Close_Button;
            }
        }

        public UnityEngine.UI.Image EB_Close_Image
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
                    this.m_EB_Close_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EB_Close");
                }

                return this.m_EB_Close_Image;
            }
        }

        public UnityEngine.RectTransform EG_Panel_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_Panel_RectTransform == null)
                {
                    this.m_EG_Panel_RectTransform = UIHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject, "EG_Panel");
                }

                return this.m_EG_Panel_RectTransform;
            }
        }

        public UnityEngine.UI.Image EI_Icon_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EI_Icon_Image == null)
                {
                    this.m_EI_Icon_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EG_Panel/Info/Slot/EI_Icon");
                }

                return this.m_EI_Icon_Image;
            }
        }

        public TMPro.TextMeshProUGUI ET_Name_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Name_TextMeshProUGUI == null)
                {
                    this.m_ET_Name_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Info/Info/ET_Name");
                }

                return this.m_ET_Name_TextMeshProUGUI;
            }
        }

        public TMPro.TextMeshProUGUI ET_Type_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Type_TextMeshProUGUI == null)
                {
                    this.m_ET_Type_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Info/Info/ET_Type");
                }

                return this.m_ET_Type_TextMeshProUGUI;
            }
        }

        public TMPro.TextMeshProUGUI ET_Level_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Level_TextMeshProUGUI == null)
                {
                    this.m_ET_Level_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Info/Info/ET_Level");
                }

                return this.m_ET_Level_TextMeshProUGUI;
            }
        }

        public TMPro.TextMeshProUGUI ET_Class_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Class_TextMeshProUGUI == null)
                {
                    this.m_ET_Class_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Info/Info/ET_Class");
                }

                return this.m_ET_Class_TextMeshProUGUI;
            }
        }

        public TMPro.TextMeshProUGUI ET_Desc_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Desc_TextMeshProUGUI == null)
                {
                    this.m_ET_Desc_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/ET_Desc");
                }

                return this.m_ET_Desc_TextMeshProUGUI;
            }
        }

        public TMPro.TextMeshProUGUI ET_Price_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Price_TextMeshProUGUI == null)
                {
                    this.m_ET_Price_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/ET_Price");
                }

                return this.m_ET_Price_TextMeshProUGUI;
            }
        }

        public UnityEngine.RectTransform EG_Buttons_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_Buttons_RectTransform == null)
                {
                    this.m_EG_Buttons_RectTransform =
                            UIHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject, "EG_Panel/EG_Buttons");
                }

                return this.m_EG_Buttons_RectTransform;
            }
        }

        public UnityEngine.UI.Button EB_Use_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Use_Button == null)
                {
                    this.m_EB_Use_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EG_Panel/EG_Buttons/EB_Use");
                }

                return this.m_EB_Use_Button;
            }
        }

        public TMPro.TextMeshProUGUI ET_Use_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Use_TextMeshProUGUI == null)
                {
                    this.m_ET_Use_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/EG_Buttons/EB_Use/ET_Use");
                }

                return this.m_ET_Use_TextMeshProUGUI;
            }
        }

        public UnityEngine.UI.Button EB_Show_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Show_Button == null)
                {
                    this.m_EB_Show_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EG_Panel/EG_Buttons/EB_Show");
                }

                return this.m_EB_Show_Button;
            }
        }

        public UnityEngine.UI.Button EB_Sell_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Sell_Button == null)
                {
                    this.m_EB_Sell_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EG_Panel/EG_Buttons/EB_Sell");
                }

                return this.m_EB_Sell_Button;
            }
        }

        public void DestroyWidget()
        {
            this.m_EB_Close_Button = null;
            this.m_EB_Close_Image = null;
            this.m_EG_Panel_RectTransform = null;
            this.m_EI_Icon_Image = null;
            this.m_ET_Name_TextMeshProUGUI = null;
            this.m_ET_Type_TextMeshProUGUI = null;
            this.m_ET_Level_TextMeshProUGUI = null;
            this.m_ET_Class_TextMeshProUGUI = null;
            this.m_ET_Desc_TextMeshProUGUI = null;
            this.m_ET_Price_TextMeshProUGUI = null;
            this.m_EG_Buttons_RectTransform = null;
            this.m_EB_Use_Button = null;
            this.m_ET_Use_TextMeshProUGUI = null;
            this.m_EB_Show_Button = null;
            this.m_EB_Sell_Button = null;
            this.uiTransform = null;
        }
    }
}