
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoles))]
	[EnableMethod]
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_SelectPanel_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectPanel_RectTransform == null )
     			{
		    		this.m_EG_SelectPanel_RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SelectPanel");
     			}
     			return this.m_EG_SelectPanel_RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_Roles_LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_Roles_LoopVerticalScrollRect == null )
     			{
		    		this.m_EL_Roles_LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_SelectPanel/EL_Roles");
     			}
     			return this.m_EL_Roles_LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EB_EnterGame_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_EnterGame_Button == null )
     			{
		    		this.m_EB_EnterGame_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_SelectPanel/EB_EnterGame");
     			}
     			return this.m_EB_EnterGame_Button;
     		}
     	}

		public UnityEngine.RectTransform EG_CreatePanel_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CreatePanel_RectTransform == null )
     			{
		    		this.m_EG_CreatePanel_RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_CreatePanel");
     			}
     			return this.m_EG_CreatePanel_RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_Class_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Class_RectTransform == null )
     			{
		    		this.m_EG_Class_RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_CreatePanel/EG_Class");
     			}
     			return this.m_EG_Class_RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_Toggles_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Toggles_RectTransform == null )
     			{
		    		this.m_EG_Toggles_RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_CreatePanel/EG_Toggles");
     			}
     			return this.m_EG_Toggles_RectTransform;
     		}
     	}

		public TMPro.TMP_InputField EInput_RoleName_TMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RoleName_TMP_InputField == null )
     			{
		    		this.m_EInput_RoleName_TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_CreatePanel/EInput_RoleName");
     			}
     			return this.m_EInput_RoleName_TMP_InputField;
     		}
     	}

		public UnityEngine.UI.Button EB_Create_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Create_Button == null )
     			{
		    		this.m_EB_Create_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_CreatePanel/EB_Create");
     			}
     			return this.m_EB_Create_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_Back_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Back_Button == null )
     			{
		    		this.m_EB_Back_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Back");
     			}
     			return this.m_EB_Back_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SelectPanel_RectTransform = null;
			this.m_EL_Roles_LoopVerticalScrollRect = null;
			this.m_EB_EnterGame_Button = null;
			this.m_EG_CreatePanel_RectTransform = null;
			this.m_EG_Class_RectTransform = null;
			this.m_EG_Toggles_RectTransform = null;
			this.m_EInput_RoleName_TMP_InputField = null;
			this.m_EB_Create_Button = null;
			this.m_EB_Back_Button = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SelectPanel_RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_Roles_LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EB_EnterGame_Button = null;
		private UnityEngine.RectTransform m_EG_CreatePanel_RectTransform = null;
		private UnityEngine.RectTransform m_EG_Class_RectTransform = null;
		private UnityEngine.RectTransform m_EG_Toggles_RectTransform = null;
		private TMPro.TMP_InputField m_EInput_RoleName_TMP_InputField = null;
		private UnityEngine.UI.Button m_EB_Create_Button = null;
		private UnityEngine.UI.Button m_EB_Back_Button = null;
		public Transform uiTransform = null;
	}
}
