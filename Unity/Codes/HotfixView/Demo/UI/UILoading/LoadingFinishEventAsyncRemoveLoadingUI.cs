using ET.EventType;

namespace ET
{
    public class LoadingFinishEventAsyncRemoveLoadingUI : AEvent<EventType.LoadingFinish>
    {
        protected override void Run(EventType.LoadingFinish args)
        {
            //UIHelper.CreatePlayer(args.Scene, UIType.UILoading, UILayer.Mid).Coroutine();
        }
    }
}