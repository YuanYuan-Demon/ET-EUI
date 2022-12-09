
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ES_Equip : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EI_ItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_ItemImage == null )
     			{
		    		this.m_EI_ItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EI_Item");
     			}
     			return this.m_EI_ItemImage;
     		}
     	}

		public UnityEngine.UI.Text ET_EquipLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_EquipLevelText == null )
     			{
		    		this.m_ET_EquipLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ET_EquipLevel");
     			}
     			return this.m_ET_EquipLevelText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EI_ItemImage = null;
			this.m_ET_EquipLevelText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EI_ItemImage = null;
		private UnityEngine.UI.Text m_ET_EquipLevelText = null;
		public Transform uiTransform = null;
	}
}
