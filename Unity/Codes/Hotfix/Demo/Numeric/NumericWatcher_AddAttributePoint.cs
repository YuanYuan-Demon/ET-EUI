//namespace ET
//{
//    [NumericWatcher(NumericType.Spirit)]
//    [NumericWatcher(NumericType.Agile)]
//    [NumericWatcher(NumericType.PhysicalStrength)]
//    [NumericWatcher(NumericType.Power)]
//    public class NumericWatcher_AddAttributePoint : INumericWatcher
//    {
//        public void Run(EventType.NumbericChange args)
//        {
//            if (!(args.Parent is Unit unit))
//            {
//                return;
//            }

//            var addValue = args.New - args.Old;

//            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
//            switch (args.NumericType)
//            {
//                //力量+1点 伤害值+5
//                case NumericType.Power:
//                    numericComponent.Add(NumericType.DamageValueAdd, addValue * 5);
//                    break;
//                //体力+1点 最大生命值 +1%
//                case NumericType.PhysicalStrength:
//                    numericComponent.Add(NumericType.MaxHpPct, addValue * 10000);
//                    break;

//                //敏捷+1点  闪避概率加0.1%
//                case NumericType.Agile:
//                    numericComponent.Add(NumericType.DodgeFinalAdd, addValue * 1000);
//                    break;

//                //精神+1点 最大法力值 +1%
//                case NumericType.Spirit:
//                    numericComponent.Add(NumericType.MaxMpFinalPct, addValue * 10000);
//                    break;

//                default:
//                    break;
//            }
//        }
//    }
//}