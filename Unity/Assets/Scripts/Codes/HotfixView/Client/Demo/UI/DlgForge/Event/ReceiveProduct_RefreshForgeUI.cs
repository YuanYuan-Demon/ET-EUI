using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class ReceiveProduct_RefreshForgeUI : AEvent<ReceiveProduct>
    {
        protected override async ETTask Run(Scene scene, ReceiveProduct args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgForge>().RefreshMakeQueue();
            await ETTask.CompletedTask;
        }
    }
}