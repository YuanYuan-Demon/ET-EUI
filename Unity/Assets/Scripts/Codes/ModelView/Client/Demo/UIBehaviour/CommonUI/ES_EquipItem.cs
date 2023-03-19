
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class ES_EquipItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EI_QualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_QualityImage == null )
     			{
		    		this.m_EI_QualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Quality");
     			}
     			return this.m_EI_QualityImage;
     		}
     	}

		public UnityEngine.UI.Image EI_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_IconImage == null )
     			{
		    		this.m_EI_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Icon");
     			}
     			return this.m_EI_IconImage;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_LabelTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_LabelTextMeshProUGUI == null )
     			{
		    		this.m_ET_LabelTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EI_Icon/ET_Label");
     			}
     			return this.m_ET_LabelTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_SelectButton == null )
     			{
		    		this.m_EB_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Select");
     			}
     			return this.m_EB_SelectButton;
     		}
     	}

		public UnityEngine.UI.Image EB_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_SelectImage == null )
     			{
		    		this.m_EB_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select");
     			}
     			return this.m_EB_SelectImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_QualityImage = null;
			this.m_EI_IconImage = null;
			this.m_ET_LabelTextMeshProUGUI = null;
			this.m_EB_SelectButton = null;
			this.m_EB_SelectImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EI_QualityImage = null;
		private UnityEngine.UI.Image m_EI_IconImage = null;
		private TMPro.TextMeshProUGUI m_ET_LabelTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_SelectButton = null;
		private UnityEngine.UI.Image m_EB_SelectImage = null;
		public Transform uiTransform = null;
	}
}
