
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChat))]
	[EnableMethod]
	public  class DlgChatViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.LoopVerticalScrollRect EL_ChatMessageLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_ChatMessageLoopVerticalScrollRect == null )
     			{
		    		this.m_EL_ChatMessageLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Panel/EL_ChatMessage");
     			}
     			return this.m_EL_ChatMessageLoopVerticalScrollRect;
     		}
     	}

		public TMPro.TMP_InputField EInput_InputMessageTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_InputMessageTMP_InputField == null )
     			{
		    		this.m_EInput_InputMessageTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_Panel/Input/EInput_InputMessage");
     			}
     			return this.m_EInput_InputMessageTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_InputMessageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_InputMessageImage == null )
     			{
		    		this.m_EInput_InputMessageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Input/EInput_InputMessage");
     			}
     			return this.m_EInput_InputMessageImage;
     		}
     	}

		public UnityEngine.UI.Button EB_SendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_SendButton == null )
     			{
		    		this.m_EB_SendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Panel/Input/EB_Send");
     			}
     			return this.m_EB_SendButton;
     		}
     	}

		public UnityEngine.UI.Image EB_SendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_SendImage == null )
     			{
		    		this.m_EB_SendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/Input/EB_Send");
     			}
     			return this.m_EB_SendImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_EB_CloseButton = null;
			this.m_EB_CloseImage = null;
			this.m_EL_ChatMessageLoopVerticalScrollRect = null;
			this.m_EInput_InputMessageTMP_InputField = null;
			this.m_EInput_InputMessageImage = null;
			this.m_EB_SendButton = null;
			this.m_EB_SendImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.UI.Button m_EB_CloseButton = null;
		private UnityEngine.UI.Image m_EB_CloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_ChatMessageLoopVerticalScrollRect = null;
		private TMPro.TMP_InputField m_EInput_InputMessageTMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_InputMessageImage = null;
		private UnityEngine.UI.Button m_EB_SendButton = null;
		private UnityEngine.UI.Image m_EB_SendImage = null;
		public Transform uiTransform = null;
	}
}
