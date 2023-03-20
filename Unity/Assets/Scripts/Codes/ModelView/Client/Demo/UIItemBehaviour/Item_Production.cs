using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_Production : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Production BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public ES_EquipItem ES_EquipItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipItem");
		    	   this.m_es_equipitem = this.AddChild<ES_EquipItem,Transform>(subTrans);
     			}
     			return this.m_es_equipitem;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_NameTextMeshProUGUI
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
     				if( this.m_ET_NameTextMeshProUGUI == null )
     				{
		    			this.m_ET_NameTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Name");
     				}
     				return this.m_ET_NameTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Name");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_CostTextMeshProUGUI
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
     				if( this.m_ET_CostTextMeshProUGUI == null )
     				{
		    			this.m_ET_CostTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Cost");
     				}
     				return this.m_ET_CostTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Cost");
     			}
     		}
     	}

		public UnityEngine.UI.Button EB_MakeButton
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
     				if( this.m_EB_MakeButton == null )
     				{
		    			this.m_EB_MakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Make");
     				}
     				return this.m_EB_MakeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Make");
     			}
     		}
     	}

		public UnityEngine.UI.Image EB_MakeImage
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
     				if( this.m_EB_MakeImage == null )
     				{
		    			this.m_EB_MakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Make");
     				}
     				return this.m_EB_MakeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Make");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_equipitem?.Dispose();
			this.m_es_equipitem = null;
			this.m_ET_NameTextMeshProUGUI = null;
			this.m_ET_CostTextMeshProUGUI = null;
			this.m_EB_MakeButton = null;
			this.m_EB_MakeImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private ES_EquipItem m_es_equipitem = null;
		private TMPro.TextMeshProUGUI m_ET_NameTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_CostTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_MakeButton = null;
		private UnityEngine.UI.Image m_EB_MakeImage = null;
		public Transform uiTransform = null;
	}
}
