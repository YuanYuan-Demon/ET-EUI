namespace ET.Server
{
    public static class LoginInfoRecordComponentSystem
    {
        #region 生命周期

        public class LoginInfoRecordComponentDestroySystem : DestroySystem<LoginInfoRecordComponent>
        {
            protected override void Destroy(LoginInfoRecordComponent self)
            {
                self.AccountLoginInfos.Clear();
            }
        }

        #endregion 生命周期

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="accountId"></param>
        /// <returns>区Id(zone)</returns>
        public static int Get(this LoginInfoRecordComponent self, long accountId)
        {
            return self.AccountLoginInfos.TryGetValue(accountId, out var instanceId)
                ? instanceId : -1;
        }

        public static void Add(this LoginInfoRecordComponent self, long accountId, int zoneId)
        {
            self.AccountLoginInfos[accountId] = zoneId;
        }

        public static void Remove(this LoginInfoRecordComponent self, long accountId)
        {
            if (self.AccountLoginInfos.ContainsKey(accountId))
            {
                self.AccountLoginInfos.Remove(accountId);
            }
        }

        public static bool IsExist(this LoginInfoRecordComponent self, long accountId)
        {
            return self.AccountLoginInfos.ContainsKey(accountId);
        }
    }
}