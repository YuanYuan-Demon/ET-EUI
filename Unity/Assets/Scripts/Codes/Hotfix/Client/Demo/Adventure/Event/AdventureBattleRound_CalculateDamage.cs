using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof(AdventureComponent))]
    [Event(SceneType.Client)]
    public class AdventureBattleRound_CalculateDamage : AEvent<AdventureBattleRound>
    {
        protected override async ETTask Run(Scene scene, AdventureBattleRound args)
        {
            if (!args.AttackUnit.IsAlive() || !args.TargetUnit.IsAlive())
            {
                return;
            }
            SRandom random = scene.CurrentScene().GetComponent<AdventureComponent>().Random;
            int damage = DamageCalcuateHelper.CalcuateDamageValue(args.AttackUnit, args.TargetUnit, ref random);
            int hp = args.TargetUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - damage;
            if (hp <= 0)
            {
                hp = 0;
                args.TargetUnit.SetAlive(false);
            }

            args.TargetUnit.GetComponent<NumericComponent>().Set(NumericType.Hp, hp);
            Log.Debug($"*************  {args.AttackUnit}造成伤害:{damage}  *************");
            Log.Debug($"*************  {args.TargetUnit.Type}剩余血量:{hp}  *************");
            EventSystem.Instance.PublishAsync(scene
                , new ShowDamageValueView()
                {
                    TargetUnit = args.TargetUnit,
                    DamageValue = damage,
                }).Coroutine();

            await ETTask.CompletedTask; ;
        }
    }
}