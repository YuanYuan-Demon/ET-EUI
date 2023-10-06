
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial class ES_Chat : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		private UnityEngine.UI.Toggle m_EToggle_Close_Toggle = null;
		private UnityEngine.UI.Button m_EB_ChatSetting_Button = null;
		private UnityEngine.UI.Button m_EB_Lock_Button = null;
		private UnityEngine.UI.LoopVList m_EL_ChatContent_LoopVList = null;
		private UnityEngine.RectTransform m_EG_Channels_RectTransform = null;
		private UnityEngine.UI.Toggle m_ETo_All_Toggle = null;
		private UnityEngine.UI.Toggle m_ETo_Local_Toggle = null;
		private UnityEngine.UI.Toggle m_ETo_World_Toggle = null;
		private UnityEngine.UI.Toggle m_ETo_Team_Toggle = null;
		private UnityEngine.UI.Toggle m_ETo_Guild_Toggle = null;
		private UnityEngine.UI.Toggle m_ETo_Private_Toggle = null;
		private UnityEngine.RectTransform m_EG_InputForm_RectTransform = null;
		private TMPro.TMP_Dropdown m_ED_SendChannel_TMP_Dropdown = null;
		private UnityEngine.UI.Image m_ED_SendChannel_Image = null;
		private TMPro.TMP_InputField m_EInput_TMP_InputField = null;
		private UnityEngine.UI.Image m_EInput_Image = null;
		private TMPro.TextMeshProUGUI m_ET_Target_TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_Send_Button = null;
		public UnityEngine.UI.Toggle EToggle_Close_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EToggle_Close_Toggle == null )
     			{
		    		this.m_EToggle_Close_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Settings/EToggle_Close");
     			}
     			return this.m_EToggle_Close_Toggle;
     		}
     	}

		public UnityEngine.UI.Button EB_ChatSetting_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_ChatSetting_Button == null )
     			{
		    		this.m_EB_ChatSetting_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Settings/EB_ChatSetting");
     			}
     			return this.m_EB_ChatSetting_Button;
     		}
     	}

		public UnityEngine.UI.Button EB_Lock_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Lock_Button == null )
     			{
		    		this.m_EB_Lock_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Settings/EB_Lock");
     			}
     			return this.m_EB_Lock_Button;
     		}
     	}

		public UnityEngine.UI.LoopVList EL_ChatContent_LoopVList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_ChatContent_LoopVList == null )
     			{
		    		this.m_EL_ChatContent_LoopVList = UIHelper.FindDeepChild<UnityEngine.UI.LoopVList>(this.uiTransform.gameObject,"EL_ChatContent");
     			}
     			return this.m_EL_ChatContent_LoopVList;
     		}
     	}

		public UnityEngine.RectTransform EG_Channels_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Channels_RectTransform == null )
     			{
		    		this.m_EG_Channels_RectTransform = UIHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Channels");
     			}
     			return this.m_EG_Channels_RectTransform;
     		}
     	}

		public UnityEngine.UI.Toggle ETo_All_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETo_All_Toggle == null )
     			{
		    		this.m_ETo_All_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Channels/ETo_All");
     			}
     			return this.m_ETo_All_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ETo_Local_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETo_Local_Toggle == null )
     			{
		    		this.m_ETo_Local_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Channels/ETo_Local");
     			}
     			return this.m_ETo_Local_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ETo_World_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETo_World_Toggle == null )
     			{
		    		this.m_ETo_World_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Channels/ETo_World");
     			}
     			return this.m_ETo_World_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ETo_Team_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETo_Team_Toggle == null )
     			{
		    		this.m_ETo_Team_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Channels/ETo_Team");
     			}
     			return this.m_ETo_Team_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ETo_Guild_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETo_Guild_Toggle == null )
     			{
		    		this.m_ETo_Guild_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Channels/ETo_Guild");
     			}
     			return this.m_ETo_Guild_Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle ETo_Private_Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETo_Private_Toggle == null )
     			{
		    		this.m_ETo_Private_Toggle = UIHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"EG_Channels/ETo_Private");
     			}
     			return this.m_ETo_Private_Toggle;
     		}
     	}

		public UnityEngine.RectTransform EG_InputForm_RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_InputForm_RectTransform == null )
     			{
		    		this.m_EG_InputForm_RectTransform = UIHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_InputForm");
     			}
     			return this.m_EG_InputForm_RectTransform;
     		}
     	}

		public TMPro.TMP_Dropdown ED_SendChannel_TMP_Dropdown
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_SendChannel_TMP_Dropdown == null )
     			{
		    		this.m_ED_SendChannel_TMP_Dropdown = UIHelper.FindDeepChild<TMPro.TMP_Dropdown>(this.uiTransform.gameObject,"EG_InputForm/ED_SendChannel");
     			}
     			return this.m_ED_SendChannel_TMP_Dropdown;
     		}
     	}

		public UnityEngine.UI.Image ED_SendChannel_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_SendChannel_Image == null )
     			{
		    		this.m_ED_SendChannel_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_InputForm/ED_SendChannel");
     			}
     			return this.m_ED_SendChannel_Image;
     		}
     	}

		public TMPro.TMP_InputField EInput_TMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_TMP_InputField == null )
     			{
		    		this.m_EInput_TMP_InputField = UIHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_InputForm/EInput");
     			}
     			return this.m_EInput_TMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_Image == null )
     			{
		    		this.m_EInput_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_InputForm/EInput");
     			}
     			return this.m_EInput_Image;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Target_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Target_TextMeshProUGUI == null )
     			{
		    		this.m_ET_Target_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_InputForm/EInput/ET_Target");
     			}
     			return this.m_ET_Target_TextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_Send_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Send_Button == null )
     			{
		    		this.m_EB_Send_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_InputForm/EB_Send");
     			}
     			return this.m_EB_Send_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EToggle_Close_Toggle = null;
			this.m_EB_ChatSetting_Button = null;
			this.m_EB_Lock_Button = null;
			this.m_EL_ChatContent_LoopVList = null;
			this.m_EG_Channels_RectTransform = null;
			this.m_ETo_All_Toggle = null;
			this.m_ETo_Local_Toggle = null;
			this.m_ETo_World_Toggle = null;
			this.m_ETo_Team_Toggle = null;
			this.m_ETo_Guild_Toggle = null;
			this.m_ETo_Private_Toggle = null;
			this.m_EG_InputForm_RectTransform = null;
			this.m_ED_SendChannel_TMP_Dropdown = null;
			this.m_ED_SendChannel_Image = null;
			this.m_EInput_TMP_InputField = null;
			this.m_EInput_Image = null;
			this.m_ET_Target_TextMeshProUGUI = null;
			this.m_EB_Send_Button = null;
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
