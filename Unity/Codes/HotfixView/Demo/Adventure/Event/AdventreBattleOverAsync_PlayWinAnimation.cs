﻿using ET.EventType;

namespace ET
{
    public class AdventreBattleOverAsync_PlayWinAnimation : AEventAsync<AdventureBattleOverAsync>
    {
        protected override async ETTask Run(AdventureBattleOverAsync args)
        {
            args.WinUnit?.GetComponent<AnimatorComponent>()?.Play(MotionType.Win);
            await ETTask.CompletedTask;
        }
    }
}