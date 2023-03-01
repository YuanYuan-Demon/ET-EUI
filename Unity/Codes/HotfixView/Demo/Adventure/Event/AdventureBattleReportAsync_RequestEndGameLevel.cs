using ET.EventType;

namespace ET
{
    /// <summary>
    /// 冒险回合结束战报
    /// </summary>
    public class AdventureBattleReportAsync_RequestEndGameLevel : AEventAsync<AdventureBattleReportAsync>
    {
        protected override async ETTask Run(AdventureBattleReportAsync args)
        {
            if (args.BattleRoundResult == BattleRoundResult.Keep)
                return;

            int errCode = await AdventureHelper.RequestEndGameLevel(args.ZoneScene, args.BattleRoundResult, args.Round);
            if (errCode != ErrorCode.ERR_Success)
                return;

            await TimerComponent.Instance.WaitAsync(3000);

            args.ZoneScene?.CurrentScene()?.GetComponent<AdventureComponent>()?.ShowAdventureHpBarInfo(false);
            args.ZoneScene?.CurrentScene()?.GetComponent<AdventureComponent>()?.ResetAdventure();
        }
    }
}