using System;
using Unity.Mathematics;

namespace ET.Server
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
                    numericComponent.Set(NumericType.AOI, 15000); // 视野15米
                    foreach (var config in PlayerNumericConfigCategory.Instance.GetAll().Values)
                    {
                        if (config.BaseValue == 0)
                            continue;
                        if (config.Id < 3000)   //小于3000的值都用加成属性推导
                        {
                            int baseKey = config.Id * 10 + 1;
                            numericComponent.SetNoEvent(baseKey, config.BaseValue);
                        }
                        else
                        {
                            //大于3000的值 直接使用
                            numericComponent.SetNoEvent(config.Id, config.BaseValue);
                        }
                    }
                    unit.Position = new float3(50, 8.2f, 40);
                    //Undone: AddComponent<BagComponent>()
                    //unit.AddComponent<BagComponent>();
                    //Undone: AddComponent<EquipmentsComponent>()
                    //unit.AddComponent<EquipmentsComponent>();
                    //Undone: AddComponent<ForgeComponent>()
                    //unit.AddComponent<ForgeComponent>();
                    //Undone: AddComponent<TasksComponent>()
                    //unit.AddComponent<TasksComponent>();

                    unitComponent.Add(unit);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }

        public static Unit CreateMonster(Scene scene, int configId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), configId);
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

            numericComponent.SetNoEvent(NumericType.MaxHp, unit.Config.MaxHP);
            numericComponent.SetNoEvent(NumericType.Hp, unit.Config.MaxHP);
            numericComponent.SetNoEvent(NumericType.DamageValue, unit.Config.DamageValue);
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);

            unitComponent.Add(unit);
            return unit;
        }
    }
}