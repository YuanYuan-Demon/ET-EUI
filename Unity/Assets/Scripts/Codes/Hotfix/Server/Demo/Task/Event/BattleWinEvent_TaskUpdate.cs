using ET.Server.EventType;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class BattleWinEvent_TaskUpdate : AEvent<BattleWin>
    {
        protected override async ETTask Run(Scene scene, BattleWin args)
        {
            await ETTask.CompletedTask;
            args.Unit.GetComponent<TasksComponent>().TriggerTaskAction(TaskActionType.Adverture, count: 1, targetId: args.LevelId);
        }
    }
}