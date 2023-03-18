
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMessageBox))]
	[EnableMethod]
	public  class DlgMessageBoxViewComponent : Entity,IAwake,IDestroy 
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

		public TMPro.TextMeshProUGUI ET_TitleTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_TitleTextMeshProUGUI == null )
     			{
		    		this.m_ET_TitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/TitleBar/ET_Title");
     			}
     			return this.m_ET_TitleTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Image EI_InformationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_InformationImage == null )
     			{
		    		this.m_EI_InformationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Message/Icons/EI_Information");
     			}
     			return this.m_EI_InformationImage;
     		}
     	}

		public UnityEngine.UI.Image EI_QuestionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_QuestionImage == null )
     			{
		    		this.m_EI_QuestionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Message/Icons/EI_Question");
     			}
     			return this.m_EI_QuestionImage;
     		}
     	}

		public UnityEngine.UI.Image EI_ErrorImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_ErrorImage == null )
     			{
		    		this.m_EI_ErrorImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Message/Icons/EI_Error");
     			}
     			return this.m_EI_ErrorImage;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_MessageTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_MessageTextMeshProUGUI == null )
     			{
		    		this.m_ET_MessageTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Message/ET_Message");
     			}
     			return this.m_ET_MessageTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_OKButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_OKButton == null )
     			{
		    		this.m_EB_OKButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Panel/Buttons/EB_OK");
     			}
     			return this.m_EB_OKButton;
     		}
     	}

		public UnityEngine.UI.Image EB_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_OKImage == null )
     			{
		    		this.m_EB_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Buttons/EB_OK");
     			}
     			return this.m_EB_OKImage;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_OKTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_OKTextMeshProUGUI == null )
     			{
		    		this.m_ET_OKTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Buttons/EB_OK/ET_OK");
     			}
     			return this.m_ET_OKTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_CancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CancelButton == null )
     			{
		    		this.m_EB_CancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Panel/Buttons/EB_Cancel");
     			}
     			return this.m_EB_CancelButton;
     		}
     	}

		public UnityEngine.UI.Image EB_CancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CancelImage == null )
     			{
		    		this.m_EB_CancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Buttons/EB_Cancel");
     			}
     			return this.m_EB_CancelImage;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_CancelTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_CancelTextMeshProUGUI == null )
     			{
		    		this.m_ET_CancelTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Buttons/EB_Cancel/ET_Cancel");
     			}
     			return this.m_ET_CancelTextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_ET_TitleTextMeshProUGUI = null;
			this.m_EI_InformationImage = null;
			this.m_EI_QuestionImage = null;
			this.m_EI_ErrorImage = null;
			this.m_ET_MessageTextMeshProUGUI = null;
			this.m_EB_OKButton = null;
			this.m_EB_OKImage = null;
			this.m_ET_OKTextMeshProUGUI = null;
			this.m_EB_CancelButton = null;
			this.m_EB_CancelImage = null;
			this.m_ET_CancelTextMeshProUGUI = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private TMPro.TextMeshProUGUI m_ET_TitleTextMeshProUGUI = null;
		private UnityEngine.UI.Image m_EI_InformationImage = null;
		private UnityEngine.UI.Image m_EI_QuestionImage = null;
		private UnityEngine.UI.Image m_EI_ErrorImage = null;
		private TMPro.TextMeshProUGUI m_ET_MessageTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_OKButton = null;
		private UnityEngine.UI.Image m_EB_OKImage = null;
		private TMPro.TextMeshProUGUI m_ET_OKTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_CancelButton = null;
		private UnityEngine.UI.Image m_EB_CancelImage = null;
		private TMPro.TextMeshProUGUI m_ET_CancelTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
