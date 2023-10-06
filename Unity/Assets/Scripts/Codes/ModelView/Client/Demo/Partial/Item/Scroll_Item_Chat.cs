using TMPro;

namespace ET.Client
{
    public partial class Scroll_Item_Chat
    {
        [StaticField]
        public static ColorData MessageColor;

        public TextLink TextLink => this.uiTransform.GetComponentInChildren<TextLink>();
        public TextMeshProUGUI ET_Message => this.uiTransform.GetComponent<TextMeshProUGUI>();
    }
}