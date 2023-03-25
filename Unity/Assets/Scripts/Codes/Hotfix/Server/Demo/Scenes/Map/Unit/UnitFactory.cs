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
                    foreach (PlayerNumericConfig config in PlayerNumericConfigCategory.Instance.GetAll().Values)
                    {
                        if (config.BaseValue == 0)
                        {
                            continue;
                        }

                        if (config.Id < 3000) //小于3000的值都用加成属性推导
                        {
                            NumericType baseKey = (NumericType)(config.Id * 10 + 1);
                            numericComponent.SetNoEvent(baseKey, config.BaseValue);
                        }
                        else
                        {
                            //大于3000的值 直接使用
                            numericComponent.SetNoEvent((NumericType)config.Id, config.BaseValue);
                        }
                    }

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
                    throw new($"not such unit type: {unitType}");
            }
        }

        public static Unit CreateMonster(Scene scene, int configId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), configId);
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

            numericComponent.SetNoEvent(NumericType.MaxHp, unit.Config.MaxHp);
            numericComponent.SetNoEvent(NumericType.Hp, unit.Config.MaxHp);
            numericComponent.SetNoEvent(NumericType.DamageValue, unit.Config.AD);
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);

            unitComponent.Add(unit);
            return unit;
        }
    }
}