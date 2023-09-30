using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (DlgMain))]
    [EnableMethod]
    public class DlgMainViewComponent: Entity, IAwake, IDestroy
    {
        private Button m_EB_Bag_Button;
        private Button m_EB_Equip_Button;
        private Button m_EB_Friend_Button;
        private Button m_EB_Guild_Button;
        private Button m_EB_Quest_Button;
        private Button m_EB_Ride_Button;
        private Button m_EB_Setting_Button;
        private Button m_EB_Shop_Button;
        private Button m_EB_Skill_Button;
        private ES_Status m_es_characterinfo;
        private ES_Chat m_es_chat;
        private ES_Joystick m_es_joystick;

        private ES_MiniMap m_es_minimap;
        private ES_Status m_es_targetinfo;
        private ES_Team m_es_team;
        public Transform uiTransform;

        public ES_MiniMap ES_MiniMap
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_minimap == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "ES_MiniMap");
                    this.m_es_minimap = this.AddChild<ES_MiniMap, Transform>(subTrans);
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

                if (this.m_es_characterinfo == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "TopArea/ES_CharacterInfo");
                    this.m_es_characterinfo = this.AddChild<ES_Status, Transform>(subTrans);
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

                if (this.m_es_targetinfo == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "TopArea/ES_TargetInfo");
                    this.m_es_targetinfo = this.AddChild<ES_Status, Transform>(subTrans);
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

                if (this.m_es_team == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "ES_Team");
                    this.m_es_team = this.AddChild<ES_Team, Transform>(subTrans);
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

                if (this.m_es_chat == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "ES_Chat");
                    this.m_es_chat = this.AddChild<ES_Chat, Transform>(subTrans);
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

                if (this.m_es_joystick == null)
                {
                    var subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "ES_Joystick");
                    this.m_es_joystick = this.AddChild<ES_Joystick, Transform>(subTrans);
                }

                return this.m_es_joystick;
            }
        }

        public Button EB_Setting_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Setting_Button == null)
                {
                    this.m_EB_Setting_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Setting");
                }

                return this.m_EB_Setting_Button;
            }
        }

        public Button EB_Bag_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Bag_Button == null)
                {
                    this.m_EB_Bag_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Bag");
                }

                return this.m_EB_Bag_Button;
            }
        }

        public Button EB_Equip_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Equip_Button == null)
                {
                    this.m_EB_Equip_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Equip");
                }

                return this.m_EB_Equip_Button;
            }
        }

        public Button EB_Quest_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Quest_Button == null)
                {
                    this.m_EB_Quest_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Quest");
                }

                return this.m_EB_Quest_Button;
            }
        }

        public Button EB_Skill_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Skill_Button == null)
                {
                    this.m_EB_Skill_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Skill");
                }

                return this.m_EB_Skill_Button;
            }
        }

        public Button EB_Ride_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Ride_Button == null)
                {
                    this.m_EB_Ride_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Ride");
                }

                return this.m_EB_Ride_Button;
            }
        }

        public Button EB_Friend_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Friend_Button == null)
                {
                    this.m_EB_Friend_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Friend");
                }

                return this.m_EB_Friend_Button;
            }
        }

        public Button EB_Guild_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Guild_Button == null)
                {
                    this.m_EB_Guild_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Guild");
                }

                return this.m_EB_Guild_Button;
            }
        }

        public Button EB_Shop_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Shop_Button == null)
                {
                    this.m_EB_Shop_Button = UIHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "Buttons/EB_Shop");
                }

                return this.m_EB_Shop_Button;
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
            this.m_EB_Bag_Button = null;
            this.m_EB_Equip_Button = null;
            this.m_EB_Quest_Button = null;
            this.m_EB_Skill_Button = null;
            this.m_EB_Ride_Button = null;
            this.m_EB_Friend_Button = null;
            this.m_EB_Guild_Button = null;
            this.m_EB_Shop_Button = null;
            this.uiTransform = null;
        }
    }
}