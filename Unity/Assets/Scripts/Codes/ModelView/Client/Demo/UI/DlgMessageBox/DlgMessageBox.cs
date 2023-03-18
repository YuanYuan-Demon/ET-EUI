namespace ET.Client
{
    public enum MessageBoxType
    {
        Infomation,
        Question,
        Error,
    }

    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMessageBox : Entity, IAwake, IUILogic
    {
        public MessageBoxData MessageBoxData;
        public DlgMessageBoxViewComponent View => this.GetComponent<DlgMessageBoxViewComponent>();
    }

    public class MessageBoxData : Entity
    {
        public MessageBoxType MessageType;
        public string Title;
        public string Message;

        public string OKText;
        public string CancelText;
    }
}