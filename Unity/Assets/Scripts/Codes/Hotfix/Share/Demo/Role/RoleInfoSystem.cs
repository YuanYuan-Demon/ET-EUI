namespace ET
{
    [FriendOf(typeof(ET.RoleInfo))]
    public static class RoleInfoSystem
    {
        public static void FromNRoleInfo(this RoleInfo self, NRoleInfo nRoleInfo)
        {
            self.Id = nRoleInfo.Id;
            self.Name = nRoleInfo.Name;
            self.ServerId = nRoleInfo.ServerId;
            self.Status = nRoleInfo.Status;
            self.AccountId = nRoleInfo.AccountId;
            self.RoleClass = nRoleInfo.RoleClass;
            self.Level = nRoleInfo.Level;
            self.LastLoginTIme = nRoleInfo.LastLoginTIme;
            self.CreateTime = nRoleInfo.CreateTime;
        }

        public static NRoleInfo ToNRoleInfo(this RoleInfo self)
        {
            return new NRoleInfo()
            {
                Id = self.Id,
                Name = self.Name,
                ServerId = self.ServerId,
                Level = self.Level,
                RoleClass = self.RoleClass,
                Status = self.Status,
                AccountId = self.AccountId,
                LastLoginTIme = self.LastLoginTIme,
                CreateTime = self.CreateTime,
            };
        }
    }
}