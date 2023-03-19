using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AdventureRoundResetEvent_ResetAnimation : AEvent<AdventureRoundReset>
    {
        protected override async ETTask Run(Scene scene, AdventureRoundReset args)
        {
            Unit unit = scene.GetMyUnit();
            unit?.GetComponent<AnimatorComponent>()?.Play(MotionType.Idle);
            await ETTask.CompletedTask;
        }
    }
}