namespace ET.Server
{
    public static class ServerInfoManagerComponentSystem
    {
        public static async void Init(this ServerInfoManagerComponent self)
        {
            var serverInfos = await self.QueryDB<ServerInfo>(info => true);
            self.ServerInfos.Clear();

            if (serverInfos?.Count <= 0)
            {
                Log.Warning("数据库中不存在 [ServerInfo] 信息");
                var config = ServerInfoConfigCategory.Instance.GetAll();
                foreach (var info in config.Values)
                {
                    var newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
                    newServerInfo.ServerName = info.ServerName;
                    newServerInfo.Status = (int)ServerStatus.Normal;
                    self.ServerInfos.Add(newServerInfo);
                    //self.AddChild(newServerInfo);
                    DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).SaveNotWait(newServerInfo).Coroutine();
                }

                return;
            }

            foreach (var serverInfo in serverInfos)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
            }
        }

#region 生命周期

        public class ServerInfoManagerComponentAwakeSystem: AwakeSystem<ServerInfoManagerComponent>
        {
            protected override void Awake(ServerInfoManagerComponent self) => self.Init();
        }

        public class ServerInfoManagerComponentDestroySystem: DestroySystem<ServerInfoManagerComponent>
        {
            protected override void Destroy(ServerInfoManagerComponent self)
            {
                for (var i = 0; i < self.ServerInfos.Count; i++)
                    self.ServerInfos[i]?.Dispose();

                self.ServerInfos.Clear();
            }
        }

        public class ServerInfoManagerComponentLoadSystem: LoadSystem<ServerInfoManagerComponent>
        {
            protected override void Load(ServerInfoManagerComponent self) => self.Init();
        }

#endregion 生命周期
    }
}