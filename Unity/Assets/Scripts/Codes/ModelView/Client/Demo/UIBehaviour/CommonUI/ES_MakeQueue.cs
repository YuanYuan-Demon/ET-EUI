
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class ES_MakeQueue : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public ES_EquipItem ES_EquipItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItem");
		    	   this.m_es_equipitem = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_TipTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_TipTextMeshProUGUI == null )
     			{
		    		this.m_ET_TipTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Tip");
     			}
     			return this.m_ET_TipTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_MakeTimeTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_MakeTimeTextMeshProUGUI == null )
     			{
		    		this.m_ET_MakeTimeTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_MakeTime");
     			}
     			return this.m_ET_MakeTimeTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Slider ED_ProcessBarSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_ProcessBarSlider == null )
     			{
		    		this.m_ED_ProcessBarSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ED_ProcessBar");
     			}
     			return this.m_ED_ProcessBarSlider;
     		}
     	}

		public UnityEngine.UI.Button EB_GetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_GetButton == null )
     			{
		    		this.m_EB_GetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Get");
     			}
     			return this.m_EB_GetButton;
     		}
     	}

		public UnityEngine.UI.Image EB_GetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_GetImage == null )
     			{
		    		this.m_EB_GetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Get");
     			}
     			return this.m_EB_GetImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_equipitem?.Dispose();
			this.m_es_equipitem = null;
			this.m_ET_TipTextMeshProUGUI = null;
			this.m_ET_MakeTimeTextMeshProUGUI = null;
			this.m_ED_ProcessBarSlider = null;
			this.m_EB_GetButton = null;
			this.m_EB_GetImage = null;
			this.uiTransform = null;
		}

		private ES_EquipItem m_es_equipitem = null;
		private TMPro.TextMeshProUGUI m_ET_TipTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_MakeTimeTextMeshProUGUI = null;
		private UnityEngine.UI.Slider m_ED_ProcessBarSlider = null;
		private UnityEngine.UI.Button m_EB_GetButton = null;
		private UnityEngine.UI.Image m_EB_GetImage = null;
		public Transform uiTransform = null;
	}
}
