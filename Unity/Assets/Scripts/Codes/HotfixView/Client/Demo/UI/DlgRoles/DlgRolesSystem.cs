using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoles))]
    [FriendOf(typeof(RoleInfosComponent))]
    [FriendOf(typeof(RoleInfo))]
    public static class DlgRolesSystem
    {
        #region UI事件

        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.EB_CreateRoleButton.onClick.AddListener(() => self.OnClickCreateRole());
            self.View.EB_DeleteRoleButton.onClick.AddListener(() => self.OnClickDeleteRole());
            self.View.EB_EnterGameButton.onClick.AddListener(() => self.OnClickConfirm());
            self.View.ELS_RoleListLoopVerticalScrollRect.AddItemRefreshListener((transform, index) => self.OnRoleListRefreshHandler(transform, index)); ;
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }

        #endregion UI事件

        public static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            var itemRole = self.ScrollItemRoleInfos[index].BindTrans(transform);
            var roleInfosComponent = self.ClientScene().GetComponent<RoleInfosComponent>();
            var roleInfo = roleInfosComponent.RoleInfos[index];
            itemRole.EB_RoleSelectImage.color = roleInfo.Id == roleInfosComponent.CurRoleId ? Color.red : Color.cyan;
            itemRole.EL_RoleText.text = roleInfo.Name;
            itemRole.EB_RoleSelectButton.AddListener(() => self.OnSelectRoleHandler(roleInfo.Id));
        }

        public static void OnSelectRoleHandler(this DlgRoles self, long roleId)
        {
            self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId = roleId;
            self.View.ELS_RoleListLoopVerticalScrollRect.RefillCells();
        }

        public static void RefreshRoleItems(this DlgRoles self)
        {
            int count = self.ClientScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoleInfos, count);
            self.View.ELS_RoleListLoopVerticalScrollRect.SetVisible(true, count);
        }

        #region 角色管理

        private static async void OnClickConfirm(this DlgRoles self)
        {
            bool isSelect = self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId != 0;
            if (!isSelect)
            {
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox("请先选择角色");
                return;
            }

            try
            {
                //申请网关负载均衡服务器的token
                int errorCode = await LoginHelper.GetRealmKey(self.ClientScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(errorCode);
                    return;
                }

                //连接网关负载均衡服务器, 请求进入游戏
                errorCode = await LoginHelper.EnterGame(self.ClientScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(errorCode);
                    return;
                }
                self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
                self.ClientScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Roles);
            }
            catch (Exception e)
            {
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(e);
                Log.Error(e);
            }
        }

        private static async void OnClickCreateRole(this DlgRoles self)
        {
            string roleName = self.View.EIF_RoleNameInputField.text;
            if (string.IsNullOrEmpty(roleName))
            {
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox("角色名不能为空");
                return;
            }
            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ClientScene(), roleName);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(errorCode);
                    return;
                }
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(e);
                Log.Error(e);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="self"> </param>
        private static async void OnClickDeleteRole(this DlgRoles self)
        {
            long roleId = self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId;
            if (roleId == 0)
            {
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox("请选择需要删除的角色");
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
                self.ClientScene().GetComponent<UIComponent>().ShowErrorBox(e);
                Log.Error(e);
            }
        }

        #endregion 角色管理
    }
}