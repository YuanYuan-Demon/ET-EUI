
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public partial class ES_TaskInfo : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		private TMPro.TextMeshProUGUI m_ET_TaskName_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Desc_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_Target_TextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ET_RewardBase_TextMeshProUGUI = null;
		private UnityEngine.UI.LoopHList m_EL_RewardItems_LoopHList = null;
		public TMPro.TextMeshProUGUI ET_TaskName_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_TaskName_TextMeshProUGUI == null )
     			{
		    		this.m_ET_TaskName_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Viewport/Content/ET_TaskName");
     			}
     			return this.m_ET_TaskName_TextMeshProUGUI;
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
		    		this.m_ET_Desc_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Viewport/Content/ET_Desc");
     			}
     			return this.m_ET_Desc_TextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_Target_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_Target_TextMeshProUGUI == null )
     			{
		    		this.m_ET_Target_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Viewport/Content/ET_Target");
     			}
     			return this.m_ET_Target_TextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI ET_RewardBase_TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_RewardBase_TextMeshProUGUI == null )
     			{
		    		this.m_ET_RewardBase_TextMeshProUGUI = UIHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Viewport/Content/TaskRewards/ET_RewardBase");
     			}
     			return this.m_ET_RewardBase_TextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.LoopHList EL_RewardItems_LoopHList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EL_RewardItems_LoopHList == null )
     			{
		    		this.m_EL_RewardItems_LoopHList = UIHelper.FindDeepChild<UnityEngine.UI.LoopHList>(this.uiTransform.gameObject,"Viewport/Content/TaskRewards/EL_RewardItems");
     			}
     			return this.m_EL_RewardItems_LoopHList;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_TaskName_TextMeshProUGUI = null;
			this.m_ET_Desc_TextMeshProUGUI = null;
			this.m_ET_Target_TextMeshProUGUI = null;
			this.m_ET_RewardBase_TextMeshProUGUI = null;
			this.m_EL_RewardItems_LoopHList = null;
			this.uiTransform = null;
		}

		public Transform uiTransform = null;


	}
}