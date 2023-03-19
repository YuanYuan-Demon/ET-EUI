using ET.EventType;

namespace ET.Client
{
    [NumericWatcher(SceneType.Client, NumericType.Level)]
    [NumericWatcher(SceneType.Client, NumericType.Gold)]
    [NumericWatcher(SceneType.Client, NumericType.Exp)]
    public class NumericWatcher_RefreashMainUI : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            args.Unit.ClientScene().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.Refresh();
        }
    }
}