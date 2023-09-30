using ET.EventType;

namespace ET.Client
{
    public static class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
            var unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.Create(unitInfo.UnitId, unitInfo.ConfigId);
            unit.AddComponent<RoleInfo>().FromNRoleInfo(unitInfo.NRoleInfo);
            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

            var numericComponent = unit.AddComponent<NumericComponent>();
            foreach ((NumericType nt, long value)in unitInfo.Numeric)
            {
                numericComponent.Set(nt, value);
            }

            unit.AddComponent<MoveComponent>();
            if (unitInfo.MoveInfo != null)
            {
                if (unitInfo.MoveInfo.Targets.Count > 0)
                {
                    unitInfo.MoveInfo.Targets[0] = unit.Position;
                    unit.MoveToAsync(unitInfo.MoveInfo.Targets).Coroutine();
                }
            }

            unit.AddComponent<ObjectWait>();

            unit.AddComponent<XunLuoPathComponent>();

            EventSystem.Instance.Publish(unit.DomainScene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }
    }
}