using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class ES_EquipSlotAwakeSystem: AwakeSystem<ES_EquipSlot, Transform>
    {
        protected override void Awake(ES_EquipSlot self, Transform name) => self.uiTransform = name;
    }

    [ObjectSystem]
    public class ES_EquipSlotDestroySystem: DestroySystem<ES_EquipSlot>
    {
        protected override void Destroy(ES_EquipSlot self) => self.DestroyWidget();
    }
}