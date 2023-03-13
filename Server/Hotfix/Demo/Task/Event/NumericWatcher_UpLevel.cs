using ET.EventType;

namespace ET
{
    [NumericWatcher(NumericType.Level)]
    public class NumericWatcher_UpLevel : INumericWatcher
    {
        public void Run(NumbericChange args)
        {
            if (args.Parent is Unit unit)
            {
                unit.GetComponent<TasksComponent>().TriggerTaskAction(TaskActionType.UpLevel, (int)args.New);
                RankHelper.AddOrUpdateLevelRank(unit);
            }
        }
    }
}