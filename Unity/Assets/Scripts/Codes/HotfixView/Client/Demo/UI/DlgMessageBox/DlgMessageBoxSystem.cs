using DG.Tweening;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgMessageBox))]
    [FriendOfAttribute(typeof (MessageBoxData))]
    public static class DlgMessageBoxSystem
    {
        private static void SetMessageType(MessageBoxType type, DlgMessageBoxViewComponent view)
        {
            for (var i = 0; i < view.EG_IconsRectTransform.childCount; i++)
            {
                view.EG_IconsRectTransform.GetChild(i).gameObject.SetActive(i == (int)type);
            }

            switch (type)
            {
                case MessageBoxType.Infomation:
                case MessageBoxType.Error:
                    view.EB_OKButton.SetVisible(true);
                    view.EB_CancelButton.SetVisible(false);
                    break;

                case MessageBoxType.Question:
                    view.EB_OKButton.SetVisible(true);
                    view.EB_CancelButton.SetVisible(true);
                    break;
            }
        }

        private static void OnClickOK(this DlgMessageBox self)
        {
        }

        private static void OnClickCancel(this DlgMessageBox self)
        {
        }

        public static void RegisterUIEvent(this DlgMessageBox self)
        {
            self.RegisterCloseEvent<DlgMessageBox>(self.View.EB_CancelButton);
            self.RegisterCloseEvent<DlgMessageBox>(self.View.EB_OKButton);
            self.View.EB_OKButton.onClick.AddListener(self.OnClickOK);
            self.View.EB_CancelButton.onClick.AddListener(self.OnClickCancel);
        }

        public static void ShowWindow(this DlgMessageBox self, ShowWindowData windowData = null)
        {
            self.Refresh(windowData as MessageBoxData);
            self.View.EG_PanelRectTransform.DOScale(Vector3.one, 0.3f);
        }

        public static void HideWindow(this DlgMessageBox self, Entity contextData = null) =>
                self.View.EG_PanelRectTransform.DOScale(Vector3.zero, 0.3f);

        /// <summary>
        ///     刷新UI
        /// </summary>
        /// <param name="self"></param>
        public static void Refresh(this DlgMessageBox self, MessageBoxData messageBoxData)
        {
            if (messageBoxData != null && self.MessageBoxData != messageBoxData)
            {
                self.MessageBoxData = messageBoxData;
                DlgMessageBoxViewComponent view = self.View;

                SetMessageType(messageBoxData.MessageType, view);
                view.ET_TitleTextMeshProUGUI.SetText(messageBoxData.Title);
                view.ET_MessageTextMeshProUGUI.SetText(messageBoxData.Message);

                if (!string.IsNullOrEmpty(messageBoxData.OKText))
                {
                    view.ET_OKTextMeshProUGUI.SetText(messageBoxData.OKText);
                }

                if (!string.IsNullOrEmpty(messageBoxData.CancelText))
                {
                    view.ET_CancelTextMeshProUGUI.SetText(messageBoxData.CancelText);
                }
            }
        }
    }
}