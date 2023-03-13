
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Task : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Task BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public TMPro.TextMeshProUGUI ET_TaskNameTextMeshProUGUI
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
     				if( this.m_ET_TaskNameTextMeshProUGUI == null )
     				{
		    			this.m_ET_TaskNameTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Title/ET_TaskName");
     				}
     				return this.m_ET_TaskNameTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Title/ET_TaskName");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_TaskDescTextMeshProUGUI
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
     				if( this.m_ET_TaskDescTextMeshProUGUI == null )
     				{
		    			this.m_ET_TaskDescTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/ET_TaskDesc");
     				}
     				return this.m_ET_TaskDescTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/ET_TaskDesc");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_TaskProcessTextMeshProUGUI
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
     				if( this.m_ET_TaskProcessTextMeshProUGUI == null )
     				{
		    			this.m_ET_TaskProcessTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/ET_TaskProcess");
     				}
     				return this.m_ET_TaskProcessTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/ET_TaskProcess");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_TaskRewardTextMeshProUGUI
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
     				if( this.m_ET_TaskRewardTextMeshProUGUI == null )
     				{
		    			this.m_ET_TaskRewardTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/ET_TaskReward");
     				}
     				return this.m_ET_TaskRewardTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/ET_TaskReward");
     			}
     		}
     	}

		public UnityEngine.UI.Button EB_SubmitButton
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
     				if( this.m_EB_SubmitButton == null )
     				{
		    			this.m_EB_SubmitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Submit");
     				}
     				return this.m_EB_SubmitButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Submit");
     			}
     		}
     	}

		public UnityEngine.UI.Image EB_SubmitImage
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
     				if( this.m_EB_SubmitImage == null )
     				{
		    			this.m_EB_SubmitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Submit");
     				}
     				return this.m_EB_SubmitImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Submit");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_LabelTextMeshProUGUI
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
     				if( this.m_ET_LabelTextMeshProUGUI == null )
     				{
		    			this.m_ET_LabelTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EB_Submit/ET_Label");
     				}
     				return this.m_ET_LabelTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EB_Submit/ET_Label");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_TaskNameTextMeshProUGUI = null;
			this.m_ET_TaskDescTextMeshProUGUI = null;
			this.m_ET_TaskProcessTextMeshProUGUI = null;
			this.m_ET_TaskRewardTextMeshProUGUI = null;
			this.m_EB_SubmitButton = null;
			this.m_EB_SubmitImage = null;
			this.m_ET_LabelTextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private TMPro.TextMeshProUGUI m_ET_TaskNameTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_TaskDescTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_TaskProcessTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_TaskRewardTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_SubmitButton = null;
		private UnityEngine.UI.Image m_EB_SubmitImage = null;
		private TMPro.TextMeshProUGUI m_ET_LabelTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
