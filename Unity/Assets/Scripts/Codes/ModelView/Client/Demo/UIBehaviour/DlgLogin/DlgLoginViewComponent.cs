using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgLogin))]
    [EnableMethod]
    public class DlgLoginViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Cancel_Button;
        private Button m_EB_Login_Button;
        private Button m_EB_Register_Button;
        private Button m_EB_ToRegister_Button;

        private RectTransform m_EG_LoginPanel_RectTransform;
        private RectTransform m_EG_RegisterPanel_RectTransform;
        private TMP_InputField m_EInput_LoginAccount_TMP_InputField;
        private TMP_InputField m_EInput_LoginPassword_TMP_InputField;
        private TMP_InputField m_EInput_RegisterAccount_TMP_InputField;
        private TMP_InputField m_EInput_RegisterPassword_Confirm_TMP_InputField;
        private TMP_InputField m_EInput_RegisterPassword_TMP_InputField;
        public Transform uiTransform;

        public RectTransform EG_LoginPanel_RectTransform
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
                            UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "Panel/Content/EG_LoginPanel");
                }

                return this.m_EG_LoginPanel_RectTransform;
            }
        }

        public TMP_InputField EInput_LoginAccount_TMP_InputField
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
                    this.m_EInput_LoginAccount_TMP_InputField = UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_LoginPanel/Account/EInput_LoginAccount");
                }

                return this.m_EInput_LoginAccount_TMP_InputField;
            }
        }

        public TMP_InputField EInput_LoginPassword_TMP_InputField
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
                    this.m_EInput_LoginPassword_TMP_InputField = UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_LoginPanel/Password/EInput_LoginPassword");
                }

                return this.m_EInput_LoginPassword_TMP_InputField;
            }
        }

        public Button EB_Login_Button
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
                            UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Content/EG_LoginPanel/Buttons/EB_Login");
                }

                return this.m_EB_Login_Button;
            }
        }

        public Button EB_ToRegister_Button
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
                    this.m_EB_ToRegister_Button =
                            UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Content/EG_LoginPanel/Buttons/EB_ToRegister");
                }

                return this.m_EB_ToRegister_Button;
            }
        }

        public RectTransform EG_RegisterPanel_RectTransform
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
                            UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "Panel/Content/EG_RegisterPanel");
                }

                return this.m_EG_RegisterPanel_RectTransform;
            }
        }

        public TMP_InputField EInput_RegisterAccount_TMP_InputField
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
                    this.m_EInput_RegisterAccount_TMP_InputField = UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/Account/EInput_RegisterAccount");
                }

                return this.m_EInput_RegisterAccount_TMP_InputField;
            }
        }

        public TMP_InputField EInput_RegisterPassword_TMP_InputField
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
                    this.m_EInput_RegisterPassword_TMP_InputField = UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/Password/EInput_RegisterPassword");
                }

                return this.m_EInput_RegisterPassword_TMP_InputField;
            }
        }

        public TMP_InputField EInput_RegisterPassword_Confirm_TMP_InputField
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
                    this.m_EInput_RegisterPassword_Confirm_TMP_InputField = UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject,
                        "Panel/Content/EG_RegisterPanel/ConfirmPassword/EInput_RegisterPassword_Confirm");
                }

                return this.m_EInput_RegisterPassword_Confirm_TMP_InputField;
            }
        }

        public Button EB_Register_Button
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
                    this.m_EB_Register_Button =
                            UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Content/EG_RegisterPanel/Buttons/EB_Register");
                }

                return this.m_EB_Register_Button;
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
                    this.m_EB_Cancel_Button =
                            UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Content/EG_RegisterPanel/Buttons/EB_Cancel");
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