using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (DlgLogin))]
    [EnableMethod]
    public class DlgLoginViewComponent: Entity, IAwake, IDestroy
    {
        private UnityEngine.UI.Button m_EB_Cancel_Button = null;
        private UnityEngine.UI.Button m_EB_Login_Button = null;
        private UnityEngine.UI.Button m_EB_Register_Button = null;
        private UnityEngine.UI.Button m_EB_ToRegister_Button = null;

        private UnityEngine.RectTransform m_EG_LoginPanel_RectTransform = null;
        private UnityEngine.RectTransform m_EG_RegisterPanel_RectTransform = null;
        private TMPro.TMP_InputField m_EInput_LoginAccount_TMP_InputField = null;
        private TMPro.TMP_InputField m_EInput_LoginPassword_TMP_InputField = null;
        private TMPro.TMP_InputField m_EInput_RegisterAccount_TMP_InputField = null;
        private TMPro.TMP_InputField m_EInput_RegisterPassword_Confirm_TMP_InputField = null;
        private TMPro.TMP_InputField m_EInput_RegisterPassword_TMP_InputField = null;
        public Transform uiTransform = null;

        public UnityEngine.RectTransform EG_LoginPanel_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_LoginPanel_RectTransform == null)
                {
                    this.m_EG_LoginPanel_RectTransform =
                            UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject, "Panel/Content/EG_LoginPanel");
                }

                return this.m_EG_LoginPanel_RectTransform;
            }
        }

        public TMPro.TMP_InputField EInput_LoginAccount_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_LoginAccount_TMP_InputField == null)
                {
                    this.m_EInput_LoginAccount_TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_LoginPanel/Account/EInput_LoginAccount");
                }

                return this.m_EInput_LoginAccount_TMP_InputField;
            }
        }

        public TMPro.TMP_InputField EInput_LoginPassword_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_LoginPassword_TMP_InputField == null)
                {
                    this.m_EInput_LoginPassword_TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_LoginPanel/Password/EInput_LoginPassword");
                }

                return this.m_EInput_LoginPassword_TMP_InputField;
            }
        }

        public UnityEngine.UI.Button EB_Login_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Login_Button == null)
                {
                    this.m_EB_Login_Button =
                            UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,
                                "Panel/Content/EG_LoginPanel/Buttons/EB_Login");
                }

                return this.m_EB_Login_Button;
            }
        }

        public UnityEngine.UI.Button EB_ToRegister_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_ToRegister_Button == null)
                {
                    this.m_EB_ToRegister_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,
                        "Panel/Content/EG_LoginPanel/Buttons/EB_ToRegister");
                }

                return this.m_EB_ToRegister_Button;
            }
        }

        public UnityEngine.RectTransform EG_RegisterPanel_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_RegisterPanel_RectTransform == null)
                {
                    this.m_EG_RegisterPanel_RectTransform =
                            UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject, "Panel/Content/EG_RegisterPanel");
                }

                return this.m_EG_RegisterPanel_RectTransform;
            }
        }

        public TMPro.TMP_InputField EInput_RegisterAccount_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_RegisterAccount_TMP_InputField == null)
                {
                    this.m_EInput_RegisterAccount_TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/Account/EInput_RegisterAccount");
                }

                return this.m_EInput_RegisterAccount_TMP_InputField;
            }
        }

        public TMPro.TMP_InputField EInput_RegisterPassword_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_RegisterPassword_TMP_InputField == null)
                {
                    this.m_EInput_RegisterPassword_TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/Password/EInput_RegisterPassword");
                }

                return this.m_EInput_RegisterPassword_TMP_InputField;
            }
        }

        public TMPro.TMP_InputField EInput_RegisterPassword_Confirm_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_RegisterPassword_Confirm_TMP_InputField == null)
                {
                    this.m_EInput_RegisterPassword_Confirm_TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(
                        this.uiTransform.gameObject, "Panel/Content/EG_RegisterPanel/ConfirmPassword/EInput_RegisterPassword_Confirm");
                }

                return this.m_EInput_RegisterPassword_Confirm_TMP_InputField;
            }
        }

        public UnityEngine.UI.Button EB_Register_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Register_Button == null)
                {
                    this.m_EB_Register_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/Buttons/EB_Register");
                }

                return this.m_EB_Register_Button;
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
                    this.m_EB_Cancel_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/Buttons/EB_Cancel");
                }

                return this.m_EB_Cancel_Button;
            }
        }

        public void DestroyWidget()
        {
            this.m_EG_LoginPanel_RectTransform = null;
            this.m_EInput_LoginAccount_TMP_InputField = null;
            this.m_EInput_LoginPassword_TMP_InputField = null;
            this.m_EB_Login_Button = null;
            this.m_EB_ToRegister_Button = null;
            this.m_EG_RegisterPanel_RectTransform = null;
            this.m_EInput_RegisterAccount_TMP_InputField = null;
            this.m_EInput_RegisterPassword_TMP_InputField = null;
            this.m_EInput_RegisterPassword_Confirm_TMP_InputField = null;
            this.m_EB_Register_Button = null;
            this.m_EB_Cancel_Button = null;
            this.uiTransform = null;
        }
    }
}