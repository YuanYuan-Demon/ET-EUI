using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_AttributeAwakeSystem: AwakeSystem<ES_Attribute, Transform>
    {
        protected override void Awake(ES_Attribute self, Transform name) => self.uiTransform = name;
    }

    [ObjectSystem]
    public class ES_AttributeDestroySystem: DestroySystem<ES_Attribute>
    {
        protected override void Destroy(ES_Attribute self) => self.DestroyWidget();
    }
}