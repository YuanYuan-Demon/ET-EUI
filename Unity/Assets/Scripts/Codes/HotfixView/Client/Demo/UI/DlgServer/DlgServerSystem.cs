using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgServer))]
    public static class DlgServerSystem
    {
        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.EB_Confirm_Button.AddListenerAsync(self.OnClickConfirm);
            self.View.ElServerLoopVList.AddItemRefreshListener((transform, index) => { self.OnScrollItemRefreshHandler(transform, index); });
        }

        public static void ShowWindow(this DlgServer self, ShowWindowData contextData = null)
        {
            var count = self.ClientScene().GetComponent<ServerInfosComponent>().ServerInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemServerInfos, count);
            self.View.ElServerLoopVList.SetVisible(true, count);
        }

        public static void HideWindow(this DlgServer self) => self.RemoveUIScrollItems(ref self.ScrollItemServerInfos);

        public static void OnScrollItemRefreshHandler(this DlgServer self, Transform transform, int index)
        {
            var itemServerInfo = self.ScrollItemServerInfos[index].BindTrans(transform);
            var serverInfosComponent = self.ClientScene().GetComponent<ServerInfosComponent>();
            var info = serverInfosComponent.ServerInfos[index];
            itemServerInfo.EI_Bg_Image.color = info.Id == serverInfosComponent.CurServerId? Color.red : Color.cyan;
            itemServerInfo.ET_ServerName_TextMeshProUGUI.SetText(info.ServerName);
            itemServerInfo.EB_Server_Button.AddListener(() => self.OnSelectServer(info.Id));
        }

        public static void OnSelectServer(this DlgServer self, long serverId)
        {
            self.ClientScene().GetComponent<ServerInfosComponent>().CurServerId = (int)serverId;
            Log.Debug($"当前选择的服务器 Id 是:{serverId}");
            self.View.ElServerLoopVList.RefillCells();
        }

        public static async ETTask OnClickConfirm(this DlgServer self)
        {
            var isSelect = self.ClientScene().GetComponent<ServerInfosComponent>().CurServerId != 0;
            if (!isSelect)
            {
                UIComponent.Instance.ShowErrorBox("请先选择区服");
                return;
            }

            try
            {
                var errorCode = await LoginHelper.GetRoles(self.ClientScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    UIComponent.Instance.ShowErrorBox(errorCode);
                    return;
                }

                UIComponent.Instance.CloseWindow(WindowID.WindowID_Server);
                UIComponent.Instance.ShowWindowAsync<DlgRoles>().Coroutine();
            }
            catch (Exception e)
            {
                Log.Error(e);
                UIComponent.Instance.ShowErrorBox(e);
            }
        }
    }
}