using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof (AnimatorComponent))]
    public class MoveStop_PlayStop: AEvent<MoveStop>
    {
        protected override async ETTask Run(Scene scene, MoveStop args)
        {
            args.Unit.GetComponent<AnimatorComponent>().SetBoolValue("Move", false);
            await ETTask.CompletedTask;
        }
    }
}