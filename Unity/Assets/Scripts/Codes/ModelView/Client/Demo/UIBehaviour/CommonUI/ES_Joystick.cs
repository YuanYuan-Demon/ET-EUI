using UnityEngine;

namespace ET.Client
{
    [EnableMethod]
    [ChildOf]
    public class ES_Joystick : Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
    {
        private UnityEngine.UI.Image m_E_Bg_Image = null;
        private UnityEngine.EventSystems.EventTrigger m_E_Bg_EventTrigger = null;
        private UnityEngine.UI.Image m_EI_Handle_Image = null;
        public float raidus = 10f;
        public Vector2 originPos = Vector2.zero;
        public Vector2 moveDir = Vector2.zero;
        public Vector2 lastDir = Vector2.zero;
        public float coolTime = 0.5f;
        public bool isUpdate = false;
        public long joyMoveTimerId = 0;
        public Transform uiTransform = null;
        public UnityEngine.UI.Image E_Bg_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_E_Bg_Image == null)
                {
                    this.m_E_Bg_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_Bg");
                }
                return this.m_E_Bg_Image;
            }
        }

        public UnityEngine.EventSystems.EventTrigger E_Bg_EventTrigger
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_E_Bg_EventTrigger == null)
                {
                    this.m_E_Bg_EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject, "E_Bg");
                }
                return this.m_E_Bg_EventTrigger;
            }
        }

        public UnityEngine.UI.Image EI_Handle_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EI_Handle_Image == null)
                {
                    this.m_EI_Handle_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EI_Handle");
                }
                return this.m_EI_Handle_Image;
            }
        }

        public void DestroyWidget()
        {
            this.m_E_Bg_Image = null;
            this.m_E_Bg_EventTrigger = null;
            this.m_EI_Handle_Image = null;
            this.uiTransform = null;
        }
    }
}