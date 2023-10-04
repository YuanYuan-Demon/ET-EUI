
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public partial class Scroll_Item_Task : Entity,IAwake,IDestroy,IUIScrollItem 
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

		public UnityEngine.UI.Toggle ET_Task_Toggle
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
     				if( this.m_ET_Task_Toggle == null )
     				{
		    			this.m_ET_Task_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"ET_Task");
     				}
     				return this.m_ET_Task_Toggle;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"ET_Task");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_TaskName_TextMeshProUGUI
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
     				if( this.m_ET_TaskName_TextMeshProUGUI == null )
     				{
		    			this.m_ET_TaskName_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_TaskName");
     				}
     				return this.m_ET_TaskName_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_TaskName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_Task_Toggle = null;
			this.m_ET_TaskName_TextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Toggle m_ET_Task_Toggle = null;
		private TMPro.TextMeshProUGUI m_ET_TaskName_TextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
