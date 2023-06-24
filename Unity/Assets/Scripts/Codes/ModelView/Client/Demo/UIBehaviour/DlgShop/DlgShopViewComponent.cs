
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgShop))]
	[EnableMethod]
	public  class DlgShopViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EB_Close_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Close_Button == null )
     			{
		    		this.m_EB_Close_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/Title/EB_Close");
     			}
     			return this.m_EB_Close_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Close_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Close_Image == null )
     			{
		    		this.m_EB_Close_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Title/EB_Close");
     			}
     			return this.m_EB_Close_Image;
     		}
     	}

		public UnityEngine.UI.ToggleGroup ETG_TabButton_ToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETG_TabButton_ToggleGroup == null )
     			{
		    		this.m_ETG_TabButton_ToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Panel/ETG_TabButton");
     			}
     			return this.m_ETG_TabButton_ToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle ET_All_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_All_Toggle == null )
     			{
		    		this.m_ET_All_Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Panel/ETG_TabButton/ET_All");
     			}
     			return this.m_ET_All_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ET_Equip_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Equip_Toggle == null )
     			{
		    		this.m_ET_Equip_Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Panel/ETG_TabButton/ET_Equip");
     			}
     			return this.m_ET_Equip_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ET_Consumables_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Consumables_Toggle == null )
     			{
		    		this.m_ET_Consumables_Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Panel/ETG_TabButton/ET_Consumables");
     			}
     			return this.m_ET_Consumables_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ET_Material_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Material_Toggle == null )
     			{
		    		this.m_ET_Material_Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Panel/ETG_TabButton/ET_Material");
     			}
     			return this.m_ET_Material_Toggle;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_ShopItem_LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_ShopItem_LoopVerticalScrollRect == null )
     			{
		    		this.m_EL_ShopItem_LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Panel/EL_ShopItem");
     			}
     			return this.m_EL_ShopItem_LoopVerticalScrollRect;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Money_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Money_TextMeshProUGUI == null )
     			{
		    		this.m_ET_Money_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Panel/Money/ET_Money");
     			}
     			return this.m_ET_Money_TextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_Buy_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Buy_Button == null )
     			{
		    		this.m_EB_Buy_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EB_Buy");
     			}
     			return this.m_EB_Buy_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EB_Close_Button = null;
			this.m_EB_Close_Image = null;
			this.m_ETG_TabButton_ToggleGroup = null;
			this.m_ET_All_Toggle = null;
			this.m_ET_Equip_Toggle = null;
			this.m_ET_Consumables_Toggle = null;
			this.m_ET_Material_Toggle = null;
			this.m_EL_ShopItem_LoopVerticalScrollRect = null;
			this.m_ET_Money_TextMeshProUGUI = null;
			this.m_EB_Buy_Button = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EB_Close_Button = null;
		private UnityEngine.UI.Image m_EB_Close_Image = null;
		private UnityEngine.UI.ToggleGroup m_ETG_TabButton_ToggleGroup = null;
		private UnityEngine.UI.Toggle m_ET_All_Toggle = null;
		private UnityEngine.UI.Toggle m_ET_Equip_Toggle = null;
		private UnityEngine.UI.Toggle m_ET_Consumables_Toggle = null;
		private UnityEngine.UI.Toggle m_ET_Material_Toggle = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_ShopItem_LoopVerticalScrollRect = null;
		private TMPro.TextMeshProUGUI m_ET_Money_TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_Buy_Button = null;
		public Transform uiTransform = null;
	}
}
