using ET.EventType;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.BattleRandomSeed)]
    public class NumericWatcher_BattleRandomSeed : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.DomainScene().GetComponent<AdventureComponent>().SetBattleRandomSeed();
        }
    }
}