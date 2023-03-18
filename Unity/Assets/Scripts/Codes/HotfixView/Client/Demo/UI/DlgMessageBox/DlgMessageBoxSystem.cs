using DG.Tweening;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgMessageBox))]
    [FriendOfAttribute(typeof(ET.Client.MessageBoxData))]
    public static class DlgMessageBoxSystem
    {
        private static void SetMessageType(MessageBoxType type, DlgMessageBoxViewComponent view)
        {
            for (int i = 0; i < view.EG_PanelRectTransform.childCount; i++)
            {
                view.EG_PanelRectTransform.GetChild(i).gameObject.SetActive(i == ((int)type));
            }
            switch (type)
            {
                case MessageBoxType.Infomation:
                    view.EB_OKButton.SetVisible(true);
                    view.ET_OKTextMeshProUGUI.SetText("确认");

                    view.EB_CancelButton.SetVisible(false);
                    break;

                case MessageBoxType.Question:
                    view.EB_OKButton.SetVisible(true);
                    view.ET_OKTextMeshProUGUI.SetText("确认");

                    view.EB_CancelButton.SetVisible(true);
                    view.ET_CancelTextMeshProUGUI.SetText("取消");
                    break;

                case MessageBoxType.Error:
                    view.EB_OKButton.SetVisible(false);

                    view.EB_CancelButton.SetVisible(true);
                    view.ET_CancelTextMeshProUGUI.SetText("确认");
                    break;

                default:
                    break;
            }
        }

        public static void RegisterUIEvent(this DlgMessageBox self)
        {
            self.RegisterCloseEvent<DlgMessageBox>(self.View.EB_CancelButton);
            self.RegisterCloseEvent<DlgMessageBox>(self.View.EB_OKButton);
        }

        public static void ShowWindow(this DlgMessageBox self, Entity contextData = null)
        {
            self.MessageBoxData = contextData as MessageBoxData;
            self.View.EG_PanelRectTransform.DOScale(Vector3.one, 0.3f).onComplete += () => self.Refresh();
        }

        public static void HideWindow(this DlgMessageBox self, Entity contextData = null)
        {
            self.View.EG_PanelRectTransform.DOScale(Vector3.zero, 0.3f);
        }

        /// <summary>
        /// 刷新UI
        /// </summary>
        /// <param name="self"></param>
        public static void Refresh(this DlgMessageBox self)
        {
            if (self.MessageBoxData != null)
            {
                MessageBoxData messageBoxData = self.MessageBoxData;
                var view = self.View;

                SetMessageType(messageBoxData.MessageType, view);
                view.ET_TitleTextMeshProUGUI.SetText(messageBoxData.Title);
                view.ET_MessageTextMeshProUGUI.SetText(messageBoxData.Message);

                if (!string.IsNullOrEmpty(messageBoxData.OKText))
                    view.ET_OKTextMeshProUGUI.SetText(messageBoxData.OKText);
                if (!string.IsNullOrEmpty(messageBoxData.CancelText))
                    view.ET_CancelTextMeshProUGUI.SetText(messageBoxData.CancelText);
            }
        }
    }
}