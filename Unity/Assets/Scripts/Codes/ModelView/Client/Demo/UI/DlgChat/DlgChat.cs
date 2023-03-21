using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgChat : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_ChatMessage> ScrollItemChats;
        public DlgChatViewComponent View { get => this.GetComponent<DlgChatViewComponent>(); }
    }
}