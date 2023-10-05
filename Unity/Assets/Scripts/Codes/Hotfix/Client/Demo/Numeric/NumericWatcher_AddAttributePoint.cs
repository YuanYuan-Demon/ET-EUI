using ET.EventType;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.STR)]
    [NumericWatcher(SceneType.Current, NumericType.STA)]
    [NumericWatcher(SceneType.Current, NumericType.DEX)]
    [NumericWatcher(SceneType.Current, NumericType.INT)]
    public class NumericWatcher_AddAttributePoint: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
#if UNITY
            //if (args.IsServer) return;
#endif
            var numericComponent = unit.GetComponent<NumericComponent>();
            var addValue = args.New - args.Old;

            switch (args.NumericType)
            {
                //力量+1点 攻击力+5
                case NumericType.STR:
                    numericComponent.Add(NumericType.ADBase, addValue * 5);
                    break;
                //体力+1点 最大生命值 +1%
                case NumericType.STA:
                    numericComponent.Add(NumericType.MaxHpPct, addValue * 10000);
                    break;

                //敏捷+1点  闪避概率加0.1%
                case NumericType.DEX:
                    numericComponent.Add(NumericType.DodgeFinalAdd, addValue * 1000);
                    break;

                //精神+1点 最大法力值 +1%
                case NumericType.INT:
                    numericComponent.Add(NumericType.MaxMpFinalPct, addValue * 10000);
                    break;
            }
        }
    }
}