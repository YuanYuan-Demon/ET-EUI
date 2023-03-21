namespace ET.Client
{
    [ChildOf(typeof(ChatComponent))]
    public class ChatInfo : Entity, IAwake, IDestroy
    {
        public string Name;
        public string Message;
    }
}