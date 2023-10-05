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
            var equipConfig = args.Item.EquipConfig;

            if (equipConfig == null)
            {
                return;
            }

            var numericComponent = args.Unit.GetComponent<NumericComponent>();
            foreach (var (nt, value) in equipConfig.Attributes)
            {
                switch (args.EquipOp)
                {
                    case EquipOp.Load:
                        numericComponent[nt] += value;
                        break;
                    case EquipOp.Unload:
                        numericComponent[nt] -= value;
                        break;
                }
            }
        }
    }
}