using System;

namespace ET.Client
{
    public enum MessageBoxType
    {
        Infomation,
        Question,
        Error,
    }

    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgMessageBox: Entity, IAwake, IUILogic
    {
        public MessageBoxData MessageBoxData;
        public Action OnNo;
        public Action OnYes;
        public DlgMessageBoxViewComponent View => this.GetComponent<DlgMessageBoxViewComponent>();
    }

    public class MessageBoxData: ShowWindowData
    {
        public string CancelText;
        public string Message;
        public MessageBoxType MessageType;

        public string OKText;
        public string Title;
    }
}