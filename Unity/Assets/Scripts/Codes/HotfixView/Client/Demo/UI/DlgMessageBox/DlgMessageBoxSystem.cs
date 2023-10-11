using DG.Tweening;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgMessageBox))]
    [FriendOfAttribute(typeof (MessageBoxData))]
    public static class DlgMessageBoxSystem
    {
        public static void RegisterUIEvent(this DlgMessageBox self)
        {
            self.RegisterCloseEvent<DlgMessageBox>(self.View.EB_Cancel_Button);
            self.RegisterCloseEvent<DlgMessageBox>(self.View.EB_OK_Button);
            self.View.EB_OK_Button.onClick.AddListener(self.OnClickOK);
            self.View.EB_Cancel_Button.onClick.AddListener(self.OnClickCancel);
        }

        public static void ShowWindow(this DlgMessageBox self, ShowWindowData contextData = null)
        {
            self.Refresh(contextData as MessageBoxData);
            self.View.EG_Panel_RectTransform.DOScale(Vector3.one, 0.3f);
        }

        public static void HideWindow(this DlgMessageBox self, Entity contextData = null)
            => self.View.EG_Panel_RectTransform.DOScale(Vector3.zero, 0.3f);

        public static void Refresh(this DlgMessageBox self, MessageBoxData messageBoxData)
        {
            if (messageBoxData != null && self.MessageBoxData != messageBoxData)
            {
                self.MessageBoxData = messageBoxData;
                var view = self.View;

                SetMessageType(messageBoxData.MessageType, view);
                view.ET_Title_TextMeshProUGUI.SetText(messageBoxData.Title);
                view.ET_Message_TextMeshProUGUI.SetText(messageBoxData.Message);
                if (!string.IsNullOrEmpty(messageBoxData.OKText))
                    view.ET_OK_TextMeshProUGUI.SetText(messageBoxData.OKText);

                if (!string.IsNullOrEmpty(messageBoxData.CancelText))
                    view.ET_Cancel_TextMeshProUGUI.SetText(messageBoxData.CancelText);
            }
        }

        private static void SetMessageType(MessageBoxType type, DlgMessageBoxViewComponent view)
        {
            for (var i = 0; i < view.EG_Icons_RectTransform.childCount; i++)
            {
                view.EG_Icons_RectTransform.GetChild(i).gameObject.SetActive(i == (int)type);
            }

            switch (type)
            {
                case MessageBoxType.Infomation:
                case MessageBoxType.Error:
                    view.EB_OK_Button.SetVisible(true);
                    view.EB_Cancel_Button.SetVisible(false);
                    break;

                case MessageBoxType.Question:
                    view.EB_OK_Button.SetVisible(true);
                    view.EB_Cancel_Button.SetVisible(true);
                    break;
            }
        }

        private static void OnClickOK(this DlgMessageBox self) => self.OnYes.Invoke();

        private static void OnClickCancel(this DlgMessageBox self) => self.OnNo.Invoke();
    }
}