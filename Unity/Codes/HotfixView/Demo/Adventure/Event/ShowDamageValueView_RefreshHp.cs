using ET.EventType;

namespace ET
{
    public class ShowDamageValueView_RefreshHp : AEventAsync<ShowDamageValueViewAsync>
    {
        protected override async ETTask Run(ShowDamageValueViewAsync args)
        {
            args.TargetUnit.GetComponent<HeadHpViewComponent>().SetHp();
            args.ZoneScene.GetComponent<FlyDamageValueViewComponent>().SpawnFlyDamage(args.TargetUnit.Position, args.DamageValue).Coroutine();
            bool isAlive = args.TargetUnit.IsAlive();
            await TimerComponent.Instance.WaitAsync(400);

            args.TargetUnit.GetComponent<HeadHpViewComponent>()?.SetVisible(isAlive);
        }
    }
}