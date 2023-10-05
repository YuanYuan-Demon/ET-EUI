namespace ET.Server
{
    [FriendOfAttribute(typeof (RoleInfo))]
    public static class UnitFactory
    {
        public static Unit CreatePlayer(Scene scene, long id, UnitType unitType, RoleInfo roleInfo = default)
        {
            var unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    var unit = unitComponent.Create(id, roleInfo.ConfigId);
                    unit.AddComponent(roleInfo);
                    InitPlayer(unit, roleInfo.UnitConfig);

#region 背包测试

                    //添加装备
                    for (var i = 0; i < 10; i++)
                    {
                        var equipId = 1000 * RandomHelper.RandomInt32(1, 4)
                                + 10 * RandomHelper.RandomInt32(0, 2)
                                + RandomHelper.RandomInt32(1, 8);
                        if (!BagHelper.AddItemByConfigId(unit, equipId, isSync: false))
                        {
                            Log.Error("增加背包物品失败");
                        }
                    }

                    //添加道具
                    for (var i = 0; i < 30; i++)
                    {
                        var itemId = RandomHelper.RandomInt32(1, 11);
                        if (!BagHelper.AddItemByConfigId(unit, itemId, isSync: false))
                        {
                            Log.Error("增加背包物品失败");
                        }
                    }

#endregion 背包测试

                    return unit;
                }
                default:
                    throw new($"not such unit type: {unitType}");
            }
        }

        public static Unit CreateRobot(Scene scene, long id, UnitType unitType, int configId)
        {
            var unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    var unit = unitComponent.Create(id, configId);
                    InitPlayer(configId, unit);

                    return unit;
                }
                default:
                    throw new($"not such unit type: {unitType}");
            }
        }

        private static void InitPlayer(int configId, Unit unit) => InitPlayer(unit, UnitConfigCategory.Instance.Get(configId));

        private static void InitPlayer(Unit unit, UnitConfig unitConfig)
        {
            var nc = unit.AddComponent<NumericComponent>();

            InitNumeric(unitConfig, nc);
            nc.SetNoEvent(NumericType.MaxBagCapacity, TGlobalConfigCategory.Instance.BagCapacityStart);
            nc.SetNoEvent(NumericType.AOI, 15000); // 视野15米

            unit.Position = TGlobalConfigCategory.Instance.BornPosition;

            unit.AddComponent<BagComponent>();
            unit.AddComponent<EquipmentsComponent>();
            //Undone: AddComponent<ForgeComponent>()
            //unit.AddComponent<ForgeComponent>();
            unit.AddComponent<TasksComponent>();
        }

        private static void InitNumeric(UnitConfig unitConfig, NumericComponent nc)
        {
            foreach (var (nt, value) in unitConfig.Attributes)
            {
                nc.SetNoEvent(nt, value);
            }

            nc.SetNoEvent(NumericType.Hp, nc[NumericType.MaxHp]);
            nc.SetNoEvent(NumericType.Mp, nc[NumericType.MaxMp]);
            nc.SetNoEvent(NumericType.IsAlive, 1);
        }

        public static Unit CreateMonster(Scene scene, int configId)
        {
            var unitComponent = scene.GetComponent<UnitComponent>();
            var unit = unitComponent.Create(configId);
            var unitConfig = UnitConfigCategory.Instance.Get(configId);
            var nc = unit.AddComponent<NumericComponent>();

            InitNumeric(unitConfig, nc);

            return unit;
        }
    }
}