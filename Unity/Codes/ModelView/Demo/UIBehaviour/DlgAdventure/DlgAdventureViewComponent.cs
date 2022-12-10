
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgAdventureViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.LoopVerticalScrollRect EL_LevelListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_LevelListLoopVerticalScrollRect == null )
     			{
		    		this.m_EL_LevelListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Panel/EL_LevelList");
     			}
     			return this.m_EL_LevelListLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_EB_CloseButton = null;
			this.m_EL_LevelListLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.UI.Button m_EB_CloseButton = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_LevelListLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
