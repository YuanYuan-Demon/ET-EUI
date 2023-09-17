
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class ES_Attribute : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text ET_Value_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Value_Text == null )
     			{
		    		this.m_ET_Value_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_Value");
     			}
     			return this.m_ET_Value_Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_Value_Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ET_Value_Text = null;
		public Transform uiTransform = null;
	}
}
