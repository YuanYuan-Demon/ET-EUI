using System;

namespace ET.Client
{
    [FriendOf(typeof(MessageBoxData))]
    public static class DlgMessageBoxHelper
    {
        public static void ShowErrorBox(this UIComponent uiComponent, Exception error)
        {
            uiComponent.ShowMessageBox(MessageBoxType.Error, "异常", error.Message); ;
        }

        public static void ShowErrorBox(this UIComponent uiComponent, int errorCode)
        {
            uiComponent.ShowMessageBox(MessageBoxType.Error, "错误", $"错误码:{errorCode}");
        }

        public static void ShowErrorBox(this UIComponent uiComponent, string message)
        {
            uiComponent.ShowMessageBox(MessageBoxType.Error, "错误", $"{message}");
        }

        public static void ShowInfoBox(this UIComponent uiComponent, string message)
        {
            uiComponent.ShowMessageBox(MessageBoxType.Infomation, "提示", $"{message}");
        }

        public static void ShowQuestBox(this UIComponent uiComponent, string message)
        {
            uiComponent.ShowMessageBox(MessageBoxType.Question, "确认", $"{message}");
        }

        public static void ShowMessageBox(this UIComponent uiComponent, MessageBoxType messageType, string title, string message, string okText = "确定", string cancelText = "取消")
        {
            ShowWindowData showWindowData = new()
            {
                contextData = new MessageBoxData()
                {
                    MessageType = messageType,
                    Title = title,
                    Message = message,
                    OKText = okText,
                    CancelText = cancelText
                }
            };

            uiComponent.ShowWindow(WindowID.WindowID_MessageBox, showWindowData);
        }

        #region Entity拓展

        public static void ShowMessageBox(this Entity entity, MessageBoxType messageType, string title, string message, string okText = "确定", string cancelText = "取消")
        {
            ShowWindowData showWindowData = new()
            {
                contextData = new MessageBoxData()
                {
                    MessageType = messageType,
                    Title = title,
                    Message = message,
                    OKText = okText,
                    CancelText = cancelText
                }
            };

            entity.ShowWindow(WindowID.WindowID_MessageBox, showWindowData);
        }

        public static void ShowErrorBox(this Entity entity, Exception error)
        {
            entity.ShowMessageBox(MessageBoxType.Error, "异常", error.Message); ;
        }

        public static void ShowErrorBox(this Entity entity, int errorCode)
        {
            entity.ShowMessageBox(MessageBoxType.Error, "错误", $"错误码:{errorCode}");
        }

        public static void ShowErrorBox(this Entity entity, string message)
        {
            entity.ShowMessageBox(MessageBoxType.Error, "错误", $"{message}");
        }

        public static void ShowInfoBox(this Entity entity, string message)
        {
            entity.ShowMessageBox(MessageBoxType.Infomation, "提示", $"{message}");
        }

        public static void ShowQuestBox(this Entity entity, string message)
        {
            entity.ShowMessageBox(MessageBoxType.Question, "确认", $"{message}");
        }

        #endregion Entity拓展
    }
}