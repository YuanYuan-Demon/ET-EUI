using System;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(DlgRoles))]
    public static class DlgRolesSystem
    {
        public static async void OnConfirmClickHandler(this DlgRoles self)
        {
            bool isSelect = self.ZoneScene().GetComponent<RoleInfosComponent>().CurRoleId != 0;
            if (!isSelect)
            {
                Log.Error("请先选择角色");
                return;
            }

            try
            {
                //申请网关负载均衡服务器的token
                int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                //连接网关负载均衡服务器, 请求进入游戏
                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
                self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Roles);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async void OnCreateRoleClickHandler(this DlgRoles self)
        {
            string roleName = self.View.EIF_RoleNameInputField.text;
            if (string.IsNullOrEmpty(roleName))
            {
                Log.Error("角色名不能为空");
                return;
            }
            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), roleName);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="self"> </param>
        public static async void OnDeleteRoleClickHandler(this DlgRoles self)
        {
            long roleId = self.ZoneScene().GetComponent<RoleInfosComponent>().CurRoleId;
            if (roleId == 0)
            {
                Log.Error("请选择需要删除的角色");
                return;
            }
            try
            {
                int errorCode = await LoginHelper.DeleteRole(self.ZoneScene(), roleId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            var itemRole = self.ScrollItemRoleInfos[index].BindTrans(transform);
            var roleInfosComponent = self.ZoneScene().GetComponent<RoleInfosComponent>();
            var roleInfo = roleInfosComponent.RoleInfos[index];
            itemRole.EB_RoleSelectImage.color = roleInfo.Id == roleInfosComponent.CurRoleId ? Color.red : Color.cyan;
            itemRole.EL_RoleText.text = roleInfo.Name;
            itemRole.EB_RoleSelectButton.AddListener(() => self.OnSelectRoleHandler(roleInfo.Id));
        }

        public static void OnSelectRoleHandler(this DlgRoles self, long roleId)
        {
            self.ZoneScene().GetComponent<RoleInfosComponent>().CurRoleId = roleId;
            self.View.ELS_RoleListLoopVerticalScrollRect.RefillCells();
        }

        public static void RefreshRoleItems(this DlgRoles self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoleInfos, count);
            self.View.ELS_RoleListLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.EB_CreateRoleButton.onClick.AddListener(() => self.OnCreateRoleClickHandler());
            self.View.EB_DeleteRoleButton.onClick.AddListener(() => self.OnDeleteRoleClickHandler());
            self.View.EB_EnterGameButton.onClick.AddListener(() => self.OnConfirmClickHandler());
            self.View.ELS_RoleListLoopVerticalScrollRect.AddItemRefreshListener((transform, index) => self.OnRoleListRefreshHandler(transform, index)); ;
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }
    }
}