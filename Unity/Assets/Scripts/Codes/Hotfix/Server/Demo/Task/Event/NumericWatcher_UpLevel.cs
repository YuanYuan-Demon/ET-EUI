using ET.EventType;

namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.Level)]
    public class NumericWatcher_UpLevel: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.GetComponent<TasksComponent>().TriggerTaskAction(TaskTargetType.UpLevel, (int)args.New);
            // RankHelper.AddOrUpdateLevelRank(unit);
        }
    }
}