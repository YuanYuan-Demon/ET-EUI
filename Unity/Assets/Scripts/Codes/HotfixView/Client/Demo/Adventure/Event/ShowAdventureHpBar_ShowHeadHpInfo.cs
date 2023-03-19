using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class ShowAdventureHpBar_ShowHeadHpInfo : AEvent<ShowAdventureHpBar>
    {
        protected override async ETTask Run(Scene scene, ShowAdventureHpBar args)
        {
            try
            {
                HeadHpViewComponent headHpViewComponent = args.Unit.GetComponent<HeadHpViewComponent>();
                headHpViewComponent.SetVisible(args.isShow);
                headHpViewComponent.SetHp();
            }
            catch (System.Exception e)
            {
                Log.Error(e);
            }
            await ETTask.CompletedTask;
        }
    }
}