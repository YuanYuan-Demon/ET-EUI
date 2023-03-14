using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgChat : Entity, IAwake, IUILogic
    {
        public List<Scroll_Item_ChatMessage> ScrollItemChats;
        public DlgChatViewComponent View { get => this.Parent.GetComponent<DlgChatViewComponent>(); }
    }
}