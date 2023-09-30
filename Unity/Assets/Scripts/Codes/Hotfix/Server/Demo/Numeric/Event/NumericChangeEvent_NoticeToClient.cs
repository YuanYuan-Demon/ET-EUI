using ET.EventType;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class NumericChangeEvent_NoticeToClient: AEvent<NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange args)
        {
            //只允许通知玩家Unit
            if (args.Unit.Type != UnitType.Player)
            {
                return;
            }

            args.Unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(args);
            await ETTask.CompletedTask;
        }
    }
}