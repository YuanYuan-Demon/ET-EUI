
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial class ES_Joystick : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		private UnityEngine.UI.Image m_E_Bg_Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Bg_EventTrigger = null;
		private UnityEngine.UI.Image m_EI_Handle_Image = null;
		public UnityEngine.UI.Image E_Bg_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Bg_Image == null )
     			{
		    		this.m_E_Bg_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Bg");
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
     			if( this.m_E_Bg_EventTrigger == null )
     			{
		    		this.m_E_Bg_EventTrigger = UIHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Bg");
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
     			if( this.m_EI_Handle_Image == null )
     			{
		    		this.m_EI_Handle_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Handle");
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

		public Transform uiTransform = null;
	}
}
