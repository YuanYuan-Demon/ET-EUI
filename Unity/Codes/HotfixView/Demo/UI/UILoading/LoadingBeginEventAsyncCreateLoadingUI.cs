using ET.EventType;

namespace ET
{
    public class LoadingBeginEventAsyncCreateLoadingUI : AEvent<EventType.LoadingBegin>
    {
        protected override void Run(EventType.LoadingBegin args)
        {
            //UIHelper.CreatePlayer(args.Scene, UIType.UILoading, UILayer.Mid).Coroutine();
        }
    }
}