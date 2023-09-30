
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial class ES_TeamItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		private UnityEngine.UI.Slider m_ED_Slider_Slider = null;
		private TMPro.TextMeshProUGUI m_ET_Text_TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_Kick_Button = null;
		public UnityEngine.UI.Slider ED_Slider_Slider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_Slider_Slider == null )
     			{
		    		this.m_ED_Slider_Slider = UIHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"MemberInfo/ED_Hp/ED_Slider");
     			}
     			return this.m_ED_Slider_Slider;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Text_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Text_TextMeshProUGUI == null )
     			{
		    		this.m_ET_Text_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"MemberInfo/ED_Hp/ET_Text");
     			}
     			return this.m_ET_Text_TextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_Kick_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Kick_Button == null )
     			{
		    		this.m_EB_Kick_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"KickOut/EB_Kick");
     			}
     			return this.m_EB_Kick_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ED_Slider_Slider = null;
			this.m_ET_Text_TextMeshProUGUI = null;
			this.m_EB_Kick_Button = null;
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
