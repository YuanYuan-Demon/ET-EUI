
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial  class ES_EquipSlot : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		private UnityEngine.UI.Image m_EI_Icon_Image = null;
		public UnityEngine.UI.Image EI_Icon_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_Icon_Image == null )
     			{
		    		this.m_EI_Icon_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Icon");
     			}
     			return this.m_EI_Icon_Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_Icon_Image = null;
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}