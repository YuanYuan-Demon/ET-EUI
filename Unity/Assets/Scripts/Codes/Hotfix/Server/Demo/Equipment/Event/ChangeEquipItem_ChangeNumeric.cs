using ET.Server.EventType;

namespace ET.Server
{
    [FriendOf(typeof(AttributeEntry))]
    [FriendOf(typeof(EquipInfoComponent))]
    [Event(SceneType.Map)]
    public class ChangeEquipItemEvent_ChangeNumeric : AEvent<ChangeEquipItem>
    {
        protected override async ETTask Run(Scene scene, ChangeEquipItem args)
        {
            await ETTask.CompletedTask;
            EquipInfoComponent equipInfoComponent = args.Item.GetComponent<EquipInfoComponent>();

            if (equipInfoComponent == null)
            {
                return;
            }

            NumericComponent numericComponent = args.Unit.GetComponent<NumericComponent>();
            foreach (var entry in equipInfoComponent.EntryList)
            {
                int numericTypeKey = entry.AttributeType * 10 + 2;
                if (args.EquipOp == EquipOp.Load)
                {
                    numericComponent[numericTypeKey] += entry.AttributeValue;
                }
                else if (args.EquipOp == EquipOp.Unload)
                {
                    numericComponent[numericTypeKey] -= entry.AttributeValue;
                }
            }
        }
    }
}