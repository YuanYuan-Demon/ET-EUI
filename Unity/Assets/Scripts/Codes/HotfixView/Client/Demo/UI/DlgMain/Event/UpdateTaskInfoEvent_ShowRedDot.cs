using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class UpdateTaskInfoEvent_ShowRedDot : AEvent<UpdateTaskInfo>
    {
        protected override async ETTask Run(Scene scene, UpdateTaskInfo args)
        {
            //bool isExist = scene.GetComponent<TasksComponent>().IsExistTaskComplete();
            //if (isExist)
            //{
            //    RedDotHelper.ShowRedDotNode(scene, RedDotType.Task);
            //}
            //else
            //{
            //    if (RedDotHelper.IsLogicAlreadyShow(scene, RedDotType.Task))
            //    {
            //        RedDotHelper.HideRedDotNode(scene, RedDotType.Task);
            //    }
            //}
            //scene.GetComponent<UIComponent>()?.GetDlgLogic<DlgTask>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }
}