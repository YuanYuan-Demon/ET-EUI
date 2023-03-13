
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Rank : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Rank BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ET_RankTextMeshProUGUI == null )
     				{
		    			this.m_ET_RankTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Rank");
     				}
     				return this.m_ET_RankTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Rank");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ET_PlayerNameTextMeshProUGUI == null )
     				{
		    			this.m_ET_PlayerNameTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_PlayerName");
     				}
     				return this.m_ET_PlayerNameTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_PlayerName");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ET_LevelTextMeshProUGUI == null )
     				{
		    			this.m_ET_LevelTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Level");
     				}
     				return this.m_ET_LevelTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Level");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_RankTextMeshProUGUI = null;
			this.m_ET_PlayerNameTextMeshProUGUI = null;
			this.m_ET_LevelTextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private TMPro.TextMeshProUGUI m_ET_RankTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_PlayerNameTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_LevelTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
