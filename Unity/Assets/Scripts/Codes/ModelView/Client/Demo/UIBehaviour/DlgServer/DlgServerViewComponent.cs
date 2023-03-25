
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgServer))]
	[EnableMethod]
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect EL_Server_LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_Server_LoopVerticalScrollRect == null )
     			{
		    		this.m_EL_Server_LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Panel/EL_Server");
     			}
     			return this.m_EL_Server_LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EB_Confirm_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Confirm_Button == null )
     			{
		    		this.m_EB_Confirm_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/EB_Confirm");
     			}
     			return this.m_EB_Confirm_Button;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EL_Server_LoopVerticalScrollRect = null;
			this.m_EB_Confirm_Button = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_EL_Server_LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EB_Confirm_Button = null;
		public Transform uiTransform = null;
	}
}
