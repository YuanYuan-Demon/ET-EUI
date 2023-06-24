
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgForge))]
	[EnableMethod]
	public  class DlgForgeViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_PanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PanelRectTransform == null )
     			{
		    		this.m_EG_PanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Panel");
     			}
     			return this.m_EG_PanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EB_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CloseButton == null )
     			{
		    		this.m_EB_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Panel/EB_Close");
     			}
     			return this.m_EB_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image EB_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CloseImage == null )
     			{
		    		this.m_EB_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/EB_Close");
     			}
     			return this.m_EB_CloseImage;
     		}
     	}

		public ES_MakeQueue ES_MakeQueue1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_makequeue1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Panel/Panel/MakeQueue/ES_MakeQueue1");
		    	   this.m_es_makequeue1 = this.AddChild<ES_MakeQueue,Transform>(subTrans);
     			}
     			return this.m_es_makequeue1;
     		}
     	}

		public ES_MakeQueue ES_MakeQueue2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_makequeue2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Panel/Panel/MakeQueue/ES_MakeQueue2");
		    	   this.m_es_makequeue2 = this.AddChild<ES_MakeQueue,Transform>(subTrans);
     			}
     			return this.m_es_makequeue2;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_ProductionsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_ProductionsLoopVerticalScrollRect == null )
     			{
		    		this.m_EL_ProductionsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Panel/Panel/EL_Productions");
     			}
     			return this.m_EL_ProductionsLoopVerticalScrollRect;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_MaterialTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_MaterialTextMeshProUGUI == null )
     			{
		    		this.m_ET_MaterialTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Panel/MaterialGroup/ET_Material");
     			}
     			return this.m_ET_MaterialTextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_EB_CloseButton = null;
			this.m_EB_CloseImage = null;
			this.m_es_makequeue1?.Dispose();
			this.m_es_makequeue1 = null;
			this.m_es_makequeue2?.Dispose();
			this.m_es_makequeue2 = null;
			this.m_EL_ProductionsLoopVerticalScrollRect = null;
			this.m_ET_MaterialTextMeshProUGUI = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.UI.Button m_EB_CloseButton = null;
		private UnityEngine.UI.Image m_EB_CloseImage = null;
		private ES_MakeQueue m_es_makequeue1 = null;
		private ES_MakeQueue m_es_makequeue2 = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_ProductionsLoopVerticalScrollRect = null;
		private TMPro.TextMeshProUGUI m_ET_MaterialTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
