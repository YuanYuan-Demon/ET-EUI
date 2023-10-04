using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SelectTask_RefreshTaskInfo: AEvent<SelectTask>
    {
        protected override async ETTask Run(Scene scene, SelectTask args)
        {
            UIComponent.Instance.GetDlgLogic<DlgTask>().View.ES_TaskInfo.Refresh(args.TaskInfo);
            await ETTask.CompletedTask;
        }
    }
}