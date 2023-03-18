namespace ET.Client
{
    public static class RoleInfosComponentSystem
    {
        #region 生命周期

        public class RoleInfosComponentDestroySystem : DestroySystem<RoleInfosComponent>
        {
            protected override void Destroy(RoleInfosComponent self)
            {
                foreach (var roleInfo in self.RoleInfos)
                {
                    roleInfo?.Dispose();
                }
                self.RoleInfos.Clear();
                self.CurRoleId = 0;
            }
        }

        #endregion 生命周期
    }
}