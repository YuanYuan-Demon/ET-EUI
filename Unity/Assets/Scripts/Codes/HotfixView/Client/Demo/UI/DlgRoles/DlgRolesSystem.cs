using System;
using ET.EventType;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRoles))]
    [FriendOf(typeof (RoleInfosComponent))]
    [FriendOf(typeof (RoleInfo))]
    public static class DlgRolesSystem
    {
        #region UI事件

        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.EB_Create_Button.AddListener(() => self.OnClickCreateRole());
            //self.View.EB_DeleteRoleButton.AddListener(() => self.OnClickDeleteRole());
            self.View.EB_EnterGame_Button.AddListener(() => self.OnClickEnter());
            self.View.EL_Roles_LoopVerticalScrollRect.AddItemRefreshListener((transform, index) => self.OnRoleListRefreshHandler(transform, index));
            ;
            self.View.EB_Back_Button.AddListener(() => self.ShowSelectPanel());
            self.View.EG_Toggles_RectTransform.GetComponent<ToggleGroup>().AddListener(self.OnSelectClass);
        }

        public static void ShowWindow(this DlgRoles self, ShowWindowData contextData = null)
        {
            self.ShowSelectPanel();
            self.RefreshRoleItems();
        }

        #endregion UI事件

        private static async void OnClickEnter(this DlgRoles self)
        {
            bool isSelect = self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId != 0;
            if (!isSelect)
            {
                UIComponent.Instance.ShowErrorBox("请先选择角色");
                return;
            }

            try
            {
                //申请网关负载均衡服务器的token
                int errorCode = await LoginHelper.GetRealmKey(self.ClientScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    UIComponent.Instance.ShowErrorBox(errorCode);
                    return;
                }

                //连接网关负载均衡服务器, 请求进入游戏
                errorCode = await LoginHelper.EnterGame(self.ClientScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    UIComponent.Instance.ShowErrorBox(errorCode);
                    return;
                }

                UIComponent.Instance.CloseWindow(WindowID.WindowID_Roles);
            }
            catch (Exception e)
            {
                UIComponent.Instance.ShowErrorBox(e);
                Log.Error(e);
            }
        }

        private static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            Scroll_Item_RoleInfo itemRole = self.ScrollItemRoleInfos[index].BindTrans(transform);
            RoleInfosComponent roleInfosComponent = self.ClientScene().GetComponent<RoleInfosComponent>();
            if (index == roleInfosComponent.RoleInfos.Count)
            {
                itemRole.EI_Avator_Image.overrideSprite = IconHelper.LoadIconSprite("UI_Icons", "Add");
                itemRole.EI_Bg_Image.color = Color.cyan;
                itemRole.ET_Info_TextMeshProUGUI.text = "创建新角色";
                itemRole.EB_Select_Button.AddListener(() => self.ShowSelectPanel(false));
            }
            else
            {
                RoleInfo roleInfo = roleInfosComponent.RoleInfos[index];
                itemRole.EI_Avator_Image.overrideSprite = null;
                itemRole.EI_Bg_Image.color = roleInfo.Id == roleInfosComponent.CurRoleId? Color.red : Color.cyan;
                itemRole.ET_Info_TextMeshProUGUI.text = $"昵称: {roleInfo.Name}\n等级: {roleInfo.Level}";
                itemRole.EB_Select_Button.AddListener(() => self.OnSelectRole(roleInfo));
            }
        }

        private static void OnSelectClass(this DlgRoles self, int cla)
        {
            for (var i = 0; i < 3; i++)
            {
                self.View.EG_Class_RectTransform.GetChild(i).gameObject.SetActive(i == cla);
                Transform toggleTransform = self.View.EG_Toggles_RectTransform.GetChild(i);
                toggleTransform.GetChild(0).gameObject.SetActive(i != cla);
                toggleTransform.GetChild(1).gameObject.SetActive(i == cla);
                toggleTransform.GetComponent<Toggle>().targetGraphic = toggleTransform.GetComponentInChildren<Image>();
                EventSystem.Instance.Publish(self.ClientScene(), new SelectRole { RoleClass = (RoleClass)cla });
            }
        }

        private static void OnSelectRole(this DlgRoles self, RoleInfo roleInfo)
        {
            self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId = roleInfo.Id;
            self.View.EL_Roles_LoopVerticalScrollRect.RefillCells();
            EventSystem.Instance.Publish(self.ClientScene(), new SelectRole { RoleClass = roleInfo.RoleClass });
        }

        private static void RefreshRoleItems(this DlgRoles self)
        {
            //在最后添加一个创建角色按钮
            int count = self.ClientScene().GetComponent<RoleInfosComponent>().RoleInfos.Count + 1;
            self.AddUIScrollItems(ref self.ScrollItemRoleInfos, count);
            self.View.EL_Roles_LoopVerticalScrollRect.SetVisible(true, count);
        }

        private static void ShowSelectPanel(this DlgRoles self, bool showSelect = true)
        {
            self.View.EG_SelectPanel_RectTransform.gameObject.SetActive(showSelect);
            self.View.EG_CreatePanel_RectTransform.gameObject.SetActive(!showSelect);
            self.View.EB_Back_Button.gameObject.SetActive(!showSelect);
            if (showSelect)
            {
                var roleInfos = self.ClientScene().GetComponent<RoleInfosComponent>().RoleInfos;
                if (roleInfos.Count > 0)
                {
                    self.OnSelectRole(roleInfos[0]);
                }
            }
            else
            {
                self.OnSelectClass(0);
            }
        }

        #region 角色管理

        private static async void OnClickCreateRole(this DlgRoles self)
        {
            string roleName = self.View.EInput_RoleName_TMP_InputField.text;
            if (string.IsNullOrEmpty(roleName))
            {
                UIComponent.Instance.ShowErrorBox("角色名不能为空");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ClientScene(), roleName);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    UIComponent.Instance.ShowErrorBox(errorCode);
                    return;
                }

                self.ShowWindow();
                //self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                UIComponent.Instance.ShowErrorBox(e);
                Log.Error(e);
            }
        }

        /// <summary>
        ///     删除角色
        /// </summary>
        /// <param name="self"> </param>
        private static async void OnClickDeleteRole(this DlgRoles self)
        {
            long roleId = self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId;
            if (roleId == 0)
            {
                UIComponent.Instance.ShowErrorBox("请选择需要删除的角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.DeleteRole(self.ClientScene(), roleId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                UIComponent.Instance.ShowErrorBox(e);
                Log.Error(e);
            }
        }

        #endregion 角色管理
    }
}