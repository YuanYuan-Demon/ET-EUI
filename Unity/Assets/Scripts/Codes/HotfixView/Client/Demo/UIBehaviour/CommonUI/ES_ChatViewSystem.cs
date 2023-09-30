using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_ChatAwakeSystem: AwakeSystem<ES_Chat, Transform>
    {
        protected override void Awake(ES_Chat self, Transform name) => self.uiTransform = name;
    }

    [ObjectSystem]
    public class ES_ChatDestroySystem: DestroySystem<ES_Chat>
    {
        protected override void Destroy(ES_Chat self) => self.DestroyWidget();
    }
}