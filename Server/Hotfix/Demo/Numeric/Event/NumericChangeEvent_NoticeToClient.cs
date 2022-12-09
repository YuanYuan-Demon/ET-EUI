using ET.EventType;

namespace ET
{
    public class NumericChangeEvent_NoticeToClient : AEventClass<EventType.NumbericChange>
    {
        protected override void Run(EventType.NumbericChange a)
        {
            if (!(a.Parent is Unit unit))
            {
                return;
            }

            //只允许通知玩家Unit
            if (unit.Type != UnitType.Player)
            {
                return;
            }
            unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(a);
        }
    }
}