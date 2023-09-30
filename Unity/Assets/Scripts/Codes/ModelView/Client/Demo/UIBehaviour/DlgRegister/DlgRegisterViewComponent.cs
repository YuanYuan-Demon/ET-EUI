using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgRegister))]
    [EnableMethod]
    public class DlgRegisterViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Login_Button;
        private Image m_EB_Login_Image;
        private Button m_EB_Register_Button;
        private Image m_EB_Register_Image;
        private Image m_EInput_Password_Image;
        private TMP_InputField m_EInput_Password_TMP_InputField;
        private Image m_EInput_Username_Image;

        private TMP_InputField m_EInput_Username_TMP_InputField;
        public Transform uiTransform;

        public TMP_InputField EInput_Username_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_Username_TMP_InputField == null)
                {
                    this.m_EInput_Username_TMP_InputField =
                            UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject, "Panel/Content/Username/EInput_Username");
                }

                return this.m_EInput_Username_TMP_InputField;
            }
        }

        public Image EInput_Username_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_Username_Image == null)
                {
                    this.m_EInput_Username_Image =
                            UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "Panel/Content/Username/EInput_Username");
                }

                return this.m_EInput_Username_Image;
            }
        }

        public TMP_InputField EInput_Password_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_Password_TMP_InputField == null)
                {
                    this.m_EInput_Password_TMP_InputField =
                            UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject, "Panel/Content/Password/EInput_Password");
                }

                return this.m_EInput_Password_TMP_InputField;
            }
        }

        public Image EInput_Password_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_Password_Image == null)
                {
                    this.m_EInput_Password_Image =
                            UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "Panel/Content/Password/EInput_Password");
                }

                return this.m_EInput_Password_Image;
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
                    this.m_EB_Login_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Content/Buttons/EB_Login");
                }

                return this.m_EB_Login_Button;
            }
        }

        public Image EB_Login_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Login_Image == null)
                {
                    this.m_EB_Login_Image = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "Panel/Content/Buttons/EB_Login");
                }

                return this.m_EB_Login_Image;
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
                    this.m_EB_Register_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/Content/Buttons/EB_Register");
                }

                return this.m_EB_Register_Button;
            }
        }

        public Image EB_Register_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Register_Image == null)
                {
                    this.m_EB_Register_Image = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "Panel/Content/Buttons/EB_Register");
                }

                return this.m_EB_Register_Image;
            }
        }

        public void DestroyWidget()
        {
            this.m_EInput_Username_TMP_InputField = null;
            this.m_EInput_Username_Image = null;
            this.m_EInput_Password_TMP_InputField = null;
            this.m_EInput_Password_Image = null;
            this.m_EB_Login_Button = null;
            this.m_EB_Login_Image = null;
            this.m_EB_Register_Button = null;
            this.m_EB_Register_Image = null;
            this.uiTransform = null;
        }
    }
}