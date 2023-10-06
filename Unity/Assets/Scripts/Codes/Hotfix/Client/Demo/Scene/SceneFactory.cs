using ET.EventType;

namespace ET.Client
{
    public static class SceneFactory
    {
        public static async ETTask<Scene> CreateClientScene(int zone, string name)
        {
            var clientScene = EntitySceneFactory.CreateScene(zone, SceneType.Client, name, ClientSceneManagerComponent.Instance);
            clientScene.AddComponent<CurrentScenesComponent>();
            clientScene.AddComponent<ObjectWait>();
            clientScene.AddComponent<PlayerComponent>();

            clientScene.AddComponent<AccountInfoComponent>();
            clientScene.AddComponent<ServerInfosComponent>();
            clientScene.AddComponent<RoleInfosComponent>();

            clientScene.AddComponent<BagComponent>();
            clientScene.AddComponent<EquipmentsComponent>();
            //Undone: AddComponent<ForgeComponent>();
            //clientScene.AddComponent<ForgeComponent>();
            clientScene.AddComponent<CTasksComponent>();
            //Undone: AddComponent<RankComponent>();
            //clientScene.AddComponent<RankComponent>();
            clientScene.AddComponent<CChatComponent>();

            await EventSystem.Instance.PublishAsync(clientScene, new AfterCreateClientScene());
            return clientScene;
        }

        public static Scene CreateCurrentScene(long id, int zone, string name, CurrentScenesComponent currentScenesComponent)
        {
            var currentScene = EntitySceneFactory.CreateScene(id, IdGenerater.Instance.GenerateInstanceId(), zone, SceneType.Current, name,
                currentScenesComponent);
            currentScenesComponent.Scene = currentScene;

            EventSystem.Instance.Publish(currentScene, new AfterCreateCurrentScene());
            return currentScene;
        }
    }
}