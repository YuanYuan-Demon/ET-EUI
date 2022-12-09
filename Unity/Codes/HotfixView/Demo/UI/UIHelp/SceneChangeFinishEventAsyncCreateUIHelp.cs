using ET.EventType;

namespace ET
{
    public class SceneChangeFinishEventAsyncCreateUIHelp : AEventAsync<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            //UIHelper.CreatePlayer(args.CurrentScene, UIType.UIHelp, UILayer.Mid).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}