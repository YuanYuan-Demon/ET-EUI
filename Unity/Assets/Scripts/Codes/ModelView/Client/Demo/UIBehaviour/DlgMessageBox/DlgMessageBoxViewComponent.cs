using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgMessageBox))]
    [EnableMethod]
    public class DlgMessageBoxViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Cancel_Button;
        private Button m_EB_OK_Button;
        private RectTransform m_EG_Icons_RectTransform;

        private RectTransform m_EG_Panel_RectTransform;
        private Image m_EI_Error_Image;
        private Image m_EI_Information_Image;
        private Image m_EI_Question_Image;
        private TextMeshProUGUI m_ET_Cancel_TextMeshProUGUI;
        private TextMeshProUGUI m_ET_Message_TextMeshProUGUI;
        private TextMeshProUGUI m_ET_OK_TextMeshProUGUI;
        private TextMeshProUGUI m_ET_Title_TextMeshProUGUI;
        public Transform uiTransform;

        public RectTransform EG_Panel_RectTransform
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
                    this.m_EG_Panel_RectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_Panel");
                }

                return this.m_EG_Panel_RectTransform;
            }
        }

        public TextMeshProUGUI ET_Title_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Title_TextMeshProUGUI == null)
                {
                    this.m_ET_Title_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/TitleBar/ET_Title");
                }

                return this.m_ET_Title_TextMeshProUGUI;
            }
        }

        public RectTransform EG_Icons_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_Icons_RectTransform == null)
                {
                    this.m_EG_Icons_RectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_Panel/Message/EG_Icons");
                }

                return this.m_EG_Icons_RectTransform;
            }
        }

        public Image EI_Information_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EI_Information_Image == null)
                {
                    this.m_EI_Information_Image =
                            UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "EG_Panel/Message/EG_Icons/EI_Information");
                }

                return this.m_EI_Information_Image;
            }
        }

        public Image EI_Question_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EI_Question_Image == null)
                {
                    this.m_EI_Question_Image = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "EG_Panel/Message/EG_Icons/EI_Question");
                }

                return this.m_EI_Question_Image;
            }
        }

        public Image EI_Error_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EI_Error_Image == null)
                {
                    this.m_EI_Error_Image = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "EG_Panel/Message/EG_Icons/EI_Error");
                }

                return this.m_EI_Error_Image;
            }
        }

        public TextMeshProUGUI ET_Message_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Message_TextMeshProUGUI == null)
                {
                    this.m_ET_Message_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Message/ET_Message");
                }

                return this.m_ET_Message_TextMeshProUGUI;
            }
        }

        public Button EB_OK_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_OK_Button == null)
                {
                    this.m_EB_OK_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_OK");
                }

                return this.m_EB_OK_Button;
            }
        }

        public TextMeshProUGUI ET_OK_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_OK_TextMeshProUGUI == null)
                {
                    this.m_ET_OK_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_OK/ET_OK");
                }

                return this.m_ET_OK_TextMeshProUGUI;
            }
        }

        public Button EB_Cancel_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Cancel_Button == null)
                {
                    this.m_EB_Cancel_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_Cancel");
                }

                return this.m_EB_Cancel_Button;
            }
        }

        public TextMeshProUGUI ET_Cancel_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_Cancel_TextMeshProUGUI == null)
                {
                    this.m_ET_Cancel_TextMeshProUGUI =
                            UIHelper.FindDeepChild<TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_Cancel/ET_Cancel");
                }

                return this.m_ET_Cancel_TextMeshProUGUI;
            }
        }

        public void DestroyWidget()
        {
            this.m_EG_Panel_RectTransform = null;
            this.m_ET_Title_TextMeshProUGUI = null;
            this.m_EG_Icons_RectTransform = null;
            this.m_EI_Information_Image = null;
            this.m_EI_Question_Image = null;
            this.m_EI_Error_Image = null;
            this.m_ET_Message_TextMeshProUGUI = null;
            this.m_EB_OK_Button = null;
            this.m_ET_OK_TextMeshProUGUI = null;
            this.m_EB_Cancel_Button = null;
            this.m_ET_Cancel_TextMeshProUGUI = null;
            this.uiTransform = null;
        }
    }
}