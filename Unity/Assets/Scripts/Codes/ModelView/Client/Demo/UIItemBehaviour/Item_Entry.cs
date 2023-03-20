using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_Entry : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Entry BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text ET_EntryNameText
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
     				if( this.m_ET_EntryNameText == null )
     				{
		    			this.m_ET_EntryNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_EntryName");
     				}
     				return this.m_ET_EntryNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_EntryName");
     			}
     		}
     	}

		public UnityEngine.UI.Text ET_EntryValueText
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
     				if( this.m_ET_EntryValueText == null )
     				{
		    			this.m_ET_EntryValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_EntryValue");
     				}
     				return this.m_ET_EntryValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_EntryValue");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_EntryNameText = null;
			this.m_ET_EntryValueText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_ET_EntryNameText = null;
		private UnityEngine.UI.Text m_ET_EntryValueText = null;
		public Transform uiTransform = null;
	}
}
