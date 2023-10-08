namespace ET
{
    [FriendOf(typeof (RoleInfo))]
    public static class RoleInfoSystem
    {
        public static void FromNRoleInfo(this RoleInfo self, NRoleInfo nRoleInfo)
        {
            self.Id = nRoleInfo.RoleId;
            self.Name = nRoleInfo.Name;
            self.ServerId = nRoleInfo.ServerId;
            self.Status = nRoleInfo.Status;
            self.AccountId = nRoleInfo.AccountId;
            self.RoleClass = nRoleInfo.RoleClass;
            self.Level = nRoleInfo.Level;
            self.LastLoginTime = nRoleInfo.LastLoginTIme;
            self.CreateTime = nRoleInfo.CreateTime;
            self.ConfigId = nRoleInfo.ConfigId;
        }

        public static NRoleInfo ToNRoleInfo(this RoleInfo self, bool isSelf = true)
        {
            NRoleInfo nRoleInfo = new()
            {
                RoleId = self.Id,
                Name = self.Name,
                ServerId = self.ServerId,
                Level = self.Level,
                RoleClass = self.RoleClass,
                Status = self.Status,
                LastLoginTIme = self.LastLoginTime,
                CreateTime = self.CreateTime,
                ConfigId = self.ConfigId,
            };
            if (isSelf)
            {
                nRoleInfo.AccountId = self.AccountId;
            }

            return nRoleInfo;
        }
    }
}