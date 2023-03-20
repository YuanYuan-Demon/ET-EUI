
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgItemPopUp))]
	[EnableMethod]
	public  class DlgItemPopUpViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EB_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CloseButton == null )
     			{
		    		this.m_EB_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EB_Close");
     			}
     			return this.m_EB_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image EB_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_CloseImage == null )
     			{
		    		this.m_EB_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EB_Close");
     			}
     			return this.m_EB_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PanelRectTransform == null )
     			{
		    		this.m_EG_PanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Panel");
     			}
     			return this.m_EG_PanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Image EI_QualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_QualityImage == null )
     			{
		    		this.m_EI_QualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/ItemDescription/EI_Quality");
     			}
     			return this.m_EI_QualityImage;
     		}
     	}

		public UnityEngine.UI.Image EI_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_IconImage == null )
     			{
		    		this.m_EI_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/ItemDescription/EI_Quality/EI_Icon");
     			}
     			return this.m_EI_IconImage;
     		}
     	}

		public UnityEngine.UI.Text ET_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_NameText == null )
     			{
		    		this.m_ET_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Panel/ItemDescription/ET_Name");
     			}
     			return this.m_ET_NameText;
     		}
     	}

		public UnityEngine.UI.Text ET_DescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_DescText == null )
     			{
		    		this.m_ET_DescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Panel/ItemDescription/ET_Desc");
     			}
     			return this.m_ET_DescText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect EL_EntrysLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_EntrysLoopVerticalScrollRect == null )
     			{
		    		this.m_EL_EntrysLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Panel/EL_Entrys");
     			}
     			return this.m_EL_EntrysLoopVerticalScrollRect;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_EvaluationTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_EvaluationTextMeshProUGUI == null )
     			{
		    		this.m_ET_EvaluationTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/ET_Evaluation");
     			}
     			return this.m_ET_EvaluationTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button EB_EquipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_EquipButton == null )
     			{
		    		this.m_EB_EquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonGroup/EB_Equip");
     			}
     			return this.m_EB_EquipButton;
     		}
     	}

		public UnityEngine.UI.Image EB_EquipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_EquipImage == null )
     			{
		    		this.m_EB_EquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonGroup/EB_Equip");
     			}
     			return this.m_EB_EquipImage;
     		}
     	}

		public UnityEngine.UI.Button EB_UnEquipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_UnEquipButton == null )
     			{
		    		this.m_EB_UnEquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonGroup/EB_UnEquip");
     			}
     			return this.m_EB_UnEquipButton;
     		}
     	}

		public UnityEngine.UI.Image EB_UnEquipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_UnEquipImage == null )
     			{
		    		this.m_EB_UnEquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonGroup/EB_UnEquip");
     			}
     			return this.m_EB_UnEquipImage;
     		}
     	}

		public UnityEngine.UI.Button EB_SellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_SellButton == null )
     			{
		    		this.m_EB_SellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ButtonGroup/EB_Sell");
     			}
     			return this.m_EB_SellButton;
     		}
     	}

		public UnityEngine.UI.Image EB_SellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_SellImage == null )
     			{
		    		this.m_EB_SellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ButtonGroup/EB_Sell");
     			}
     			return this.m_EB_SellImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EB_CloseButton = null;
			this.m_EB_CloseImage = null;
			this.m_EG_PanelRectTransform = null;
			this.m_EI_QualityImage = null;
			this.m_EI_IconImage = null;
			this.m_ET_NameText = null;
			this.m_ET_DescText = null;
			this.m_EL_EntrysLoopVerticalScrollRect = null;
			this.m_ET_EvaluationTextMeshProUGUI = null;
			this.m_EB_EquipButton = null;
			this.m_EB_EquipImage = null;
			this.m_EB_UnEquipButton = null;
			this.m_EB_UnEquipImage = null;
			this.m_EB_SellButton = null;
			this.m_EB_SellImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EB_CloseButton = null;
		private UnityEngine.UI.Image m_EB_CloseImage = null;
		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.UI.Image m_EI_QualityImage = null;
		private UnityEngine.UI.Image m_EI_IconImage = null;
		private UnityEngine.UI.Text m_ET_NameText = null;
		private UnityEngine.UI.Text m_ET_DescText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_EL_EntrysLoopVerticalScrollRect = null;
		private TMPro.TextMeshProUGUI m_ET_EvaluationTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_EB_EquipButton = null;
		private UnityEngine.UI.Image m_EB_EquipImage = null;
		private UnityEngine.UI.Button m_EB_UnEquipButton = null;
		private UnityEngine.UI.Image m_EB_UnEquipImage = null;
		private UnityEngine.UI.Button m_EB_SellButton = null;
		private UnityEngine.UI.Image m_EB_SellImage = null;
		public Transform uiTransform = null;
	}
}
