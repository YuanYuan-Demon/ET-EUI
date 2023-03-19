using ET.EventType;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class NumericChangeEvent_NoticeToClient : AEvent<NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange nc)
        {
            await ETTask.CompletedTask;
            //只允许通知玩家Unit
            if (nc.Unit.Type != UnitType.Player)
            {
                return;
            }
            nc.Unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(nc);
        }
    }
}