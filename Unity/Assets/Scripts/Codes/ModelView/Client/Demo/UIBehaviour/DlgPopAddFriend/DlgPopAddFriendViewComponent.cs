using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (DlgPopAddFriend))]
    [EnableMethod]
    public class DlgPopAddFriendViewComponent: Entity, IAwake, IDestroy
    {
        private UnityEngine.UI.Button m_EB_Add_Button = null;
        private UnityEngine.UI.Button m_EB_Cancel_Button = null;

        private UnityEngine.UI.Button m_EB_Close_Button = null;
        private UnityEngine.UI.Image m_EB_Close_Image = null;
        private UnityEngine.RectTransform m_EG_Panel_RectTransform = null;
        private UnityEngine.UI.Image m_EInput_NameOrId_Image = null;
        private TMPro.TMP_InputField m_EInput_NameOrId_TMP_InputField = null;
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

        public TMPro.TMP_InputField EInput_NameOrId_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_NameOrId_TMP_InputField == null)
                {
                    this.m_EInput_NameOrId_TMP_InputField
                            = UIHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject, "EG_Panel/EInput_NameOrId");
                }

                return this.m_EInput_NameOrId_TMP_InputField;
            }
        }

        public UnityEngine.UI.Image EInput_NameOrId_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_NameOrId_Image == null)
                {
                    this.m_EInput_NameOrId_Image
                            = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EG_Panel/EInput_NameOrId");
                }

                return this.m_EInput_NameOrId_Image;
            }
        }

        public UnityEngine.UI.Button EB_Add_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Add_Button == null)
                {
                    this.m_EB_Add_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_Add");
                }

                return this.m_EB_Add_Button;
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
                    this.m_ET_Use_TextMeshProUGUI
                            = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_Add/ET_Use");
                }

                return this.m_ET_Use_TextMeshProUGUI;
            }
        }

        public UnityEngine.UI.Button EB_Cancel_Button
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
                    this.m_EB_Cancel_Button
                            = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EG_Panel/Buttons/EB_Cancel");
                }

                return this.m_EB_Cancel_Button;
            }
        }

        public void DestroyWidget()
        {
            this.m_EB_Close_Button = null;
            this.m_EB_Close_Image = null;
            this.m_EG_Panel_RectTransform = null;
            this.m_EInput_NameOrId_TMP_InputField = null;
            this.m_EInput_NameOrId_Image = null;
            this.m_EB_Add_Button = null;
            this.m_ET_Use_TextMeshProUGUI = null;
            this.m_EB_Cancel_Button = null;
            this.uiTransform = null;
        }
    }
}