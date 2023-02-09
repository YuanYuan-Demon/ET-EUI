using System;
using System.Threading.Tasks;
using ET.EventType;

namespace ET
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
            for (int i = 0; i < unitInfo.Ks.Count; ++i)
            {
                numericComponent.SetNoEvent(unitInfo.Ks[i], unitInfo.Vs[i]);
            }

            unit.AddComponent<ObjectWait>();

            Game.EventSystem.PublishAsync(new EventType.AfterUnitCreateAsync() { Unit = unit }).Coroutine();
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

            await Game.EventSystem.PublishAsync(new AfterUnitCreateAsync() { Unit = unit });

            return unit;
        }
    }
}