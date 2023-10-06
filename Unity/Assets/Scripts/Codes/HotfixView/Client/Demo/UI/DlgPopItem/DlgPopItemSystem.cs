using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPopItem))]
    [FriendOfAttribute(typeof (RoleInfo))]
    public static class DlgPopItemSystem
    {
        public static void RegisterUIEvent(this DlgPopItem self)
        {
            self.RegisterCloseEvent<DlgPopItem>(self.View.EB_Close_Button);
            self.View.EB_Use_Button.AddListener(self.OnClickUse);
            self.View.EB_Show_Button.AddListener(self.OnClickShow);
            self.View.EB_Sell_Button.AddListener(self.OnClickUse);
        }

        public static void ShowWindow(this DlgPopItem self, ShowWindowData windowData = null)
        {
            var data = windowData as PopItemData;
            self.SetItem(data.ItemConfig, data.ShowButtons);
            self.SetPosition(data.ClickPosition);
        }

        public static void SetItem(this DlgPopItem self, ItemConfig config, bool showButton = true)
        {
            var nc = self.GetMyNumericComponent();
            var roleClass = self.GetMyUnit().GetComponent<RoleInfo>().RoleClass;

            var view = self.View;
            view.ET_Name_TextMeshProUGUI.text = $"{config.Name}";
            view.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", config.Icon);
            view.ET_Type_TextMeshProUGUI.text = $"类型: {config.Type.GetDisplayName()}";

            var levelColor = self.ShowColor[nc[NumericType.Level] > config.Level];
            view.ET_Level_TextMeshProUGUI.text = $"等级: <color={levelColor}>{config.Level.ToString()}</color>";

            var limitClassColor = self.ShowColor[roleClass == config.LimitClass || config.LimitClass == RoleClass.None];
            view.ET_Class_TextMeshProUGUI.text = $"职业: <color={limitClassColor}>{config.LimitClass.GetDisplayName()}</color>";
            view.ET_Price_TextMeshProUGUI.text = $"出售价格: {config.SellPrice,8}";

            view.ET_Desc_TextMeshProUGUI.text = config.Desc;

            view.EG_Buttons_RectTransform.gameObject.SetActive(showButton);
            if (showButton)
                switch (config.Type)
                {
                    case ItemType.Consumable:
                        view.EB_Use_Button.gameObject.SetActive(true);
                        view.ET_Use_TextMeshProUGUI.text = "使用";
                        break;

                    case ItemType.Equip:
                    case ItemType.Rider:
                        view.EB_Use_Button.gameObject.SetActive(true);
                        view.ET_Use_TextMeshProUGUI.text = "装备";
                        break;

                    default:
                        view.EB_Use_Button.gameObject.SetActive(false);
                        break;
                }
        }

        private static void SetPosition(this DlgPopItem self, Vector3 pos)
        {
            var root = self.View.EG_Panel_RectTransform;
            root.anchoredPosition = pos;
            var size = root.sizeDelta;
            var screen = root.GetComponentInParent<CanvasScaler>().referenceResolution;
            if (pos.x + size.x < screen.x)
                root.pivot = pos.y + size.y < screen.y
                        ? Vector2.zero
                        : new(0, 1);
            else
                root.pivot = pos.y + size.y < screen.y
                        ? new(1, 0)
                        : new Vector2(1, 1);
        }

        public static void OnClickUse(this DlgPopItem self)
        {
        }

        public static void OnClickShow(this DlgPopItem self)
        {
        }

        public static void OnClickDrop(this DlgPopItem self)
        {
        }
    }
}