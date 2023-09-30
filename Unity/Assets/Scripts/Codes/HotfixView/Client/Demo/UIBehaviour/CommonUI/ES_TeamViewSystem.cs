using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_TeamAwakeSystem: AwakeSystem<ES_Team, Transform>
    {
        protected override void Awake(ES_Team self, Transform name) => self.uiTransform = name;
    }

    [ObjectSystem]
    public class ES_TeamDestroySystem: DestroySystem<ES_Team>
    {
        protected override void Destroy(ES_Team self) => self.DestroyWidget();
    }
}