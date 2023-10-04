
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial class ES_TaskButton : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		private UnityEngine.UI.Image m_EI_Arrow_Image = null;
		public UnityEngine.UI.Image EI_Arrow_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_Arrow_Image == null )
     			{
		    		this.m_EI_Arrow_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Arrow");
     			}
     			return this.m_EI_Arrow_Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_Arrow_Image = null;
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
