using ET.EventType;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.STR)]
    [NumericWatcher(SceneType.Current, NumericType.STA)]
    [NumericWatcher(SceneType.Current, NumericType.DEX)]
    [NumericWatcher(SceneType.Current, NumericType.INT)]
    [NumericWatcher(SceneType.Current, NumericType.AD)]
    [NumericWatcher(SceneType.Current, NumericType.DEF)]
    [NumericWatcher(SceneType.Current, NumericType.AP)]
    [NumericWatcher(SceneType.Current, NumericType.MDEF)]
    [NumericWatcher(SceneType.Current, NumericType.Speed)]
    [NumericWatcher(SceneType.Current, NumericType.Crit)]
    [NumericWatcher(SceneType.Current, NumericType.Level)]
    public class NumericWatcher_RefreshRoleInfo: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args) => UIComponent.Instance.GetDlgLogic<DlgEquip>()?.RefreshRoleInfo();
    }
}