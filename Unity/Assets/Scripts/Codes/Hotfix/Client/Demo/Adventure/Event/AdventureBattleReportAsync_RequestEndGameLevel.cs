using ET.Client.EventType;

namespace ET.Client
{
    /// <summary>
    /// 冒险回合结束战报
    /// </summary>
    [Event(SceneType.Client)]
    public class AdventureBattleReportAsync_RequestEndGameLevel : AEvent<AdventureBattleReport>
    {
        protected override async ETTask Run(Scene scene, AdventureBattleReport args)
        {
            if (args.BattleRoundResult == BattleRoundResult.Keep)
                return;

            int errCode = await AdventureHelper.RequestEndGameLevel(scene, args.BattleRoundResult, args.Round);
            if (errCode != ErrorCode.ERR_Success)
                return;

            await TimerComponent.Instance.WaitAsync(3000);

            scene.CurrentScene()?.GetComponent<AdventureComponent>()?.ShowAdventureHpBarInfo(false);
            scene.CurrentScene()?.GetComponent<AdventureComponent>()?.ResetAdventure();
        }
    }
}