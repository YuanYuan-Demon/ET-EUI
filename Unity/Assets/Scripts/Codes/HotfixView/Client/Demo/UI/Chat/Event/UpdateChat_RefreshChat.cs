using ET.Client.EventType;

namespace ET.Client.Event
{
    [Event(SceneType.Client)]
    public class UpdateChat_RefreshChat: AEvent<UpdateChat>
    {
        protected override async ETTask Run(Scene scene, UpdateChat args)
        {
            await ETTask.CompletedTask;
            UIComponent.Instance.GetDlgLogic<DlgMain>().View.ES_Chat.Refresh();
        }
    }
}