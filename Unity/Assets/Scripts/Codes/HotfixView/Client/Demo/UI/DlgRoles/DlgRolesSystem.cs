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
        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.EB_Create_Button.AddListener(self.OnClickCreateRole);
            //self.View.EB_DeleteRoleButton.AddListener(() => self.OnClickDeleteRole());
            self.View.EB_EnterGame_Button.AddListener(self.OnClickEnter);
            self.View.ElRolesLoopVList.AddItemRefreshListener(self.OnRoleListRefreshHandler);
            ;
            self.View.EB_Back_Button.AddListener(() => self.ShowSelectPanel());
            self.View.EG_Toggles_RectTransform.GetComponent<ToggleGroup>().AddListener(self.OnSelectClass);
        }

        public static void ShowWindow(this DlgRoles self, ShowWindowData contextData = null)
        {
            self.Refresh();
            self.ShowSelectPanel();
        }

        public static void Refresh(this DlgRoles self)
        {
            //在最后添加一个创建角色按钮
            self.RoleInfos = self.ClientScene().GetComponent<RoleInfosComponent>().RoleInfos;
            var count = self.RoleInfos.Count + 1;
            self.AddUIScrollItems(ref self.ScrollItemRoleInfos, count);
            self.View.ElRolesLoopVList.SetVisible(true, count);
        }

        private static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            var itemRole = self.ScrollItemRoleInfos[index].BindTrans(transform);
            var roleInfo = index == self.RoleInfos.Count? default : self.RoleInfos[index];
            itemRole.Refresh(roleInfo);
        }

        /// <summary>
        ///     选择创建角色
        /// </summary>
        /// <param name="self"></param>
        /// <param name="cla"></param>
        private static void OnSelectClass(this DlgRoles self, int cla)
        {
            self.index = cla;
            for (var i = 0; i < 3; i++)
            {
                self.View.EG_Class_RectTransform.GetChild(i).gameObject.SetActive(i == cla);
                var toggleTransform = self.View.EG_Toggles_RectTransform.GetChild(i);
                toggleTransform.GetChild(0).gameObject.SetActive(i != cla);
                toggleTransform.GetChild(1).gameObject.SetActive(i == cla);
                toggleTransform.GetComponent<Toggle>().targetGraphic = toggleTransform.GetComponentInChildren<Image>();
                EventSystem.Instance.Publish(self.ClientScene(), new SelectRoleClass() { RoleClass = (RoleClass)cla + 1 });
            }
        }

        public static void ShowSelectPanel(this DlgRoles self, bool showSelect = true)
        {
            self.View.EG_SelectPanel_RectTransform.gameObject.SetActive(showSelect);
            self.View.EG_CreatePanel_RectTransform.gameObject.SetActive(!showSelect);
            self.View.EB_Back_Button.gameObject.SetActive(!showSelect);
            if (showSelect)
            {
                self.ScrollItemRoleInfos[0].OnSelect();
            }
            else
            {
                self.OnSelectClass(0);
            }
        }

        private static async void OnClickEnter(this DlgRoles self)
        {
            var isSelect = self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId != 0;
            if (!isSelect)
            {
                UIComponent.Instance.ShowErrorBox("请先选择角色");
                return;
            }

            try
            {
                //申请网关负载均衡服务器的token
                var errorCode = await LoginHelper.GetRealmKey(self.ClientScene());
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

#region 角色管理

        private static async void OnClickCreateRole(this DlgRoles self)
        {
            var roleName = self.View.EInput_RoleName_TMP_InputField.text;
            if (string.IsNullOrEmpty(roleName))
            {
                UIComponent.Instance.ShowErrorBox("角色名不能为空");
                return;
            }

            try
            {
                var errorCode = await LoginHelper.CreateRole(self.ClientScene(), roleName, self.index + 1);
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
            var roleId = self.ClientScene().GetComponent<RoleInfosComponent>().CurRoleId;
            if (roleId == 0)
            {
                UIComponent.Instance.ShowErrorBox("请选择需要删除的角色");
                return;
            }

            try
            {
                var errorCode = await LoginHelper.DeleteRole(self.ClientScene(), roleId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.Refresh();
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