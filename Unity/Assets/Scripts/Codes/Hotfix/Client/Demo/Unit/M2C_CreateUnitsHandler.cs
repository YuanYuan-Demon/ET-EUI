namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_CreateUnitsHandler: AMHandler<M2C_CreateUnits>
    {
        protected override async ETTask Run(Session session, M2C_CreateUnits message)
        {
            var currentScene = session.DomainScene().CurrentScene();
            var unitComponent = currentScene.GetComponent<UnitComponent>();

            foreach (var unitInfo in message.Units)
            {
                if (unitComponent.Get(unitInfo.UnitId) != null)
                    continue;

                var unit = UnitFactory.Create(currentScene, unitInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}