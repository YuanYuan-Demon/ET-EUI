using ET.Server.EventType;

namespace ET.Server
{
    [FriendOf(typeof (AttributeEntry))]
    [FriendOf(typeof (EquipInfoComponent))]
    [Event(SceneType.Map)]
    public class ChangeEquipItemEvent_ChangeNumeric: AEvent<ChangeEquipItem>
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
            foreach (AttributeEntry entry in equipInfoComponent.EntryList)
            {
                NumericType nt = (NumericType)((int)entry.AttributeType * 10 + 2);
                switch (args.EquipOp)
                {
                    case EquipOp.Load:
                        numericComponent[nt] += entry.AttributeValue;
                        break;
                    case EquipOp.Unload:
                        numericComponent[nt] -= entry.AttributeValue;
                        break;
                }
            }
        }
    }
}