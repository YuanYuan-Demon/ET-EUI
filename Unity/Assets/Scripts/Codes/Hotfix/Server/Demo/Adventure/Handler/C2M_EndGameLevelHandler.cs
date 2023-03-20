namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_EndGameLevelHandler : AMActorLocationRpcHandler<Unit, C2M_EndGameLevel, M2C_EndGameLevel>
    {
        protected override async ETTask Run(Unit unit, C2M_EndGameLevel request, M2C_EndGameLevel response)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            #region 校验

            //检测关卡信息是否正常
            int levelId = numericComponent.GetAsInt(NumericType.AdventureStatus);
            if (levelId == 0 || !BattleLevelConfigCategory.Instance.Contain(levelId))
            {
                response.Error = ErrorCode.ERR_AdventureLevelError;
                return;
            }

            //检测上传的回合数是否正常
            if (request.Round <= 0)
            {
                response.Error = ErrorCode.ERR_AdventureRoundError;
                return;
            }

            switch (request.BattleResult)
            {
                //战斗失败进入垂死状态
                case (int)BattleRoundResult.Lose:
                    numericComponent.Set(NumericType.DyingState, 1);
                    numericComponent.Set(NumericType.AdventureStatus, 0);
                    return;

                case (int)BattleRoundResult.Win:
                    //胜利结果核验
                    if (!unit.GetComponent<AdventureCheckComponent>().CheckBattleWinResult(request.Round))
                    {
                        response.Error = ErrorCode.ERR_AdventureWinResultError;
                        return;
                    }
                    break;

                default:
                    response.Error = ErrorCode.ERR_AdventureResultError;
                    return;
            }

            #endregion 校验

            #region 发放奖励

            numericComponent.Set(NumericType.AdventureStatus, 0);
            EventSystem.Instance.Publish(unit.DomainScene(),
                new EventType.BattleWin()
                {
                    Unit = unit,
                    LevelId = levelId,
                });

            #region 背包测试奖励

            for (int i = 0; i < 30; i++)
            {
                if (!BagHelper.AddItemByConfigId(unit, RandomHelper.RandomNumber(1002, 1018)))
                {
                    Log.Error("增加背包物品失败");
                }
            }

            #endregion 背包测试奖励

            numericComponent[NumericType.Exp] += BattleLevelConfigCategory.Instance.Get(levelId).RewardExp;
            numericComponent[NumericType.IronStone] += 3600; ;
            numericComponent[NumericType.Fur] += 3600; ;

            #endregion 发放奖励

            await ETTask.CompletedTask;
        }
    }
}