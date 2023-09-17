
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class ES_Slider : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
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
		    		this.m_ED_Slider_Slider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ED_Slider");
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
		    		this.m_ET_Text_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Text");
     			}
     			return this.m_ET_Text_TextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ED_Slider_Slider = null;
			this.m_ET_Text_TextMeshProUGUI = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Slider m_ED_Slider_Slider = null;
		private TMPro.TextMeshProUGUI m_ET_Text_TextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
