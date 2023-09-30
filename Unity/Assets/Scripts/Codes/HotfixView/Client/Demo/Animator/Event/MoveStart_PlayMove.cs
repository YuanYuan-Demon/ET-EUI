using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof (AnimatorComponent))]
    public class MoveStart_PlayMove: AEvent<MoveStart>
    {
        protected override async ETTask Run(Scene scene, MoveStart args)
        {
            args.Unit.GetComponent<AnimatorComponent>().SetBoolValue("Move", true);
            await ETTask.CompletedTask;
        }
    }
}