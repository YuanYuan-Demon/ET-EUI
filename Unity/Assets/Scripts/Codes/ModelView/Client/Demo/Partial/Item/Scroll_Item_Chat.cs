using System.Collections.Generic;
using TMPro;

namespace ET.Client
{
    public partial class Scroll_Item_Chat
    {
        [StaticField]
        public static readonly Dictionary<ChatChannel, string> MessageColor = new()
        {
            { ChatChannel.Local, "FFFFFF" },
            { ChatChannel.World, "70A1FF" },
            { ChatChannel.Team, "FFA502" },
            { ChatChannel.Guild, "2ED573" },
            { ChatChannel.Private, "FF6B81" },
            { ChatChannel.System, "F5E67C" },
        };

        public TextLink TextLink => this.uiTransform.GetComponentInChildren<TextLink>();
        public TextMeshProUGUI ET_Message => this.uiTransform.GetComponent<TextMeshProUGUI>();
    }
}