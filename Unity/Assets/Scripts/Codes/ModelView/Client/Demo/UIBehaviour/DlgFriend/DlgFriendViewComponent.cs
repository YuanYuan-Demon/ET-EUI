
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFriend))]
	[EnableMethod]
	public  class DlgFriendViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_EB_Close_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/Title/EB_Close");
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
		    		this.m_EB_Close_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/Title/EB_Close");
     			}
     			return this.m_EB_Close_Image;
     		}
     	}

		public UnityEngine.UI.Toggle EToggle_Friends_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EToggle_Friends_Toggle == null )
     			{
		    		this.m_EToggle_Friends_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Panel/Tab/EToggle_Friends");
     			}
     			return this.m_EToggle_Friends_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle EToggle_FriendApply_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EToggle_FriendApply_Toggle == null )
     			{
		    		this.m_EToggle_FriendApply_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Panel/Tab/EToggle_FriendApply");
     			}
     			return this.m_EToggle_FriendApply_Toggle;
     		}
     	}

		public UnityEngine.RectTransform EG_Friends_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Friends_RectTransform == null )
     			{
		    		this.m_EG_Friends_RectTransform = UIHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Panel/EG_Friends");
     			}
     			return this.m_EG_Friends_RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVList EL_Friend_LoopVList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_Friend_LoopVList == null )
     			{
		    		this.m_EL_Friend_LoopVList = UIHelper.FindDeepChild<UnityEngine.UI.LoopVList>(this.uiTransform.gameObject,"Panel/EG_Friends/EL_Friend");
     			}
     			return this.m_EL_Friend_LoopVList;
     		}
     	}

		public UnityEngine.UI.Button EB_AddFriend_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_AddFriend_Button == null )
     			{
		    		this.m_EB_AddFriend_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EG_Friends/Buttons/EB_AddFriend");
     			}
     			return this.m_EB_AddFriend_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_Chat_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Chat_Button == null )
     			{
		    		this.m_EB_Chat_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EG_Friends/Buttons/EB_Chat");
     			}
     			return this.m_EB_Chat_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_Delete_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Delete_Button == null )
     			{
		    		this.m_EB_Delete_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EG_Friends/Buttons/EB_Delete");
     			}
     			return this.m_EB_Delete_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_Team_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Team_Button == null )
     			{
		    		this.m_EB_Team_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EG_Friends/Buttons/EB_Team");
     			}
     			return this.m_EB_Team_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_PK_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_PK_Button == null )
     			{
		    		this.m_EB_PK_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EG_Friends/Buttons/EB_PK");
     			}
     			return this.m_EB_PK_Button;
     		}
     	}

		public UnityEngine.RectTransform EG_Apply_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Apply_RectTransform == null )
     			{
		    		this.m_EG_Apply_RectTransform = UIHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Panel/EG_Apply");
     			}
     			return this.m_EG_Apply_RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVList EL_Apply_LoopVList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_Apply_LoopVList == null )
     			{
		    		this.m_EL_Apply_LoopVList = UIHelper.FindDeepChild<UnityEngine.UI.LoopVList>(this.uiTransform.gameObject,"Panel/EG_Apply/EL_Apply");
     			}
     			return this.m_EL_Apply_LoopVList;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EB_Close_Button = null;
			this.m_EB_Close_Image = null;
			this.m_EToggle_Friends_Toggle = null;
			this.m_EToggle_FriendApply_Toggle = null;
			this.m_EG_Friends_RectTransform = null;
			this.m_EL_Friend_LoopVList = null;
			this.m_EB_AddFriend_Button = null;
			this.m_EB_Chat_Button = null;
			this.m_EB_Delete_Button = null;
			this.m_EB_Team_Button = null;
			this.m_EB_PK_Button = null;
			this.m_EG_Apply_RectTransform = null;
			this.m_EL_Apply_LoopVList = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EB_Close_Button = null;
		private UnityEngine.UI.Image m_EB_Close_Image = null;
		private UnityEngine.UI.Toggle m_EToggle_Friends_Toggle = null;
		private UnityEngine.UI.Toggle m_EToggle_FriendApply_Toggle = null;
		private UnityEngine.RectTransform m_EG_Friends_RectTransform = null;
		private UnityEngine.UI.LoopVList m_EL_Friend_LoopVList = null;
		private UnityEngine.UI.Button m_EB_AddFriend_Button = null;
		private UnityEngine.UI.Button m_EB_Chat_Button = null;
		private UnityEngine.UI.Button m_EB_Delete_Button = null;
		private UnityEngine.UI.Button m_EB_Team_Button = null;
		private UnityEngine.UI.Button m_EB_PK_Button = null;
		private UnityEngine.RectTransform m_EG_Apply_RectTransform = null;
		private UnityEngine.UI.LoopVList m_EL_Apply_LoopVList = null;
		public Transform uiTransform = null;
	}
}
