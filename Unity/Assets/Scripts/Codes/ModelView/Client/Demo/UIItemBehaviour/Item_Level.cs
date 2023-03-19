using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_Level : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Level BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text ET_LevelNameText
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
     				if( this.m_ET_LevelNameText == null )
     				{
		    			this.m_ET_LevelNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_LevelName");
     				}
     				return this.m_ET_LevelNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_LevelName");
     			}
     		}
     	}

		public UnityEngine.UI.Text ET_LevelLimitText
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
     				if( this.m_ET_LevelLimitText == null )
     				{
		    			this.m_ET_LevelLimitText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_LevelLimit");
     				}
     				return this.m_ET_LevelLimitText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_LevelLimit");
     			}
     		}
     	}

		public UnityEngine.UI.Button EB_StartButton
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
     				if( this.m_EB_StartButton == null )
     				{
		    			this.m_EB_StartButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Start");
     				}
     				return this.m_EB_StartButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Start");
     			}
     		}
     	}

		public UnityEngine.UI.Image EB_StartImage
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
     				if( this.m_EB_StartImage == null )
     				{
		    			this.m_EB_StartImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Start");
     				}
     				return this.m_EB_StartImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Start");
     			}
     		}
     	}

		public UnityEngine.UI.Text ET_Tip_LevelNotEnoughText
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
     				if( this.m_ET_Tip_LevelNotEnoughText == null )
     				{
		    			this.m_ET_Tip_LevelNotEnoughText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Tip_LevelNotEnough");
     				}
     				return this.m_ET_Tip_LevelNotEnoughText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Tip_LevelNotEnough");
     			}
     		}
     	}

		public UnityEngine.UI.Text ET_Tip_InAdventureText
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
     				if( this.m_ET_Tip_InAdventureText == null )
     				{
		    			this.m_ET_Tip_InAdventureText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Tip_InAdventure");
     				}
     				return this.m_ET_Tip_InAdventureText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Tip_InAdventure");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_LevelNameText = null;
			this.m_ET_LevelLimitText = null;
			this.m_EB_StartButton = null;
			this.m_EB_StartImage = null;
			this.m_ET_Tip_LevelNotEnoughText = null;
			this.m_ET_Tip_InAdventureText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_ET_LevelNameText = null;
		private UnityEngine.UI.Text m_ET_LevelLimitText = null;
		private UnityEngine.UI.Button m_EB_StartButton = null;
		private UnityEngine.UI.Image m_EB_StartImage = null;
		private UnityEngine.UI.Text m_ET_Tip_LevelNotEnoughText = null;
		private UnityEngine.UI.Text m_ET_Tip_InAdventureText = null;
		public Transform uiTransform = null;
	}
}
