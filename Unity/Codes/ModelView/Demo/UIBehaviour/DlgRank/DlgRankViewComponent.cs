
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRankViewComponent : Entity,IAwake,IDestroy 
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

		public TMPro.TextMeshProUGUI ET_RankTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_RankTextMeshProUGUI == null )
     			{
		    		this.m_ET_RankTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Item_Rank/ET_Rank");
     			}
     			return this.m_ET_RankTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_PlayerNameTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_PlayerNameTextMeshProUGUI == null )
     			{
		    		this.m_ET_PlayerNameTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Item_Rank/ET_PlayerName");
     			}
     			return this.m_ET_PlayerNameTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_LevelTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_LevelTextMeshProUGUI == null )
     			{
		    		this.m_ET_LevelTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/Item_Rank/ET_Level");
     			}
     			return this.m_ET_LevelTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_RankLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_RankLoopVerticalScrollRect == null )
     			{
		    		this.m_EL_RankLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Panel/EL_Rank");
     			}
     			return this.m_EL_RankLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_EB_CloseButton = null;
			this.m_ET_RankTextMeshProUGUI = null;
			this.m_ET_PlayerNameTextMeshProUGUI = null;
			this.m_ET_LevelTextMeshProUGUI = null;
			this.m_EL_RankLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.UI.Button m_EB_CloseButton = null;
		private TMPro.TextMeshProUGUI m_ET_RankTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_PlayerNameTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_LevelTextMeshProUGUI = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_RankLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
