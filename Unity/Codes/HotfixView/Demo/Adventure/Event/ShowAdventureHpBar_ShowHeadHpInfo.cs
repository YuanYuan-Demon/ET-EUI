using ET.EventType;

namespace ET
{
    public class ShowAdventureHpBar_ShowHeadHpInfo : AEventClass<ShowAdventureHpBar>
    {
        protected override void Run(ShowAdventureHpBar args)
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
        }
    }
}