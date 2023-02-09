using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventType;

namespace ET
{
    [NumericWatcher(NumericType.IsAlive)]
    public class NumericWatcher_IsAliveAnimation : INumericWatcher
    {
        public void Run(NumbericChange args)
        {
            if (args.Parent is not Unit unit)
            {
                return;
            }
            if (args.New == 0)
            {
                unit?.GetComponent<AnimatorComponent>()?.Play(MotionType.Die);
            }
            else
            {
                unit?.GetComponent<AnimatorComponent>()?.Play(MotionType.Idle);
            }
        }
    }
}