namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_ReceiveTaskRewardHandler : AMActorLocationRpcHandler<Unit, C2M_ReceiveTaskReward, M2C_ReceiveTaskReward>
    {
        protected override async ETTask Run(Unit unit, C2M_ReceiveTaskReward request, M2C_ReceiveTaskReward response)
        {
            TasksComponent tasksComponent = unit.GetComponent<TasksComponent>();

            int errorCode = tasksComponent.TryReceiveTaskReward(request.TaskConfigId);
            if (errorCode != ErrorCode.ERR_Success)
            {
                response.Error = errorCode;
                return;
            }

            tasksComponent.ReceiveTaskRewardState(unit, request.TaskConfigId);

            unit.GetComponent<NumericComponent>()[NumericType.Gold] += TaskConfigCategory.Instance.Get(request.TaskConfigId).RewardGoldCount;

            await ETTask.CompletedTask;
        }
    }
}