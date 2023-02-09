using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventType;
using UnityEngine;

namespace ET
{
    [FriendClassAttribute(typeof(ET.GameObjectComponent))]
    public class AdventureBattleRoundView_PlayAnimation : AEventAsync<AdventureBattleRoundViewAsync>
    {
        protected override async ETTask Run(AdventureBattleRoundViewAsync args)
        {
            if (!args.AttackUnit.IsAlive() || !args.TargetUnit.IsAlive())
            {
                return;
            }
            args.AttackUnit.GetComponent<AnimatorComponent>()?.Play(MotionType.Attack);
            args.TargetUnit.GetComponent<AnimatorComponent>()?.Play(MotionType.Hurt);

            long instanceId = args.TargetUnit.InstanceId;
            SpriteRenderer spriteRenderer = args.TargetUnit.GetComponent<GameObjectComponent>().SpriteRenderer;
            spriteRenderer.color = Color.red;

            await TimerComponent.Instance.WaitAsync(300);
            if (instanceId != args.TargetUnit.InstanceId)
            {
                //若攻击后死亡则直接退出
                return;
            }
            spriteRenderer.color = Color.white;

            await ETTask.CompletedTask;
        }
    }
}