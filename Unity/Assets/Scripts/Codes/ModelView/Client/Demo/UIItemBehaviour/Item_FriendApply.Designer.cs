
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public partial class Scroll_Item_FriendApply : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_FriendApply BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
		    			this.m_ET_Name_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Name");
     				}
     				return this.m_ET_Name_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Name");
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
		    			this.m_ET_Level_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Level");
     				}
     				return this.m_ET_Level_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Level");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Class_TextMeshProUGUI
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
     				if( this.m_ET_Class_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Class_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Class");
     				}
     				return this.m_ET_Class_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Class");
     			}
     		}
     	}

		public UnityEngine.UI.Button EB_Agree_Button
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
     				if( this.m_EB_Agree_Button == null )
     				{
		    			this.m_EB_Agree_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Info/EB_Agree");
     				}
     				return this.m_EB_Agree_Button;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Info/EB_Agree");
     			}
     		}
     	}

		public UnityEngine.UI.Button EB_Refuse_Button
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
     				if( this.m_EB_Refuse_Button == null )
     				{
		    			this.m_EB_Refuse_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Info/EB_Refuse");
     				}
     				return this.m_EB_Refuse_Button;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Info/EB_Refuse");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Result_TextMeshProUGUI
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
     				if( this.m_ET_Result_TextMeshProUGUI == null )
     				{
		    			this.m_ET_Result_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Result");
     				}
     				return this.m_ET_Result_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Info/ET_Result");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_Name_TextMeshProUGUI = null;
			this.m_ET_Level_TextMeshProUGUI = null;
			this.m_ET_Class_TextMeshProUGUI = null;
			this.m_EB_Agree_Button = null;
			this.m_EB_Refuse_Button = null;
			this.m_ET_Result_TextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private TMPro.TextMeshProUGUI m_ET_Name_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Level_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Class_TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_Agree_Button = null;
		private UnityEngine.UI.Button m_EB_Refuse_Button = null;
		private TMPro.TextMeshProUGUI m_ET_Result_TextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
