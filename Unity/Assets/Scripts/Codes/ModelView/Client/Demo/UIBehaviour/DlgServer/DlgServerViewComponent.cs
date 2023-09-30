using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgServer))]
    [EnableMethod]
    public class DlgServerViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Confirm_Button;

        private LoopVerticalScrollRect m_EL_Server_LoopVerticalScrollRect;
        public Transform uiTransform;

        public LoopVerticalScrollRect EL_Server_LoopVerticalScrollRect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_Server_LoopVerticalScrollRect == null)
                {
                    this.m_EL_Server_LoopVerticalScrollRect =
                            UIHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject, "Panel/EL_Server");
                }

                return this.m_EL_Server_LoopVerticalScrollRect;
            }
        }

        public Button EB_Confirm_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Confirm_Button == null)
                {
                    this.m_EB_Confirm_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Panel/EB_Confirm");
                }

                return this.m_EB_Confirm_Button;
            }
        }

        public void DestroyWidget()
        {
            this.m_EL_Server_LoopVerticalScrollRect = null;
            this.m_EB_Confirm_Button = null;
            this.uiTransform = null;
        }
    }
}