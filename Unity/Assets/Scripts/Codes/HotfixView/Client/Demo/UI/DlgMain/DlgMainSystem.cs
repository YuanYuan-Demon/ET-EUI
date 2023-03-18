using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.EB_RoleInfoButton.AddListener(() => self.ShowDlgRoleInfo());
            self.View.EB_AdventureButton.AddListener(() => self.ShowDlgAdventure());
            self.View.EB_BagButton.AddListener(() => self.ShowDlgBag());
            self.View.EB_ForgeButton.AddListener(() => self.ShowDlgForge());
            self.View.EB_TaskButton.AddListener(() => self.ShowDlgTask());
            self.View.EB_RankButton.AddListener(() => self.ShowDlgRank());
            self.View.EB_ChatButton.AddListener(() => self.ShowDlgChat());

            RedDotHelper.AddRedDotNodeView(self.ClientScene(), RedDotType.Role, self.View.EB_RoleInfoButton.gameObject, Vector3.one, new Vector3(92, 50, 0));
            RedDotHelper.AddRedDotNodeView(self.ClientScene(), RedDotType.Forge, self.View.EB_ForgeButton.gameObject, Vector3.one, new Vector3(92, 50, 0));
            RedDotHelper.AddRedDotNodeView(self.ClientScene(), RedDotType.Task, self.View.EB_TaskButton.gameObject, Vector3.one, new Vector3(92, 50, 0));
        }

        public static void OnUnLoadWindow(this DlgMain self)
        {
            RedDotHelper.RemoveRedDotView(self.ClientScene(), RedDotType.Role, out _);
            RedDotHelper.RemoveRedDotView(self.ClientScene(), RedDotType.Forge, out _);
            RedDotHelper.RemoveRedDotView(self.ClientScene(), RedDotType.Task, out _);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void Refresh(this DlgMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ClientScene().CurrentScene());
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            self.View.ET_LevelText.SetText($"Lv.{numericComponent.GetAsInt(NumericType.Level)}");
            self.View.ET_GoldText.SetText($"金币: {numericComponent.GetAsInt(NumericType.Gold)}");
            self.View.ET_ExpText.SetText($"经验: {numericComponent.GetAsInt(NumericType.Exp)}");
        }

        #region 界面入口

        public static void ShowDlgRoleInfo(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_RoleInfo);
        }

        public static void ShowDlgAdventure(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Adventure);
        }

        public static void ShowDlgBag(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Bag);
        }

        public static void ShowDlgForge(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Forge);
        }

        public static void ShowDlgTask(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Task);
        }

        public static void ShowDlgRank(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Rank);
        }

        public static void ShowDlgChat(this DlgMain self)
        {
            self.ClientScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Chat);
        }

        #endregion 界面入口
    }
}