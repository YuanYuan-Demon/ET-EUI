namespace ET
{
    public static class UnitFactory
    {
        public static Unit CreatePlayer(Scene currentScene, UnitInfo unitInfo)
        {
            //创建Unit
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            //初始化数值组件
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            for (int i = 0; i < unitInfo.Ks.Count; ++i)
            {
                numericComponent.SetNoEvent(unitInfo.Ks[i], unitInfo.Vs[i]);
            }

            unit.AddComponent<ObjectWait>();

            Game.EventSystem.Publish(new EventType.AfterUnitCreate() { Unit = unit });
            return unit;
        }
    }
}