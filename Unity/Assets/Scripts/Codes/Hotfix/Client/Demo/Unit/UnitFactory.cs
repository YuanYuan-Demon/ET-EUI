using ET.Client.EventType;

namespace ET.Client
{
    public static class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

            foreach (var kv in unitInfo.KV)
            {
                numericComponent.Set(kv.Key, kv.Value);
            }

            unit.AddComponent<MoveComponent>();
            if (unitInfo.MoveInfo != null)
            {
                if (unitInfo.MoveInfo.Points.Count > 0)
                {
                    unitInfo.MoveInfo.Points[0] = unit.Position;
                    unit.MoveToAsync(unitInfo.MoveInfo.Points).Coroutine();
                }
            }

            unit.AddComponent<ObjectWait>();

            unit.AddComponent<XunLuoPathComponent>();

            EventSystem.Instance.Publish(unit.DomainScene(), new EventType.AfterUnitCreate() { Unit = unit });
            return unit;
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public static Unit CreatePlayer(Scene currentScene, UnitInfo unitInfo)
        {
            //创建Unit
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            //初始化数值组件
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            foreach (var kv in unitInfo.KV)
            {
                numericComponent.SetNoEvent(kv.Key, kv.Value);
            }

            unit.AddComponent<ObjectWait>();
            //unit.AddComponent<BagComponent>();

            EventSystem.Instance.PublishAsync(currentScene, new EventType.AfterUnitCreateAsync() { Unit = unit }).Coroutine();
            return unit;
        }

        /// <summary>
        /// 创建怪物
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="configId"></param>
        /// <returns></returns>
        public static async ETTask<Unit> CreateMonsterAsync(Scene currentScene, int configId)
        {
            //创建Unit
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), configId);
            unitComponent.Add(unit);

            //初始化数值组件
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);
            numericComponent.SetNoEvent(NumericType.DamageValue, unit.Config.DamageValue);
            numericComponent.SetNoEvent(NumericType.MaxHp, unit.Config.MaxHP);
            numericComponent.SetNoEvent(NumericType.Hp, unit.Config.MaxHP);

            unit.AddComponent<ObjectWait>();

            await EventSystem.Instance.PublishAsync(currentScene, new AfterUnitCreateAsync() { Unit = unit });

            return unit;
        }
    }
}