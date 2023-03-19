using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class ShowDamageValueView_RefreshHp : AEvent<ShowDamageValueView>
    {
        protected override async ETTask Run(Scene scene, ShowDamageValueView args)
        {
            args.TargetUnit.GetComponent<HeadHpViewComponent>().SetHp();
            scene.GetComponent<FlyDamageValueViewComponent>().SpawnFlyDamage(args.TargetUnit.Position, args.DamageValue).Coroutine();
            bool isAlive = args.TargetUnit.IsAlive();
            await TimerComponent.Instance.WaitAsync(400);

            args.TargetUnit.GetComponent<HeadHpViewComponent>()?.SetVisible(isAlive);
        }
    }
}