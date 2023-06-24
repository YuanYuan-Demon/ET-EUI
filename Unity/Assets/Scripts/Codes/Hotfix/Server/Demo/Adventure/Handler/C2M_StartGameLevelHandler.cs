namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_StartGameLevelHandler : AMActorLocationRpcHandler<Unit, C2M_StartGameLevel, M2C_StartGameLevel>
    {
        protected override async ETTask Run(Unit unit, C2M_StartGameLevel request, M2C_StartGameLevel response)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            #region 校验

            if (numericComponent.GetAsInt(NumericType.AdventureStatus) != 0)
            {
                response.Error = ErrorCode.ERR_AlreadyAdventureStatus;
                return;
            }
            if (numericComponent.GetAsInt(NumericType.DyingState) != 0)
            {
                response.Error = ErrorCode.ERR_AdventureInDying;
                return;
            }
            if (!BattleLevelConfigCategory.Instance.Contain(request.LevelId))
            {
                response.Error = ErrorCode.ERR_AdventureLevelError;
                return;
            }

            #endregion 校验

            #region 进入关卡

            BattleLevelConfig config = BattleLevelConfigCategory.Instance.Get(request.LevelId);
            if (numericComponent[NumericType.Level] < config.MiniEnterLevel[0])
            {
                response.Error = ErrorCode.ERR_AdventureLevelNotEnough;
                return;
            }

            numericComponent.Set(NumericType.AdventureStatus, request.LevelId);
            numericComponent.Set(NumericType.AdventureStartTime, TimeHelper.ServerNow());

            //设置本次战斗的随机种子，保证客户端的战斗中的每次随机产生的数能在服务器端复现
            numericComponent.Set(NumericType.BattleRandomSeed, RandomHelper.RandomUInt32());

            #endregion 进入关卡

            await ETTask.CompletedTask;
        }
    }
}