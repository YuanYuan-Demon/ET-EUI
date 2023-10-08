using ET.EventType;

namespace ET.Client
{
    public static class UnitFactory
    {
        public static Unit Create(Scene currentScene, NUnit nUnit)
        {
            var unitComponent = currentScene.GetComponent<UnitComponent>();
            var unit = unitComponent.Create(nUnit.UnitId, nUnit.ConfigId);
            unit.AddComponent<RoleInfo>().FromNRoleInfo(nUnit.NRoleInfo);
            unit.Position = nUnit.Position;
            unit.Forward = nUnit.Forward;

            var numericComponent = unit.AddComponent<NumericComponent>();
            foreach (var (nt, value)in nUnit.Numeric)
            {
                numericComponent.Set(nt, value);
            }

            unit.AddComponent<MoveComponent>();
            if (nUnit.MoveInfo != null)
                if (nUnit.MoveInfo.Targets.Count > 0)
                {
                    nUnit.MoveInfo.Targets[0] = unit.Position;
                    unit.MoveToAsync(nUnit.MoveInfo.Targets).Coroutine();
                }

            unit.AddComponent<ObjectWait>();

            unit.AddComponent<XunLuoPathComponent>();

            EventSystem.Instance.Publish(unit.DomainScene(),
                new AfterUnitCreate() { Unit = unit, Prefab = UnitConfigCategory.Instance.Get(nUnit.ConfigId).Prefab });
            return unit;
        }
    }
}