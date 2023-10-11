using System.Text;
using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ChatMessage))]
    [FriendOfAttribute(typeof (Scroll_Item_Chat))]
    public static class Scroll_Item_ChatSystem
    {
        public static void Init(this Scroll_Item_Chat self, ChatMessage message)
        {
            self.TextLink.OnClickLink = OnClickChatLink;
            self.ET_Message.SetText(self.FormatMessage(message));
        }

        private static string FormatMessage(this Scroll_Item_Chat self, ChatMessage message)
        {
            var sb = new StringBuilder();
            sb.Append($"<color=#{Scroll_Item_Chat.MessageColor[message.Channel]}>")
                    .Append($"[{message.Channel.GetDisplayName()}]");
            if (message.Channel != ChatChannel.System)
                sb.Append($"{self.FormatFromPlayer(message)}{message.Message}");
            sb.Append($"</color>");
            return sb.ToString();
        }

        private static string FormatFromPlayer(this Scroll_Item_Chat self, ChatMessage message)
            => message.FromId == self.GetMyUnit().Id
                    ? $"[你]:"
                    : $"<link=\"Player:{message.FromId}:{message.FromName}\">[{message.FromName}]:</link>";

        private static void OnClickChatLink(string linkInfo, Vector3 pos)
        {
            if (string.IsNullOrEmpty(linkInfo))
                return;
            var infos = linkInfo.Split(':');
            switch (infos[0])
            {
                case "Player":
                {
                    // UIPopChatMenu menu = UIManager.Instance.Show<UIPopChatMenu>();
                    // menu.SetTarget(int.Parse(infos[1]), infos[2]);
                    break;
                }
                case "Item":
                {
                    var itemConfig = ItemConfigCategory.Instance.Get(infos[1].ToInt());
                    var showWindowData = new PopItemData() { ItemConfig = itemConfig, ShowButtons = false, ClickPosition = pos };
                    UIComponent.Instance.ShowWindow<DlgPopItem>(showWindowData);
                    break;
                }
            }
        }
    }
}