namespace ET.Server
{
    [FriendOf(typeof (WatcherComponent))]
    public static class WatcherComponentSystem
    {
        public class WatcherComponentAwakeSystem: AwakeSystem<WatcherComponent>
        {
            protected override void Awake(WatcherComponent self) => WatcherComponent.Instance = self;
        }

        public class WatcherComponentDestroySystem: DestroySystem<WatcherComponent>
        {
            protected override void Destroy(WatcherComponent self) => WatcherComponent.Instance = null;
        }

        public static void Start(this WatcherComponent self, int createScenes = 0)
        {
            var localIP = NetworkHelper.GetAddressIPs();
            var processConfigs = StartProcessConfigCategory.Instance.GetAll();
            foreach (var startProcessConfig in processConfigs.Values)
            {
                if (!WatcherHelper.IsThisMachine(startProcessConfig.InnerIP, localIP))
                    continue;
                var process = WatcherHelper.StartProcess(startProcessConfig.Id, createScenes);
                self.Processes.Add(startProcessConfig.Id, process);
            }
        }
    }
}