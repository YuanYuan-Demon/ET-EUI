
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public partial class Scroll_Item_TaskRewardItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_TaskRewardItem BindTrans(Transform trans)
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
		    			this.m_EI_Icon_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Icon");
     				}
     				return this.m_EI_Icon_Image;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Icon");
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
		    			this.m_ET_Count_Text = UIHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Count");
     				}
     				return this.m_ET_Count_Text;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Count");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_Icon_Image = null;
			this.m_ET_Count_Text = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EI_Icon_Image = null;
		private UnityEngine.UI.Text m_ET_Count_Text = null;
		public Transform uiTransform = null;
	}
}
