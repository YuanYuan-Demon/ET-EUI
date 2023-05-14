
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class ES_TeamItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Slider ED_Hp_Slider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_Hp_Slider == null )
     			{
		    		this.m_ED_Hp_Slider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"MemberInfo/ED_Hp");
     			}
     			return this.m_ED_Hp_Slider;
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
		    		this.m_EB_Kick_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"KickOut/EB_Kick");
     			}
     			return this.m_EB_Kick_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ED_Hp_Slider = null;
			this.m_EB_Kick_Button = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Slider m_ED_Hp_Slider = null;
		private UnityEngine.UI.Button m_EB_Kick_Button = null;
		public Transform uiTransform = null;
	}
}
