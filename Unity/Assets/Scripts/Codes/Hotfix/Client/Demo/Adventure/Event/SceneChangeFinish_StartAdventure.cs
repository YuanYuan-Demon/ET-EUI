using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeFinish_StartAdventure : AEvent<SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            Unit unit = scene.GetMyUnit();
            //查看当前是否正在闯关
            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureStatus) == 0)
                return;
            //继续上次闯关进度
            await TimerComponent.Instance.WaitAsync(3000);
            scene.CurrentScene().GetComponent<AdventureComponent>().StartAdventure().Coroutine();
        }
    }
}