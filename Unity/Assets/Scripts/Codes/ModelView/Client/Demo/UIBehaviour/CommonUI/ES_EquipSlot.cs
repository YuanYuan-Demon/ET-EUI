using UnityEngine;

namespace ET.Client
{
    [EnableMethod]
    [ChildOf]
    public class ES_EquipSlot : Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
    {
        private UnityEngine.UI.Image m_EI_Icon_Image = null;
        public Transform uiTransform = null;
        public EquipPosition EquipPosition;

        public UnityEngine.UI.Image EI_Icon_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EI_Icon_Image == null)
                {
                    this.m_EI_Icon_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EI_Icon");
                }
                return this.m_EI_Icon_Image;
            }
        }

        public void DestroyWidget()
        {
            this.m_EI_Icon_Image = null;
            this.uiTransform = null;
        }
    }
}