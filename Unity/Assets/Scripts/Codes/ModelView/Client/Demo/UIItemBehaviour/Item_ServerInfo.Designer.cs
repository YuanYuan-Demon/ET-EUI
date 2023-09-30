
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public partial class Scroll_Item_ServerInfo : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ServerInfo BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button EB_Server_Button
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
     				if( this.m_EB_Server_Button == null )
     				{
		    			this.m_EB_Server_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Server");
     				}
     				return this.m_EB_Server_Button;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Server");
     			}
     		}
     	}

		public UnityEngine.UI.Image EI_Bg_Image
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
     				if( this.m_EI_Bg_Image == null )
     				{
		    			this.m_EI_Bg_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Server/EI_Bg");
     				}
     				return this.m_EI_Bg_Image;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Server/EI_Bg");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI ET_ServerName_TextMeshProUGUI
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
     				if( this.m_ET_ServerName_TextMeshProUGUI == null )
     				{
		    			this.m_ET_ServerName_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EB_Server/ET_ServerName");
     				}
     				return this.m_ET_ServerName_TextMeshProUGUI;
     			}
     			else
     			{
		    		return UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EB_Server/ET_ServerName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EB_Server_Button = null;
			this.m_EI_Bg_Image = null;
			this.m_ET_ServerName_TextMeshProUGUI = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_EB_Server_Button = null;
		private UnityEngine.UI.Image m_EI_Bg_Image = null;
		private TMPro.TextMeshProUGUI m_ET_ServerName_TextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
