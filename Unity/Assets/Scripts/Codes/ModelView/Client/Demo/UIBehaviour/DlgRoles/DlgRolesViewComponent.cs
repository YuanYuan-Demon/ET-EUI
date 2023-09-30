using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgRoles))]
    [EnableMethod]
    public class DlgRolesViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Back_Button;
        private Button m_EB_Create_Button;
        private Button m_EB_EnterGame_Button;
        private RectTransform m_EG_Class_RectTransform;
        private RectTransform m_EG_CreatePanel_RectTransform;

        private RectTransform m_EG_SelectPanel_RectTransform;
        private RectTransform m_EG_Toggles_RectTransform;
        private TMP_InputField m_EInput_RoleName_TMP_InputField;
        private LoopVerticalScrollRect m_EL_Roles_LoopVerticalScrollRect;
        public Transform uiTransform;

        public RectTransform EG_SelectPanel_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_SelectPanel_RectTransform == null)
                {
                    this.m_EG_SelectPanel_RectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_SelectPanel");
                }

                return this.m_EG_SelectPanel_RectTransform;
            }
        }

        public LoopVerticalScrollRect EL_Roles_LoopVerticalScrollRect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_Roles_LoopVerticalScrollRect == null)
                {
                    this.m_EL_Roles_LoopVerticalScrollRect =
                            UIHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject, "EG_SelectPanel/EL_Roles");
                }

                return this.m_EL_Roles_LoopVerticalScrollRect;
            }
        }

        public Button EB_EnterGame_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_EnterGame_Button == null)
                {
                    this.m_EB_EnterGame_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EG_SelectPanel/EB_EnterGame");
                }

                return this.m_EB_EnterGame_Button;
            }
        }

        public RectTransform EG_CreatePanel_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_CreatePanel_RectTransform == null)
                {
                    this.m_EG_CreatePanel_RectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_CreatePanel");
                }

                return this.m_EG_CreatePanel_RectTransform;
            }
        }

        public RectTransform EG_Class_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_Class_RectTransform == null)
                {
                    this.m_EG_Class_RectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_CreatePanel/EG_Class");
                }

                return this.m_EG_Class_RectTransform;
            }
        }

        public RectTransform EG_Toggles_RectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EG_Toggles_RectTransform == null)
                {
                    this.m_EG_Toggles_RectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_CreatePanel/EG_Toggles");
                }

                return this.m_EG_Toggles_RectTransform;
            }
        }

        public TMP_InputField EInput_RoleName_TMP_InputField
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EInput_RoleName_TMP_InputField == null)
                {
                    this.m_EInput_RoleName_TMP_InputField =
                            UIHelper.FindDeepChild<TMP_InputField>(this.uiTransform.gameObject, "EG_CreatePanel/EInput_RoleName");
                }

                return this.m_EInput_RoleName_TMP_InputField;
            }
        }

        public Button EB_Create_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Create_Button == null)
                {
                    this.m_EB_Create_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EG_CreatePanel/EB_Create");
                }

                return this.m_EB_Create_Button;
            }
        }

        public Button EB_Back_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Back_Button == null)
                {
                    this.m_EB_Back_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EB_Back");
                }

                return this.m_EB_Back_Button;
            }
        }

        public void DestroyWidget()
        {
            this.m_EG_SelectPanel_RectTransform = null;
            this.m_EL_Roles_LoopVerticalScrollRect = null;
            this.m_EB_EnterGame_Button = null;
            this.m_EG_CreatePanel_RectTransform = null;
            this.m_EG_Class_RectTransform = null;
            this.m_EG_Toggles_RectTransform = null;
            this.m_EInput_RoleName_TMP_InputField = null;
            this.m_EB_Create_Button = null;
            this.m_EB_Back_Button = null;
            this.uiTransform = null;
        }
    }
}