
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public partial class Scroll_Item_Equip : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Equip BindTrans(Transform trans)
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
		    			this.m_EI_Icon_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/I_Equip/EI_Icon");
     				}
     				return this.m_EI_Icon_Image;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/I_Equip/EI_Icon");
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
		    			this.m_ET_Name_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/Info/ET_Name");
     				}
     				return this.m_ET_Name_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/Info/ET_Name");
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
		    			this.m_ET_Level_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/Info/Horizontal/ET_Level");
     				}
     				return this.m_ET_Level_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/Info/Horizontal/ET_Level");
     			}
     		}
     	}

		public UnityEngine.UI.Image EI_Compare_Image
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
     				if( this.m_EI_Compare_Image == null )
     				{
		    			this.m_EI_Compare_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/Info/Horizontal/EI_Compare");
     				}
     				return this.m_EI_Compare_Image;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/Info/Horizontal/EI_Compare");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Type_TextMeshProUGUI
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
     				if( this.m_ET_Type_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Type_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/Info/Horizontal/ET_Type");
     				}
     				return this.m_ET_Type_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Content/Info/Horizontal/ET_Type");
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
		    			this.m_EB_Select_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Select");
     				}
     				return this.m_EB_Select_Button;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Select");
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
		    			this.m_EB_Select_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select");
     				}
     				return this.m_EB_Select_Image;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Select");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_Icon_Image = null;
			this.m_ET_Name_TextMeshProUGUI = null;
			this.m_ET_Level_TextMeshProUGUI = null;
			this.m_EI_Compare_Image = null;
			this.m_ET_Type_TextMeshProUGUI = null;
			this.m_EB_Select_Button = null;
			this.m_EB_Select_Image = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EI_Icon_Image = null;
		private TMPro.TextMeshProUGUI m_ET_Name_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Level_TextMeshProUGUI = null;
		private UnityEngine.UI.Image m_EI_Compare_Image = null;
		private TMPro.TextMeshProUGUI m_ET_Type_TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_Select_Button = null;
		private UnityEngine.UI.Image m_EB_Select_Image = null;
		public Transform uiTransform = null;
	}
}
