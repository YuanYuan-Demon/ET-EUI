using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_MiniMapAwakeSystem: AwakeSystem<ES_MiniMap, Transform>
    {
        protected override void Awake(ES_MiniMap self, Transform transform)
        {
            self.uiTransform = transform;
        }
    }

    [ObjectSystem]
    public class ES_MiniMapDestroySystem: DestroySystem<ES_MiniMap>
    {
        protected override void Destroy(ES_MiniMap self)
        {
            self.DestroyWidget();
        }
    }
}