using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgServer))]
    [EnableMethod]
    public class DlgServerViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Confirm_Button;

        private LoopVList mElServerLoopVList;
        public Transform uiTransform;

        public LoopVList ElServerLoopVList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.mElServerLoopVList == null)
                {
                    this.mElServerLoopVList =
                            UIHelper.FindDeepChild<LoopVList>(this.uiTransform.gameObject, "Panel/EL_Server");
                }

                return this.mElServerLoopVList;
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
            this.mElServerLoopVList = null;
            this.m_EB_Confirm_Button = null;
            this.uiTransform = null;
        }
    }
}