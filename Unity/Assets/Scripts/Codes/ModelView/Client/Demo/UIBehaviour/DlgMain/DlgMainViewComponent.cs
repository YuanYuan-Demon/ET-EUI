
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMain))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_MiniMap ES_MiniMap
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_minimap == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_MiniMap");
		    	   this.m_es_minimap = this.AddChild<ES_MiniMap,Transform>(subTrans);
     			}
     			return this.m_es_minimap;
     		}
     	}

		public ES_Status ES_CharacterInfo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_characterinfo == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"TopArea/ES_CharacterInfo");
		    	   this.m_es_characterinfo = this.AddChild<ES_Status,Transform>(subTrans);
     			}
     			return this.m_es_characterinfo;
     		}
     	}

		public ES_Status ES_TargetInfo
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_targetinfo == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"TopArea/ES_TargetInfo");
		    	   this.m_es_targetinfo = this.AddChild<ES_Status,Transform>(subTrans);
     			}
     			return this.m_es_targetinfo;
     		}
     	}

		public ES_Team ES_Team
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_team == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_Team");
		    	   this.m_es_team = this.AddChild<ES_Team,Transform>(subTrans);
     			}
     			return this.m_es_team;
     		}
     	}

		public ES_Chat ES_Chat
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_chat == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_Chat");
		    	   this.m_es_chat = this.AddChild<ES_Chat,Transform>(subTrans);
     			}
     			return this.m_es_chat;
     		}
     	}

		public ES_Joystick ES_Joystick
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_joystick == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_Joystick");
		    	   this.m_es_joystick = this.AddChild<ES_Joystick,Transform>(subTrans);
     			}
     			return this.m_es_joystick;
     		}
     	}

		public UnityEngine.UI.Button EB_Setting_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Setting_Button == null )
     			{
		    		this.m_EB_Setting_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Setting");
     			}
     			return this.m_EB_Setting_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Setting_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Setting_Image == null )
     			{
		    		this.m_EB_Setting_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Setting");
     			}
     			return this.m_EB_Setting_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Bag_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Bag_Button == null )
     			{
		    		this.m_EB_Bag_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Bag");
     			}
     			return this.m_EB_Bag_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Bag_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Bag_Image == null )
     			{
		    		this.m_EB_Bag_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Bag");
     			}
     			return this.m_EB_Bag_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Quest_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Quest_Button == null )
     			{
		    		this.m_EB_Quest_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Quest");
     			}
     			return this.m_EB_Quest_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Quest_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Quest_Image == null )
     			{
		    		this.m_EB_Quest_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Quest");
     			}
     			return this.m_EB_Quest_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Equip_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Equip_Button == null )
     			{
		    		this.m_EB_Equip_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Equip");
     			}
     			return this.m_EB_Equip_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Equip_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Equip_Image == null )
     			{
		    		this.m_EB_Equip_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Equip");
     			}
     			return this.m_EB_Equip_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Skill_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Skill_Button == null )
     			{
		    		this.m_EB_Skill_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Skill");
     			}
     			return this.m_EB_Skill_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Skill_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Skill_Image == null )
     			{
		    		this.m_EB_Skill_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Skill");
     			}
     			return this.m_EB_Skill_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Friend_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Friend_Button == null )
     			{
		    		this.m_EB_Friend_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Friend");
     			}
     			return this.m_EB_Friend_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Friend_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Friend_Image == null )
     			{
		    		this.m_EB_Friend_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Friend");
     			}
     			return this.m_EB_Friend_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Guild_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Guild_Button == null )
     			{
		    		this.m_EB_Guild_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Guild");
     			}
     			return this.m_EB_Guild_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Guild_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Guild_Image == null )
     			{
		    		this.m_EB_Guild_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Guild");
     			}
     			return this.m_EB_Guild_Image;
     		}
     	}

		public UnityEngine.UI.Button EB_Ride_Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Ride_Button == null )
     			{
		    		this.m_EB_Ride_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Buttons/EB_Ride");
     			}
     			return this.m_EB_Ride_Button;
     		}
     	}

		public UnityEngine.UI.Image EB_Ride_Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EB_Ride_Image == null )
     			{
		    		this.m_EB_Ride_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Buttons/EB_Ride");
     			}
     			return this.m_EB_Ride_Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_minimap?.Dispose();
			this.m_es_minimap = null;
			this.m_es_characterinfo?.Dispose();
			this.m_es_characterinfo = null;
			this.m_es_targetinfo?.Dispose();
			this.m_es_targetinfo = null;
			this.m_es_team?.Dispose();
			this.m_es_team = null;
			this.m_es_chat?.Dispose();
			this.m_es_chat = null;
			this.m_es_joystick?.Dispose();
			this.m_es_joystick = null;
			this.m_EB_Setting_Button = null;
			this.m_EB_Setting_Image = null;
			this.m_EB_Bag_Button = null;
			this.m_EB_Bag_Image = null;
			this.m_EB_Quest_Button = null;
			this.m_EB_Quest_Image = null;
			this.m_EB_Equip_Button = null;
			this.m_EB_Equip_Image = null;
			this.m_EB_Skill_Button = null;
			this.m_EB_Skill_Image = null;
			this.m_EB_Friend_Button = null;
			this.m_EB_Friend_Image = null;
			this.m_EB_Guild_Button = null;
			this.m_EB_Guild_Image = null;
			this.m_EB_Ride_Button = null;
			this.m_EB_Ride_Image = null;
			this.uiTransform = null;
		}

		private ES_MiniMap m_es_minimap = null;
		private ES_Status m_es_characterinfo = null;
		private ES_Status m_es_targetinfo = null;
		private ES_Team m_es_team = null;
		private ES_Chat m_es_chat = null;
		private ES_Joystick m_es_joystick = null;
		private UnityEngine.UI.Button m_EB_Setting_Button = null;
		private UnityEngine.UI.Image m_EB_Setting_Image = null;
		private UnityEngine.UI.Button m_EB_Bag_Button = null;
		private UnityEngine.UI.Image m_EB_Bag_Image = null;
		private UnityEngine.UI.Button m_EB_Quest_Button = null;
		private UnityEngine.UI.Image m_EB_Quest_Image = null;
		private UnityEngine.UI.Button m_EB_Equip_Button = null;
		private UnityEngine.UI.Image m_EB_Equip_Image = null;
		private UnityEngine.UI.Button m_EB_Skill_Button = null;
		private UnityEngine.UI.Image m_EB_Skill_Image = null;
		private UnityEngine.UI.Button m_EB_Friend_Button = null;
		private UnityEngine.UI.Image m_EB_Friend_Image = null;
		private UnityEngine.UI.Button m_EB_Guild_Button = null;
		private UnityEngine.UI.Image m_EB_Guild_Image = null;
		private UnityEngine.UI.Button m_EB_Ride_Button = null;
		private UnityEngine.UI.Image m_EB_Ride_Image = null;
		public Transform uiTransform = null;
	}
}
