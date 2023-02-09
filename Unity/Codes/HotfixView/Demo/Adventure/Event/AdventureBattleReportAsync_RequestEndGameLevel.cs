using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventType;

namespace ET
{
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

            //args.ZoneScene?.CurrentScene()?.GetComponent<AdventureComponent>()?.ShowAdventureHpBarInfo(false);
            args.ZoneScene?.CurrentScene()?.GetComponent<AdventureComponent>()?.ResetAdventure();
        }
    }
}