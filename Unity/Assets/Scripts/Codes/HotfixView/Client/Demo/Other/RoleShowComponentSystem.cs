using UnityEngine;

namespace ET.Client
{
    public static class RoleShowComponentSystem
    {
        public class RoleShowComponentAwakeSystem : AwakeSystem<RoleShowComponent>
        {
            protected override void Awake(RoleShowComponent self)
            {
                self.Transform = GameObject.Find("RoleShow").transform;
            }
        }

        public class RoleShowComponentDestroySystem : DestroySystem<RoleShowComponent>
        {
            protected override void Destroy(RoleShowComponent self)
            {
                self.Transform = null;
            }
        }
    }
}