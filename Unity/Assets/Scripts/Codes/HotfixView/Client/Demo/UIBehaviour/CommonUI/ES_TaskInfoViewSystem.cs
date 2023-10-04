using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_TaskInfoAwakeSystem: AwakeSystem<ES_TaskInfo, Transform>
    {
        protected override void Awake(ES_TaskInfo self, Transform transform)
        {
            self.uiTransform = transform;
        }
    }

    [ObjectSystem]
    public class ES_TaskInfoDestroySystem: DestroySystem<ES_TaskInfo>
    {
        protected override void Destroy(ES_TaskInfo self)
        {
            self.DestroyWidget();
        }
    }
}