using UnityEngine;

namespace ET.Client
{
    public static class RoleShowComponentSystem
    {
        public static void ShowRole(this RoleShowComponent self, int index)
        {
            for (var i = 0; i < 3; i++)
            {
                self.Transform.GetChild(i).gameObject.SetActive(i == index);
            }
        }

#region 生命周期

        public class RoleShowComponentAwakeSystem: AwakeSystem<RoleShowComponent>
        {
            protected override void Awake(RoleShowComponent self) => self.Transform = GameObject.Find("RoleShow").transform;
        }

        public class RoleShowComponentDestroySystem: DestroySystem<RoleShowComponent>
        {
            protected override void Destroy(RoleShowComponent self) => self.Transform = null;
        }

#endregion
    }
}