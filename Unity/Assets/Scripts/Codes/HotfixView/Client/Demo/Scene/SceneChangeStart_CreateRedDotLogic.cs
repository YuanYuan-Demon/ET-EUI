using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_CreateRedDotLogic : AEvent<SceneChangeStart>
    {
        protected override async ETTask Run(Scene clientScene, SceneChangeStart args)
        {
            await ETTask.CompletedTask;
            RedDotHelper.AddRedDotNode(clientScene, RedDotType.Root, RedDotType.Main, false);
            RedDotHelper.AddRedDotNode(clientScene, RedDotType.Main, RedDotType.Role, false);
            RedDotHelper.AddRedDotNode(clientScene, RedDotType.Main, RedDotType.Forge, false);
            RedDotHelper.AddRedDotNode(clientScene, RedDotType.Main, RedDotType.Task, false);
            RedDotHelper.AddRedDotNode(clientScene, RedDotType.Role, RedDotType.UpLevelButton, false);
            RedDotHelper.AddRedDotNode(clientScene, RedDotType.Role, RedDotType.AddAttribute, false);
        }
    }
}