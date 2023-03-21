using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChatMessage : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChatMessage BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public TMPro.TextMeshProUGUI ET_ChatMessageTextMeshProUGUI
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
     				if( this.m_ET_ChatMessageTextMeshProUGUI == null )
     				{
		    			this.m_ET_ChatMessageTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_ChatMessage");
     				}
     				return this.m_ET_ChatMessageTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_ChatMessage");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_ChatMessageTextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private TMPro.TextMeshProUGUI m_ET_ChatMessageTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
