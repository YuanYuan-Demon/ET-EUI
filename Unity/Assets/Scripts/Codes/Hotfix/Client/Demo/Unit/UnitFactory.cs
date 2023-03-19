using ET.Client.EventType;

namespace ET.Client
{
    public static class UnitFactory
    {
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

            EventSystem.Instance.PublishAsync(currentScene, new EventType.AfterUnitCreate() { Unit = unit }).Coroutine();
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

            await EventSystem.Instance.PublishAsync(currentScene, new AfterUnitCreate() { Unit = unit });

            return unit;
        }
    }
}