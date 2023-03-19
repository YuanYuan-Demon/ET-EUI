using ET.EventType;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.IsAlive)]
    public class NumericWatcher_IsAliveAnimation : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit?.GetComponent<AnimatorComponent>()
                ?.Play(args.New == 0
                ? MotionType.Die
                : MotionType.Idle);
        }
    }
}