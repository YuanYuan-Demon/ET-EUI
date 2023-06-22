
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_BagItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_BagItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EI_Icon_Image
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
     				if( this.m_EI_Icon_Image == null )
     				{
		    			this.m_EI_Icon_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Icon");
     				}
     				return this.m_EI_Icon_Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Icon");
     			}
     		}
     	}

		public UnityEngine.UI.Text ET_Count_Text
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
     				if( this.m_ET_Count_Text == null )
     				{
		    			this.m_ET_Count_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Count");
     				}
     				return this.m_ET_Count_Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Count");
     			}
     		}
     	}

		public UnityEngine.UI.Button EB_Select_Button
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
     				if( this.m_EB_Select_Button == null )
     				{
		    			this.m_EB_Select_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Select");
     				}
     				return this.m_EB_Select_Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Image EB_Select_Image
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
     				if( this.m_EB_Select_Image == null )
     				{
		    			this.m_EB_Select_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select");
     				}
     				return this.m_EB_Select_Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_Icon_Image = null;
			this.m_ET_Count_Text = null;
			this.m_EB_Select_Button = null;
			this.m_EB_Select_Image = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EI_Icon_Image = null;
		private UnityEngine.UI.Text m_ET_Count_Text = null;
		private UnityEngine.UI.Button m_EB_Select_Button = null;
		private UnityEngine.UI.Image m_EB_Select_Image = null;
		public Transform uiTransform = null;
	}
}
