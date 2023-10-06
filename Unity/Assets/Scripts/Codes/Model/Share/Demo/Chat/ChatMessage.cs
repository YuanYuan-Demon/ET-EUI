namespace ET
{
    [ChildOf]
    public class ChatMessage: Entity, IAwake, IDestroy
    {
        public ChatChannel Channel;
        public long FromId;
        public string FromName;
        public string Message;
        public long Time;
        public long ToId;
        public string ToName;
    }
}