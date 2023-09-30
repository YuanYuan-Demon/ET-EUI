using ET.EventType;

namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.Level)]
    [FriendOfAttribute(typeof (ET.RoleInfo))]
    public class NumericWatcher_UpLevel: INumericWatcher
    {
        public async void Run(Unit unit, NumbericChange args)
        {
            var roleInfo = await DBManagerComponent.Instance.GetZoneDB(unit.DomainZone()).Query<RoleInfo>(r => r.Id == unit.Id);
            if (roleInfo != null && roleInfo.Count > 0)
            {
                roleInfo[0].Level = (int)args.New;
                await DBManagerComponent.Instance.GetZoneDB(unit.DomainZone()).Save(roleInfo[0]);
            }
        }
    }
}