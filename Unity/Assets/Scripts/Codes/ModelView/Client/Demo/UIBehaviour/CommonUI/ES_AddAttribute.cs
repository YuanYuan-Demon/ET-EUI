using UnityEngine;

namespace ET.Client
{
    [EnableMethod]
    [ChildOf]
    public class ES_AddAttribute : Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
    {
        private TMPro.TextMeshProUGUI m_ET_AttributeNameTextMeshProUGUI = null;

        private TMPro.TextMeshProUGUI m_ET_AttributeValueTextMeshProUGUI = null;

        private UnityEngine.UI.Button m_EB_AddAttributeButton = null;

        public Transform uiTransform = null;

        public TMPro.TextMeshProUGUI ET_AttributeNameTextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_ET_AttributeNameTextMeshProUGUI == null)
                {
                    this.m_ET_AttributeNameTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_AttributeName");
                }
                return this.m_ET_AttributeNameTextMeshProUGUI;
            }
        }

        public TMPro.TextMeshProUGUI ET_AttributeValueTextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_ET_AttributeValueTextMeshProUGUI == null)
                {
                    this.m_ET_AttributeValueTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_AttributeValue");
                }
                return this.m_ET_AttributeValueTextMeshProUGUI;
            }
        }

        public UnityEngine.UI.Button EB_AddAttributeButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EB_AddAttributeButton == null)
                {
                    this.m_EB_AddAttributeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EB_AddAttribute");
                }
                return this.m_EB_AddAttributeButton;
            }
        }

        public void DestroyWidget()
        {
            this.m_ET_AttributeNameTextMeshProUGUI = null;
            this.m_ET_AttributeValueTextMeshProUGUI = null;
            this.m_EB_AddAttributeButton = null;
            this.uiTransform = null;
        }
    }
}