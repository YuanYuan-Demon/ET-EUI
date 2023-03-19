using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_Attribute : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Attribute BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text ET_AttributeNameText
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
     				if( this.m_ET_AttributeNameText == null )
     				{
		    			this.m_ET_AttributeNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_AttributeName");
     				}
     				return this.m_ET_AttributeNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_AttributeName");
     			}
     		}
     	}

		public UnityEngine.UI.Text ET_AttributeValueText
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
     				if( this.m_ET_AttributeValueText == null )
     				{
		    			this.m_ET_AttributeValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_AttributeValue");
     				}
     				return this.m_ET_AttributeValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_AttributeValue");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_AttributeNameText = null;
			this.m_ET_AttributeValueText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_ET_AttributeNameText = null;
		private UnityEngine.UI.Text m_ET_AttributeValueText = null;
		public Transform uiTransform = null;
	}
}
