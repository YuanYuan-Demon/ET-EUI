using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_StatusAwakeSystem: AwakeSystem<ES_Status, Transform>
    {
        protected override void Awake(ES_Status self, Transform transform)
        {
            self.uiTransform = transform;
        }
    }

    [ObjectSystem]
    public class ES_StatusDestroySystem: DestroySystem<ES_Status>
    {
        protected override void Destroy(ES_Status self)
        {
            self.DestroyWidget();
        }
    }
}