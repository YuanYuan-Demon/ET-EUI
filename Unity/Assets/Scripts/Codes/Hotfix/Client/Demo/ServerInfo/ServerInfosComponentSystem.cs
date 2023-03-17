namespace ET.Client
{
    public static class ServerInfosComponentSystem
    {
        #region 生命周期

        public class ServerInfosComponentDestroySystem : DestroySystem<ServerInfosComponent>
        {
            protected override void Destroy(ServerInfosComponent self)
            {
                for (int i = 0; i < self.ServerInfos.Count; i++)
                {
                    self.ServerInfos[i]?.Dispose();
                }
                self.ServerInfos.Clear();
                self.CurServerId = 0;
            }
        }

        #endregion 生命周期

        public static void Add(this ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.ServerInfos.Add(serverInfo);
        }
    }
}