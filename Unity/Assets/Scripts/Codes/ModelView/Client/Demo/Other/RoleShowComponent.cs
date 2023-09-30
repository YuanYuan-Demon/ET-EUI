using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class RoleShowComponent: Entity, IAwake, IDestroy
    {
        public Transform Transform { get; set; }
    }
}