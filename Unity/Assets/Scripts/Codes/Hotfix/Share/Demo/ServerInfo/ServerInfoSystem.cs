namespace ET
{
    public static class ServerInfoSystem
    {
        public static void FromNServerInfo(this ServerInfo self, NServerInfo nServerInfo)
        {
            self.Id = nServerInfo.Id;
            self.Status = nServerInfo.Status;
            self.ServerName = nServerInfo.ServerName;
        }

        public static NServerInfo ToNServerInfo(this ServerInfo self)
        {
            return new NServerInfo() { Id = (int)self.Id, Status = self.Status, ServerName = self.ServerName, };
        }
    }
}