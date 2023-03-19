using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AdventreBattleOverAsync_PlayWinAnimation : AEvent<AdventureBattleOver>
    {
        protected override async ETTask Run(Scene scene, AdventureBattleOver args)
        {
            args.WinUnit?.GetComponent<AnimatorComponent>()?.Play(MotionType.Win);
            await ETTask.CompletedTask;
        }
    }
}