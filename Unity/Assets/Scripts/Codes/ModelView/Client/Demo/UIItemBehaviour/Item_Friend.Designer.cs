
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public partial class Scroll_Item_Friend : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Friend BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Toggle ET_Select_Toggle
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
     				if( this.m_ET_Select_Toggle == null )
     				{
		    			this.m_ET_Select_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"ET_Select");
     				}
     				return this.m_ET_Select_Toggle;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"ET_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Image ET_Select_Image
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
     				if( this.m_ET_Select_Image == null )
     				{
		    			this.m_ET_Select_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ET_Select");
     				}
     				return this.m_ET_Select_Image;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ET_Select");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Name_TextMeshProUGUI
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
     				if( this.m_ET_Name_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Name_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Name");
     				}
     				return this.m_ET_Name_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Name");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Level_TextMeshProUGUI
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
     				if( this.m_ET_Level_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Level_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Level");
     				}
     				return this.m_ET_Level_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Level");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Class_TextMeshProUGUI
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
     				if( this.m_ET_Class_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Class_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Class");
     				}
     				return this.m_ET_Class_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Class");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Status_TextMeshProUGUI
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
     				if( this.m_ET_Status_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Status_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Status");
     				}
     				return this.m_ET_Status_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Status");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_Select_Toggle = null;
			this.m_ET_Select_Image = null;
			this.m_ET_Name_TextMeshProUGUI = null;
			this.m_ET_Level_TextMeshProUGUI = null;
			this.m_ET_Class_TextMeshProUGUI = null;
			this.m_ET_Status_TextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Toggle m_ET_Select_Toggle = null;
		private UnityEngine.UI.Image m_ET_Select_Image = null;
		private TMPro.TextMeshProUGUI m_ET_Name_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Level_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Class_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Status_TextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
