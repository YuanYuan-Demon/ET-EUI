
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image EI_AvatarImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_AvatarImage == null )
     			{
		    		this.m_EI_AvatarImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"TopArea/RoleStatus/EI_Avatar");
     			}
     			return this.m_EI_AvatarImage;
     		}
     	}

		public UnityEngine.UI.Text ET_LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_LevelText == null )
     			{
		    		this.m_ET_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TopArea/RoleStatus/ET_Level");
     			}
     			return this.m_ET_LevelText;
     		}
     	}

		public UnityEngine.UI.Text ET_GoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_GoldText == null )
     			{
		    		this.m_ET_GoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TopArea/Gold/ET_Gold");
     			}
     			return this.m_ET_GoldText;
     		}
     	}

		public UnityEngine.UI.Text ET_ExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_ExpText == null )
     			{
		    		this.m_ET_ExpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TopArea/Exp/ET_Exp");
     			}
     			return this.m_ET_ExpText;
     		}
     	}

		public UnityEngine.UI.Button EB_RoleInfoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_RoleInfoButton == null )
     			{
		    		this.m_EB_RoleInfoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BottomArea/EB_RoleInfo");
     			}
     			return this.m_EB_RoleInfoButton;
     		}
     	}

		public UnityEngine.UI.Image EB_RoleInfoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_RoleInfoImage == null )
     			{
		    		this.m_EB_RoleInfoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BottomArea/EB_RoleInfo");
     			}
     			return this.m_EB_RoleInfoImage;
     		}
     	}

		public UnityEngine.UI.Button EB_ForgeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_ForgeButton == null )
     			{
		    		this.m_EB_ForgeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BottomArea/EB_Forge");
     			}
     			return this.m_EB_ForgeButton;
     		}
     	}

		public UnityEngine.UI.Image EB_ForgeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_ForgeImage == null )
     			{
		    		this.m_EB_ForgeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BottomArea/EB_Forge");
     			}
     			return this.m_EB_ForgeImage;
     		}
     	}

		public UnityEngine.UI.Button EB_AdventureButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_AdventureButton == null )
     			{
		    		this.m_EB_AdventureButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BottomArea/EB_Adventure");
     			}
     			return this.m_EB_AdventureButton;
     		}
     	}

		public UnityEngine.UI.Image EB_AdventureImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_AdventureImage == null )
     			{
		    		this.m_EB_AdventureImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BottomArea/EB_Adventure");
     			}
     			return this.m_EB_AdventureImage;
     		}
     	}

		public UnityEngine.UI.Button EB_TaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_TaskButton == null )
     			{
		    		this.m_EB_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BottomArea/EB_Task");
     			}
     			return this.m_EB_TaskButton;
     		}
     	}

		public UnityEngine.UI.Image EB_TaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_TaskImage == null )
     			{
		    		this.m_EB_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BottomArea/EB_Task");
     			}
     			return this.m_EB_TaskImage;
     		}
     	}

		public UnityEngine.UI.Button EB_StoreButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_StoreButton == null )
     			{
		    		this.m_EB_StoreButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BottomArea/EB_Store");
     			}
     			return this.m_EB_StoreButton;
     		}
     	}

		public UnityEngine.UI.Image EB_StoreImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_StoreImage == null )
     			{
		    		this.m_EB_StoreImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BottomArea/EB_Store");
     			}
     			return this.m_EB_StoreImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_AvatarImage = null;
			this.m_ET_LevelText = null;
			this.m_ET_GoldText = null;
			this.m_ET_ExpText = null;
			this.m_EB_RoleInfoButton = null;
			this.m_EB_RoleInfoImage = null;
			this.m_EB_ForgeButton = null;
			this.m_EB_ForgeImage = null;
			this.m_EB_AdventureButton = null;
			this.m_EB_AdventureImage = null;
			this.m_EB_TaskButton = null;
			this.m_EB_TaskImage = null;
			this.m_EB_StoreButton = null;
			this.m_EB_StoreImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EI_AvatarImage = null;
		private UnityEngine.UI.Text m_ET_LevelText = null;
		private UnityEngine.UI.Text m_ET_GoldText = null;
		private UnityEngine.UI.Text m_ET_ExpText = null;
		private UnityEngine.UI.Button m_EB_RoleInfoButton = null;
		private UnityEngine.UI.Image m_EB_RoleInfoImage = null;
		private UnityEngine.UI.Button m_EB_ForgeButton = null;
		private UnityEngine.UI.Image m_EB_ForgeImage = null;
		private UnityEngine.UI.Button m_EB_AdventureButton = null;
		private UnityEngine.UI.Image m_EB_AdventureImage = null;
		private UnityEngine.UI.Button m_EB_TaskButton = null;
		private UnityEngine.UI.Image m_EB_TaskImage = null;
		private UnityEngine.UI.Button m_EB_StoreButton = null;
		private UnityEngine.UI.Image m_EB_StoreImage = null;
		public Transform uiTransform = null;
	}
}
