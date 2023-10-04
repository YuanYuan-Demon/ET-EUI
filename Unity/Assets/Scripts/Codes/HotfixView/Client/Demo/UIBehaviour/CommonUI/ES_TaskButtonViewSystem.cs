using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_TaskButtonAwakeSystem: AwakeSystem<ES_TaskButton, Transform>
    {
        protected override void Awake(ES_TaskButton self, Transform transform)
        {
            self.uiTransform = transform;
        }
    }

    [ObjectSystem]
    public class ES_TaskButtonDestroySystem: DestroySystem<ES_TaskButton>
    {
        protected override void Destroy(ES_TaskButton self)
        {
            self.DestroyWidget();
        }
    }
}