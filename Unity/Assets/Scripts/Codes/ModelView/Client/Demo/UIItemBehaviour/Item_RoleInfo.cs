
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RoleInfo : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RoleInfo BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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

		public UnityEngine.UI.Image EI_Bg_Image
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
     				if( this.m_EI_Bg_Image == null )
     				{
		    			this.m_EI_Bg_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select/EI_Bg");
     				}
     				return this.m_EI_Bg_Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select/EI_Bg");
     			}
     		}
     	}

		public UnityEngine.UI.Image EI_Avator_Image
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
     				if( this.m_EI_Avator_Image == null )
     				{
		    			this.m_EI_Avator_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Avator");
     				}
     				return this.m_EI_Avator_Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Avator");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Info_TextMeshProUGUI
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
     				if( this.m_ET_Info_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Info_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Info");
     				}
     				return this.m_ET_Info_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Info");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EB_Select_Button = null;
			this.m_EI_Bg_Image = null;
			this.m_EI_Avator_Image = null;
			this.m_ET_Info_TextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_EB_Select_Button = null;
		private UnityEngine.UI.Image m_EI_Bg_Image = null;
		private UnityEngine.UI.Image m_EI_Avator_Image = null;
		private TMPro.TextMeshProUGUI m_ET_Info_TextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
