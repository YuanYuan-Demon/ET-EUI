
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class ES_Status : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Slider ED_HpSlider_Slider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_HpSlider_Slider == null )
     			{
		    		this.m_ED_HpSlider_Slider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ED_HpSlider");
     			}
     			return this.m_ED_HpSlider_Slider;
     		}
     	}

		public UnityEngine.UI.Slider ED_MpSlider_Slider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ED_MpSlider_Slider == null )
     			{
		    		this.m_ED_MpSlider_Slider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"ED_MpSlider");
     			}
     			return this.m_ED_MpSlider_Slider;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ED_HpSlider_Slider = null;
			this.m_ED_MpSlider_Slider = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Slider m_ED_HpSlider_Slider = null;
		private UnityEngine.UI.Slider m_ED_MpSlider_Slider = null;
		public Transform uiTransform = null;
	}
}
