namespace ET.Server
{
    [FriendOfAttribute(typeof (FriendInfo))]
    [FriendOfAttribute(typeof (RoleInfo))]
    public static class FriendInfoSystem
    {
        public static NFriend ToNFriend(this FriendInfo self) => new()
        {
            UnitId = self.Id,
            Level = self.Level,
            Name = self.Name,
            Online = self.Online,
            RoleClass = self.RoleClass,
            LastLoginTime = self.LastLoginTime,
            IsApply = self.IsApply,
        };

        public static void FromNFriend(this FriendInfo self, NFriend nFriend)
        {
            self.Level = nFriend.Level;
            self.Name = nFriend.Name;
            self.Online = nFriend.Online;
            self.RoleClass = nFriend.RoleClass;
            self.LastLoginTime = nFriend.LastLoginTime;
            self.IsApply = nFriend.IsApply;
        }

        public static void FromRoleInfo(this FriendInfo self, RoleInfo roleInfo)
        {
            self.Level = roleInfo.Level;
            self.Name = roleInfo.Name;
            self.Online = roleInfo.Online;
            self.RoleClass = roleInfo.RoleClass;
            self.LastLoginTime = roleInfo.LastLoginTime;
        }

        public static void Destroy(this FriendInfo self)
        {
            self.Level = default;
            self.Name = default;
            self.Online = default;
            self.RoleClass = default;
            self.LastLoginTime = default;
        }
    }
}