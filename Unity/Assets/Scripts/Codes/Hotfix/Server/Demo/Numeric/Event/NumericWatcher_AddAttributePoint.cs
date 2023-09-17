using ET.EventType;

namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.INT)]
    [NumericWatcher(SceneType.Map, NumericType.DEX)]
    [NumericWatcher(SceneType.Map, NumericType.STA)]
    [NumericWatcher(SceneType.Map, NumericType.STR)]
    public class NumericWatcher_AddAttributePoint : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            var addValue = args.New - args.Old;

            NumericComponent nc = unit.GetComponent<NumericComponent>();
            switch (args.NumericType)
            {
                //力量+1点
                //攻击+5 法强+5
                case NumericType.STR:
                    nc.Add(NumericType.ADAdd, addValue * 5);
                    nc.Add(NumericType.APAdd, addValue * 5);

                    break;
                //体力+1点 最大生命值 +1%
                case NumericType.STA:
                    nc.Add(NumericType.MaxHpPct, addValue * 1_0000);
                    break;

                //敏捷+1点  防御+3 攻速+2
                case NumericType.DEX:
                    nc.Add(NumericType.DEFAdd, addValue * 3);
                    nc.Add(NumericType.Speed, addValue * 2);
                    break;

                //智力+1点 最大法力值 +1%
                case NumericType.INT:
                    nc.Add(NumericType.MaxMpFinalPct, addValue * 1_0000);
                    break;

                default:
                    break;
            }
        }
    }
}