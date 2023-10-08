using ET.EventType;
using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof (RoleInfo))]
    [FriendOfAttribute(typeof (CRoleInfosComponent))]
    [FriendOfAttribute(typeof (Scroll_Item_RoleInfo))]
    public static class Scroll_Item_RoleInfoSystem
    {
        public static void Refresh(this Scroll_Item_RoleInfo self, RoleInfo roleInfo)
        {
            if (roleInfo == default)
            {
                self.DataId = 0;
                self.EI_Avator_Image.overrideSprite = IconHelper.LoadIconSprite("UI_Icons", "Add");
                self.EI_Bg_Image.color = Color.cyan;
                self.ET_Info_TextMeshProUGUI.text = "创建新角色";
                self.EB_Select_Button.AddListener(() => EventSystem.Instance.Publish(self.DomainScene(), new ShowCreateRolePanel()));
            }
            else
            {
                self.RoleInfo = roleInfo;
                self.DataId = roleInfo.Id;
                self.EI_Avator_Image.overrideSprite = null;
                self.EI_Bg_Image.color = Color.cyan;
                self.ET_Info_TextMeshProUGUI.text = $"昵称: {roleInfo.Name}\n等级: {roleInfo.Level}";
                self.EB_Select_Button.AddListener(self.OnSelect);
            }
        }

        public static void OnDeSelect(this Scroll_Item_RoleInfo self) => self.EI_Bg_Image.color = Color.cyan;

        public static void OnSelect(this Scroll_Item_RoleInfo self)
        {
            self.ClientScene().GetComponent<CRoleInfosComponent>().CurRoleId = self.DataId;
            self.EI_Bg_Image.color = Color.red;
            if (self.RoleInfo is not null)
            {
                EventSystem.Instance.Publish(self.ClientScene(), new SelectRole { RoleId = self.DataId });
                EventSystem.Instance.Publish(self.ClientScene(), new SelectRoleClass() { RoleClass = self.RoleInfo.RoleClass });
            }
        }
    }
}