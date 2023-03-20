using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class MakeQueueOverEvent_ShowRedDot : AEvent<MakeQueueOver>
    {
        protected override async ETTask Run(Scene scene, MakeQueueOver args)
        {
            bool isExist = scene.GetComponent<ForgeComponent>().IsExistMakeQueueOver();
            if (isExist)
            {
                RedDotHelper.ShowRedDotNode(scene, RedDotType.Forge);
            }
            else
            {
                if (RedDotHelper.IsLogicAlreadyShow(scene, RedDotType.Forge))
                {
                    RedDotHelper.HideRedDotNode(scene, RedDotType.Forge);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}