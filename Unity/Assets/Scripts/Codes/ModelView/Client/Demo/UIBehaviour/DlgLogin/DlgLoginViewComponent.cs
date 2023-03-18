
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLogin))]
	[EnableMethod]
	public  class DlgLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.InputField EInput_AccountInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_AccountInputField == null )
     			{
		    		this.m_EInput_AccountInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"I_Bg/Account/EInput_Account");
     			}
     			return this.m_EInput_AccountInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_AccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_AccountImage == null )
     			{
		    		this.m_EInput_AccountImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"I_Bg/Account/EInput_Account");
     			}
     			return this.m_EInput_AccountImage;
     		}
     	}

		public UnityEngine.UI.InputField EInput_PasswordInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_PasswordInputField == null )
     			{
		    		this.m_EInput_PasswordInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"I_Bg/Password/EInput_Password");
     			}
     			return this.m_EInput_PasswordInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_PasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_PasswordImage == null )
     			{
		    		this.m_EInput_PasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"I_Bg/Password/EInput_Password");
     			}
     			return this.m_EInput_PasswordImage;
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
		    		this.m_EB_LoginButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"I_Bg/EB_Login");
     			}
     			return this.m_EB_LoginButton;
     		}
     	}

		public UnityEngine.UI.Image EB_LoginImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_LoginImage == null )
     			{
		    		this.m_EB_LoginImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"I_Bg/EB_Login");
     			}
     			return this.m_EB_LoginImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EInput_AccountInputField = null;
			this.m_EInput_AccountImage = null;
			this.m_EInput_PasswordInputField = null;
			this.m_EInput_PasswordImage = null;
			this.m_EB_LoginButton = null;
			this.m_EB_LoginImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.InputField m_EInput_AccountInputField = null;
		private UnityEngine.UI.Image m_EInput_AccountImage = null;
		private UnityEngine.UI.InputField m_EInput_PasswordInputField = null;
		private UnityEngine.UI.Image m_EInput_PasswordImage = null;
		private UnityEngine.UI.Button m_EB_LoginButton = null;
		private UnityEngine.UI.Image m_EB_LoginImage = null;
		public Transform uiTransform = null;
	}
}
