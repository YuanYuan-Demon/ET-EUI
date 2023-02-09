using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventType;

namespace ET
{
    public class SceneChangeFinishAsync_StartAdventure : AEventAsync<SceneChangeFinishAsync>
    {
        protected override async ETTask Run(SceneChangeFinishAsync args)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(args.CurrentScene);
            //查看当前是否正在闯关
            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureStatus) == 0)
                return;
            //继续上次闯关进度
            await TimerComponent.Instance.WaitAsync(3000);
            args.CurrentScene.GetComponent<AdventureComponent>().StartAdventure().Coroutine();
        }
    }
}