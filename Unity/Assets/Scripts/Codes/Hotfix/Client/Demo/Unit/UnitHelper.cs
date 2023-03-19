namespace ET.Client
{
    public static class UnitHelper
    {
        public static Unit GetMyUnit(this Scene scene)
        {
            PlayerComponent playerComponent;
            switch (scene.SceneType)
            {
                case SceneType.Client:
                    playerComponent = scene.GetComponent<PlayerComponent>();
                    return scene.CurrentScene().GetComponent<UnitComponent>().Get(playerComponent.MyId);

                case SceneType.Current:
                    playerComponent = scene.ClientScene().GetComponent<PlayerComponent>();
                    return scene.GetComponent<UnitComponent>().Get(playerComponent.MyId);

                default:
                    Scene clientScene = scene.ClientScene();
                    playerComponent = clientScene.GetComponent<PlayerComponent>();
                    return clientScene.CurrentScene().GetComponent<UnitComponent>().Get(playerComponent.MyId);
            }
        }

        public static NumericComponent GetMyNumericComponent(this Scene scene)
        {
            return scene.GetMyUnit()?.GetComponent<NumericComponent>();
        }
    }
}