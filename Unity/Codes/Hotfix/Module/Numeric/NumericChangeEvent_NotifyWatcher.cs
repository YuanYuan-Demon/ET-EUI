using ET.EventType;

namespace ET
{
    // 分发数值监听
    public class NumericChangeEventAsyncNotifyWatcher : AEventClass<EventType.NumbericChange>
    {
        protected override void Run(EventType.NumbericChange args)
        {
            NumericWatcherComponent.Instance.Run(args);
        }
    }
}