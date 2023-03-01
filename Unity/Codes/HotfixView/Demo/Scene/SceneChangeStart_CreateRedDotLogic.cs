using ET.EventType;

namespace ET
{
    public class SceneChangeStart_CreateRedDotLogic : AEvent<SceneChangeStart>
    {
        protected override void Run(SceneChangeStart args)
        {
            RedDotHelper.AddRedDotNode(args.ZoneScene, RedDotType.Root, RedDotType.Main, false);
            RedDotHelper.AddRedDotNode(args.ZoneScene, RedDotType.Main, RedDotType.Role, false);
            RedDotHelper.AddRedDotNode(args.ZoneScene, RedDotType.Main, RedDotType.Forge, false);
            RedDotHelper.AddRedDotNode(args.ZoneScene, RedDotType.Main, RedDotType.Task, false);
            RedDotHelper.AddRedDotNode(args.ZoneScene, RedDotType.Role, RedDotType.UpLevelButton, false);
            RedDotHelper.AddRedDotNode(args.ZoneScene, RedDotType.Role, RedDotType.AddAttribute, false);
        }
    }
}