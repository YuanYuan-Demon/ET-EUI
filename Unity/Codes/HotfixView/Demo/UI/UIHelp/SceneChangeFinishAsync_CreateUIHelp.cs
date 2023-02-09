using ET.EventType;

namespace ET
{
    public class SceneChangeFinishAsync_CreateUIHelp : AEventAsync<EventType.SceneChangeFinishAsync>
    {
        protected override async ETTask Run(EventType.SceneChangeFinishAsync args)
        {
            //UIHelper.CreatePlayer(args.CurrentScene, UIType.UIHelp, UILayer.Mid).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}