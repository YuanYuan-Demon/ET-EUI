using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgLobby))]
    [EnableMethod]
    public class DlgLobbyViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_E_EnterMapButton;
        private Image m_E_EnterMapImage;

        private RectTransform m_EGBackGroundRectTransform;
        public Transform uiTransform;

        public RectTransform EGBackGroundRectTransform
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EGBackGroundRectTransform == null)
                {
                    this.m_EGBackGroundRectTransform = UIHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EGBackGround");
                }

                return this.m_EGBackGroundRectTransform;
            }
        }

        public Button E_EnterMapButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_EnterMapButton == null)
                {
                    this.m_E_EnterMapButton = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EGBackGround/E_EnterMap");
                }

                return this.m_E_EnterMapButton;
            }
        }

        public Image E_EnterMapImage
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_E_EnterMapImage == null)
                {
                    this.m_E_EnterMapImage = UIHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "EGBackGround/E_EnterMap");
                }

                return this.m_E_EnterMapImage;
            }
        }

        public void DestroyWidget()
        {
            this.m_EGBackGroundRectTransform = null;
            this.m_E_EnterMapButton = null;
            this.m_E_EnterMapImage = null;
            this.uiTransform = null;
        }
    }
}