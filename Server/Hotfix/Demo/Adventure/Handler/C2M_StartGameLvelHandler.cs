using System;

namespace ET
{
    public class C2M_StartGameLvelHandler : AMActorLocationRpcHandler<Unit, C2M_StartGameLevel, M2C_StartGameLevel>
    {
        protected override async ETTask Run(Unit unit, C2M_StartGameLevel request, M2C_StartGameLevel response, Action reply)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            #region 校验

            if (numericComponent.GetAsInt(NumericType.AdventureStatus) != 0)
            {
                response.Error = ErrorCode.ERR_AlreadyAdventureStatus;
                reply();
                return;
            }
            if (numericComponent.GetAsInt(NumericType.DyingState) != 0)
            {
                response.Error = ErrorCode.ERR_AdventureInDying;
                reply();
                return;
            }
            if (!BattleLevelConfigCategory.Instance.Contain(request.LevelId))
            {
                response.Error = ErrorCode.ERR_AdventureLevelError;
                reply();
                return;
            }

            #endregion 校验

            #region 进入关卡

            BattleLevelConfig config = BattleLevelConfigCategory.Instance.Get(request.LevelId);
            if (numericComponent[NumericType.Level] < config.MiniEnterLevel[0])
            {
                response.Error = ErrorCode.ERR_AdventureLevelNotEnough;
                reply();
                return;
            }

            numericComponent.Set(NumericType.AdventureStatus, request.LevelId);
            numericComponent.Set(NumericType.AdventureStartTime, TimeHelper.ServerNow());

            #endregion 进入关卡

            reply();
            await ETTask.CompletedTask;
        }
    }
}