namespace ET.Server
{
    [FriendOfAttribute(typeof (FriendInfo))]
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
        };

        public static void FromNFriend(this FriendInfo self, NFriend nFriend)
        {
            self.Level = nFriend.Level;
            self.Name = nFriend.Name;
            self.Online = nFriend.Online;
            self.RoleClass = nFriend.RoleClass;
            self.LastLoginTime = nFriend.LastLoginTime;
        }
    }
}