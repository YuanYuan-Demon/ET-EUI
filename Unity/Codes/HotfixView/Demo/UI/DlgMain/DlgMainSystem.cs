using UnityEngine;

namespace ET
{
    [FriendClass(typeof(DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.EB_RoleInfoButton.AddListener(() => self.ShowDlgRoleInfo());
            self.View.EB_AdventureButton.AddListener(() => self.ShowDlgAdventure());
            self.View.EB_BagButton.AddListener(() => self.ShowDlgBag());
            self.View.EB_ForgeButton.AddListener(() => self.ShowDlgForge());
            self.View.EB_TaskButton.AddListener(() => self.ShowDlgTask());

            RedDotHelper.AddRedDotNodeView(self.ZoneScene(), RedDotType.Role, self.View.EB_RoleInfoButton.gameObject, Vector3.one, new Vector3(80, 30, 0));
        }

        public static void OnUnLoadWindow(this DlgMain self)
        {
            RedDotMonoView redDotMonoView = self.View.EB_RoleInfoButton.GetComponent<RedDotMonoView>();
            RedDotHelper.RemoveRedDotView(self.ZoneScene(), RedDotType.Role, out redDotMonoView);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void Refresh(this DlgMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            self.View.ET_LevelText.SetText($"Lv.{numericComponent.GetAsInt(NumericType.Level)}");
            self.View.ET_GoldText.SetText($"金币: {numericComponent.GetAsInt(NumericType.Gold)}");
            self.View.ET_ExpText.SetText($"经验: {numericComponent.GetAsInt(NumericType.Exp)}");
        }

        public static void ShowDlgRoleInfo(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_RoleInfo);
        }

        public static void ShowDlgAdventure(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Adventure);
        }

        public static void ShowDlgBag(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Bag);
        }

        public static void ShowDlgForge(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Forge);
        }

        public static void ShowDlgTask(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Task);
        }
    }
}