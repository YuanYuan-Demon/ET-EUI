
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class ES_Team : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text ET_TeamInfo_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ET_TeamInfo_Text == null )
     			{
		    		this.m_ET_TeamInfo_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Header/ET_TeamInfo");
     			}
     			return this.m_ET_TeamInfo_Text;
     		}
     	}

		public UnityEngine.UI.Button EB_Exit_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Exit_Button == null )
     			{
		    		this.m_EB_Exit_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Header/EB_Exit");
     			}
     			return this.m_EB_Exit_Button;
     		}
     	}

		public ES_TeamItem ES_TeamItem1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_teamitem1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Members/ES_TeamItem1");
		    	   this.m_es_teamitem1 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem1;
     		}
     	}

		public ES_TeamItem ES_TeamItem2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_teamitem2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Members/ES_TeamItem2");
		    	   this.m_es_teamitem2 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem2;
     		}
     	}

		public ES_TeamItem ES_TeamItem3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_teamitem3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Members/ES_TeamItem3");
		    	   this.m_es_teamitem3 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem3;
     		}
     	}

		public ES_TeamItem ES_TeamItem4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_teamitem4 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Members/ES_TeamItem4");
		    	   this.m_es_teamitem4 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem4;
     		}
     	}

		public ES_TeamItem ES_TeamItem5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_teamitem5 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Members/ES_TeamItem5");
		    	   this.m_es_teamitem5 = this.AddChild<ES_TeamItem,Transform>(subTrans);
     			}
     			return this.m_es_teamitem5;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ET_TeamInfo_Text = null;
			this.m_EB_Exit_Button = null;
			this.m_es_teamitem1?.Dispose();
			this.m_es_teamitem1 = null;
			this.m_es_teamitem2?.Dispose();
			this.m_es_teamitem2 = null;
			this.m_es_teamitem3?.Dispose();
			this.m_es_teamitem3 = null;
			this.m_es_teamitem4?.Dispose();
			this.m_es_teamitem4 = null;
			this.m_es_teamitem5?.Dispose();
			this.m_es_teamitem5 = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ET_TeamInfo_Text = null;
		private UnityEngine.UI.Button m_EB_Exit_Button = null;
		private ES_TeamItem m_es_teamitem1 = null;
		private ES_TeamItem m_es_teamitem2 = null;
		private ES_TeamItem m_es_teamitem3 = null;
		private ES_TeamItem m_es_teamitem4 = null;
		private ES_TeamItem m_es_teamitem5 = null;
		public Transform uiTransform = null;
	}
}
