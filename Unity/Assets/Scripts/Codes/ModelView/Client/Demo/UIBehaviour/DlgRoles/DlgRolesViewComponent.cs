﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoles))]
	[EnableMethod]
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect ELS_RoleListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELS_RoleListLoopVerticalScrollRect == null )
     			{
		    		this.m_ELS_RoleListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/ELS_RoleList");
     			}
     			return this.m_ELS_RoleListLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.InputField EIF_RoleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EIF_RoleNameInputField == null )
     			{
		    		this.m_EIF_RoleNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Sprite_BackGround/EIF_RoleName");
     			}
     			return this.m_EIF_RoleNameInputField;
     		}
     	}

		public UnityEngine.UI.Image EIF_RoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EIF_RoleNameImage == null )
     			{
		    		this.m_EIF_RoleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EIF_RoleName");
     			}
     			return this.m_EIF_RoleNameImage;
     		}
     	}

		public UnityEngine.UI.Button EB_DeleteRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_DeleteRoleButton == null )
     			{
		    		this.m_EB_DeleteRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/BottomArea/EB_DeleteRole");
     			}
     			return this.m_EB_DeleteRoleButton;
     		}
     	}

		public UnityEngine.UI.Image EB_DeleteRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_DeleteRoleImage == null )
     			{
		    		this.m_EB_DeleteRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/BottomArea/EB_DeleteRole");
     			}
     			return this.m_EB_DeleteRoleImage;
     		}
     	}

		public UnityEngine.UI.Button EB_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CreateRoleButton == null )
     			{
		    		this.m_EB_CreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/BottomArea/EB_CreateRole");
     			}
     			return this.m_EB_CreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image EB_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CreateRoleImage == null )
     			{
		    		this.m_EB_CreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/BottomArea/EB_CreateRole");
     			}
     			return this.m_EB_CreateRoleImage;
     		}
     	}

		public UnityEngine.UI.Button EB_EnterGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_EnterGameButton == null )
     			{
		    		this.m_EB_EnterGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/BottomArea/EB_EnterGame");
     			}
     			return this.m_EB_EnterGameButton;
     		}
     	}

		public UnityEngine.UI.Image EB_EnterGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_EnterGameImage == null )
     			{
		    		this.m_EB_EnterGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/BottomArea/EB_EnterGame");
     			}
     			return this.m_EB_EnterGameImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELS_RoleListLoopVerticalScrollRect = null;
			this.m_EIF_RoleNameInputField = null;
			this.m_EIF_RoleNameImage = null;
			this.m_EB_DeleteRoleButton = null;
			this.m_EB_DeleteRoleImage = null;
			this.m_EB_CreateRoleButton = null;
			this.m_EB_CreateRoleImage = null;
			this.m_EB_EnterGameButton = null;
			this.m_EB_EnterGameImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_ELS_RoleListLoopVerticalScrollRect = null;
		private UnityEngine.UI.InputField m_EIF_RoleNameInputField = null;
		private UnityEngine.UI.Image m_EIF_RoleNameImage = null;
		private UnityEngine.UI.Button m_EB_DeleteRoleButton = null;
		private UnityEngine.UI.Image m_EB_DeleteRoleImage = null;
		private UnityEngine.UI.Button m_EB_CreateRoleButton = null;
		private UnityEngine.UI.Image m_EB_CreateRoleImage = null;
		private UnityEngine.UI.Button m_EB_EnterGameButton = null;
		private UnityEngine.UI.Image m_EB_EnterGameImage = null;
		public Transform uiTransform = null;
	}
}
