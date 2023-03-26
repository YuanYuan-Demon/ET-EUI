using System.Collections.Generic;

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

        public static void AddRange(this RoleInfosComponent self, IEnumerable<NRoleInfo> nRoleInfos)
        {
            foreach (var nRoleInfo in nRoleInfos)
            {
                self.Add(nRoleInfo);
            }
        }

        public static RoleInfo Add(this RoleInfosComponent self, NRoleInfo nRoleInfo)
        {
            var roleInfo = self.AddChild<RoleInfo>();
            roleInfo.FromNRoleInfo(nRoleInfo);
            self.RoleInfos.Add(roleInfo);
            return roleInfo;
        }

        public static void Remove(this RoleInfosComponent self, long roleId)
        {
            var index = self.RoleInfos.FindIndex(r => r.Id == roleId);
            self.RoleInfos[index].Dispose();
            self.RoleInfos.RemoveAt(index);
        }

        public static void Clear(this RoleInfosComponent self)
        {
            foreach (var roleInfo in self.RoleInfos)
            {
                roleInfo?.Dispose();
            }
            self.RoleInfos.Clear();
            self.RoleInfos.Clear();
            self.CurRoleId = 0;
        }
    }
}