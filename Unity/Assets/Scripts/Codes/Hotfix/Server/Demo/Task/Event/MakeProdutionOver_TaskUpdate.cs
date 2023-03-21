using ET.Server.EventType;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class MakeProdutionOver_TaskUpdate : AEvent<MakeProdutionOver>
    {
        protected override async ETTask Run(Scene scene, MakeProdutionOver args)
        {
            await ETTask.CompletedTask;
            args.Unit.GetComponent<TasksComponent>().TriggerTaskAction(TaskActionType.MakeItem, count: 1, targetId: args.ProductionConfigId);
        }
    }
}