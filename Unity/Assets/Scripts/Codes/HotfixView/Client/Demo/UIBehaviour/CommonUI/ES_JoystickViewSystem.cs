using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_JoystickAwakeSystem: AwakeSystem<ES_Joystick, Transform>
    {
        protected override void Awake(ES_Joystick self, Transform transform)
        {
            self.uiTransform = transform;
        }
    }

    [ObjectSystem]
    public class ES_JoystickDestroySystem: DestroySystem<ES_Joystick>
    {
        protected override void Destroy(ES_Joystick self)
        {
            self.DestroyWidget();
        }
    }
}