
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLogin))]
	[EnableMethod]
	public  class DlgLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_RegisterPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RegisterPanelRectTransform == null )
     			{
		    		this.m_EG_RegisterPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel");
     			}
     			return this.m_EG_RegisterPanelRectTransform;
     		}
     	}

		public TMPro.TMP_InputField EInput_RegisterAccountTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RegisterAccountTMP_InputField == null )
     			{
		    		this.m_EInput_RegisterAccountTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/Account/EInput_RegisterAccount");
     			}
     			return this.m_EInput_RegisterAccountTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_RegisterAccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RegisterAccountImage == null )
     			{
		    		this.m_EInput_RegisterAccountImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/Account/EInput_RegisterAccount");
     			}
     			return this.m_EInput_RegisterAccountImage;
     		}
     	}

		public TMPro.TMP_InputField EInput_RegisterPasswordTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RegisterPasswordTMP_InputField == null )
     			{
		    		this.m_EInput_RegisterPasswordTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/Password/EInput_RegisterPassword");
     			}
     			return this.m_EInput_RegisterPasswordTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_RegisterPasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RegisterPasswordImage == null )
     			{
		    		this.m_EInput_RegisterPasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/Password/EInput_RegisterPassword");
     			}
     			return this.m_EInput_RegisterPasswordImage;
     		}
     	}

		public TMPro.TMP_InputField EInput_RegisterPassword_ConfirmTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RegisterPassword_ConfirmTMP_InputField == null )
     			{
		    		this.m_EInput_RegisterPassword_ConfirmTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/ConfirmPassword/EInput_RegisterPassword_Confirm");
     			}
     			return this.m_EInput_RegisterPassword_ConfirmTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_RegisterPassword_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RegisterPassword_ConfirmImage == null )
     			{
		    		this.m_EInput_RegisterPassword_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/ConfirmPassword/EInput_RegisterPassword_Confirm");
     			}
     			return this.m_EInput_RegisterPassword_ConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button EB_RegisterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_RegisterButton == null )
     			{
		    		this.m_EB_RegisterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/Buttons/EB_Register");
     			}
     			return this.m_EB_RegisterButton;
     		}
     	}

		public UnityEngine.UI.Button EB_CancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CancelButton == null )
     			{
		    		this.m_EB_CancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/Content/EG_RegisterPanel/Buttons/EB_Cancel");
     			}
     			return this.m_EB_CancelButton;
     		}
     	}

		public UnityEngine.RectTransform EG_LoginPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LoginPanelRectTransform == null )
     			{
		    		this.m_EG_LoginPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel");
     			}
     			return this.m_EG_LoginPanelRectTransform;
     		}
     	}

		public TMPro.TMP_InputField EInput_LoginAccountTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_LoginAccountTMP_InputField == null )
     			{
		    		this.m_EInput_LoginAccountTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel/Account/EInput_LoginAccount");
     			}
     			return this.m_EInput_LoginAccountTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_LoginAccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_LoginAccountImage == null )
     			{
		    		this.m_EInput_LoginAccountImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel/Account/EInput_LoginAccount");
     			}
     			return this.m_EInput_LoginAccountImage;
     		}
     	}

		public TMPro.TMP_InputField EInput_LoginPasswordTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_LoginPasswordTMP_InputField == null )
     			{
		    		this.m_EInput_LoginPasswordTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel/Password/EInput_LoginPassword");
     			}
     			return this.m_EInput_LoginPasswordTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_LoginPasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_LoginPasswordImage == null )
     			{
		    		this.m_EInput_LoginPasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel/Password/EInput_LoginPassword");
     			}
     			return this.m_EInput_LoginPasswordImage;
     		}
     	}

		public UnityEngine.UI.Button EB_LoginButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_LoginButton == null )
     			{
		    		this.m_EB_LoginButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel/Buttons/EB_Login");
     			}
     			return this.m_EB_LoginButton;
     		}
     	}

		public UnityEngine.UI.Button EB_ToRegisterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_ToRegisterButton == null )
     			{
		    		this.m_EB_ToRegisterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/Content/EG_LoginPanel/Buttons/EB_ToRegister");
     			}
     			return this.m_EB_ToRegisterButton;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_RegisterPanelRectTransform = null;
			this.m_EInput_RegisterAccountTMP_InputField = null;
			this.m_EInput_RegisterAccountImage = null;
			this.m_EInput_RegisterPasswordTMP_InputField = null;
			this.m_EInput_RegisterPasswordImage = null;
			this.m_EInput_RegisterPassword_ConfirmTMP_InputField = null;
			this.m_EInput_RegisterPassword_ConfirmImage = null;
			this.m_EB_RegisterButton = null;
			this.m_EB_CancelButton = null;
			this.m_EG_LoginPanelRectTransform = null;
			this.m_EInput_LoginAccountTMP_InputField = null;
			this.m_EInput_LoginAccountImage = null;
			this.m_EInput_LoginPasswordTMP_InputField = null;
			this.m_EInput_LoginPasswordImage = null;
			this.m_EB_LoginButton = null;
			this.m_EB_ToRegisterButton = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_RegisterPanelRectTransform = null;
		private TMPro.TMP_InputField m_EInput_RegisterAccountTMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_RegisterAccountImage = null;
		private TMPro.TMP_InputField m_EInput_RegisterPasswordTMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_RegisterPasswordImage = null;
		private TMPro.TMP_InputField m_EInput_RegisterPassword_ConfirmTMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_RegisterPassword_ConfirmImage = null;
		private UnityEngine.UI.Button m_EB_RegisterButton = null;
		private UnityEngine.UI.Button m_EB_CancelButton = null;
		private UnityEngine.RectTransform m_EG_LoginPanelRectTransform = null;
		private TMPro.TMP_InputField m_EInput_LoginAccountTMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_LoginAccountImage = null;
		private TMPro.TMP_InputField m_EInput_LoginPasswordTMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_LoginPasswordImage = null;
		private UnityEngine.UI.Button m_EB_LoginButton = null;
		private UnityEngine.UI.Button m_EB_ToRegisterButton = null;
		public Transform uiTransform = null;
	}
}
