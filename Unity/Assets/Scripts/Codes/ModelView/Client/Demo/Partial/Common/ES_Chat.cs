using System.Collections.Generic;

namespace ET.Client
{
    public partial class ES_Chat: IUILogic
    {
        public ChatChannel DisplayChannel = ChatChannel.All;
        public List<ChatMessage> Messages = new();
        public List<Scroll_Item_Chat> ScrollItemChats;
        public ChatChannel SendChannel = ChatChannel.Local;

        public long ToId;
        public string ToName;
    }
}