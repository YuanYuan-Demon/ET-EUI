namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.RoleInfosComponent))]
    public static class RoleInfosComponentSystem
    {
        #region 生命周期

        public class RoleInfosComponentDestroySystem : DestroySystem<RoleInfosComponent>
        {
            protected override void Destroy(RoleInfosComponent self)
            {
                self.Clear();
            }
        }

        #endregion 生命周期

        public static RoleInfo Add(this RoleInfosComponent self, NRoleInfo nRoleInfo)
        {
            var roleInfo = self.AddChild<RoleInfo>();
            roleInfo.FromNRoleInfo(nRoleInfo);
            self.RoleInfos.Add(roleInfo.Id, roleInfo);
            return roleInfo;
        }

        public static RoleInfo Remove(this RoleInfosComponent self, long roleId)
        {
            if (self.RoleInfos.TryGetValue(roleId, out var roleInfo))
            {
                roleInfo.Dispose();
                self.RoleInfos.Remove(roleId);
            }
            return roleInfo;
        }

        public static void Clear(this RoleInfosComponent self)
        {
            foreach (var roleInfo in self.RoleInfos.Values)
            {
                roleInfo?.Dispose();
            }
            self.RoleInfos.Clear();
            self.CurRoleId = 0;
        }
    }
}