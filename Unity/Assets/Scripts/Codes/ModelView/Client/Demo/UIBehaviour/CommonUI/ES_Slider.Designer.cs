
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial class ES_Slider : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		private UnityEngine.UI.Slider m_ED_Slider_Slider = null;
		private TMPro.TextMeshProUGUI m_ET_Desc_TextMeshProUGUI = null;
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
		    		this.m_ED_Slider_Slider = UIHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ED_Slider");
     			}
     			return this.m_ED_Slider_Slider;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Desc_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Desc_TextMeshProUGUI == null )
     			{
		    		this.m_ET_Desc_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"ET_Desc");
     			}
     			return this.m_ET_Desc_TextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ED_Slider_Slider = null;
			this.m_ET_Desc_TextMeshProUGUI = null;
			this.uiTransform = null;
		}

		public Transform uiTransform = null;
	}
}
