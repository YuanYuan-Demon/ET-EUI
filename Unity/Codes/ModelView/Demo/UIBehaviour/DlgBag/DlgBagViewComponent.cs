
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgBagViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_PanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PanelRectTransform == null )
     			{
		    		this.m_EG_PanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Panel");
     			}
     			return this.m_EG_PanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EB_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CloseButton == null )
     			{
		    		this.m_EB_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Panel/EB_Close");
     			}
     			return this.m_EB_CloseButton;
     		}
     	}

		public UnityEngine.UI.ToggleGroup ETG_TabGroupToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETG_TabGroupToggleGroup == null )
     			{
		    		this.m_ETG_TabGroupToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup");
     			}
     			return this.m_ETG_TabGroupToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle ET_WeaponToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_WeaponToggle == null )
     			{
		    		this.m_ET_WeaponToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Weapon");
     			}
     			return this.m_ET_WeaponToggle;
     		}
     	}

		public UnityEngine.UI.Image ET_WeaponImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_WeaponImage == null )
     			{
		    		this.m_ET_WeaponImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Weapon");
     			}
     			return this.m_ET_WeaponImage;
     		}
     	}

		public UnityEngine.UI.Toggle ET_ArmorToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_ArmorToggle == null )
     			{
		    		this.m_ET_ArmorToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Armor");
     			}
     			return this.m_ET_ArmorToggle;
     		}
     	}

		public UnityEngine.UI.Image ET_ArmorImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_ArmorImage == null )
     			{
		    		this.m_ET_ArmorImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Armor");
     			}
     			return this.m_ET_ArmorImage;
     		}
     	}

		public UnityEngine.UI.Toggle ET_RingToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_RingToggle == null )
     			{
		    		this.m_ET_RingToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Ring");
     			}
     			return this.m_ET_RingToggle;
     		}
     	}

		public UnityEngine.UI.Image ET_RingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_RingImage == null )
     			{
		    		this.m_ET_RingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Ring");
     			}
     			return this.m_ET_RingImage;
     		}
     	}

		public UnityEngine.UI.Toggle ET_ItemToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_ItemToggle == null )
     			{
		    		this.m_ET_ItemToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Item");
     			}
     			return this.m_ET_ItemToggle;
     		}
     	}

		public UnityEngine.UI.Image ET_ItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_ItemImage == null )
     			{
		    		this.m_ET_ItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/ETG_TabGroup/ET_Item");
     			}
     			return this.m_ET_ItemImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_EL_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Panel/EL_BagItems");
     			}
     			return this.m_EL_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_EB_CloseButton = null;
			this.m_ETG_TabGroupToggleGroup = null;
			this.m_ET_WeaponToggle = null;
			this.m_ET_WeaponImage = null;
			this.m_ET_ArmorToggle = null;
			this.m_ET_ArmorImage = null;
			this.m_ET_RingToggle = null;
			this.m_ET_RingImage = null;
			this.m_ET_ItemToggle = null;
			this.m_ET_ItemImage = null;
			this.m_EL_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.UI.Button m_EB_CloseButton = null;
		private UnityEngine.UI.ToggleGroup m_ETG_TabGroupToggleGroup = null;
		private UnityEngine.UI.Toggle m_ET_WeaponToggle = null;
		private UnityEngine.UI.Image m_ET_WeaponImage = null;
		private UnityEngine.UI.Toggle m_ET_ArmorToggle = null;
		private UnityEngine.UI.Image m_ET_ArmorImage = null;
		private UnityEngine.UI.Toggle m_ET_RingToggle = null;
		private UnityEngine.UI.Image m_ET_RingImage = null;
		private UnityEngine.UI.Toggle m_ET_ItemToggle = null;
		private UnityEngine.UI.Image m_ET_ItemImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
