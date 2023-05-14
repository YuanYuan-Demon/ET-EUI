
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class ES_Chat : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button EB_Minilize_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Minilize_Button == null )
     			{
		    		this.m_EB_Minilize_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Settings/EB_Minilize");
     			}
     			return this.m_EB_Minilize_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_ChatSetting_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_ChatSetting_Button == null )
     			{
		    		this.m_EB_ChatSetting_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Settings/EB_ChatSetting");
     			}
     			return this.m_EB_ChatSetting_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_Lock_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Lock_Button == null )
     			{
		    		this.m_EB_Lock_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Settings/EB_Lock");
     			}
     			return this.m_EB_Lock_Button;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_ChatMessage_LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_ChatMessage_LoopVerticalScrollRect == null )
     			{
		    		this.m_EL_ChatMessage_LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EL_ChatMessage");
     			}
     			return this.m_EL_ChatMessage_LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EB_Send_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Send_Button == null )
     			{
		    		this.m_EB_Send_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"InputForm/EB_Send");
     			}
     			return this.m_EB_Send_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EB_Minilize_Button = null;
			this.m_EB_ChatSetting_Button = null;
			this.m_EB_Lock_Button = null;
			this.m_EL_ChatMessage_LoopVerticalScrollRect = null;
			this.m_EB_Send_Button = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EB_Minilize_Button = null;
		private UnityEngine.UI.Button m_EB_ChatSetting_Button = null;
		private UnityEngine.UI.Button m_EB_Lock_Button = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_ChatMessage_LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EB_Send_Button = null;
		public Transform uiTransform = null;
	}
}
