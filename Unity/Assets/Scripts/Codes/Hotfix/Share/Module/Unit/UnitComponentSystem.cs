namespace ET
{
    [ObjectSystem]
    public class UnitComponentAwakeSystem: AwakeSystem<UnitComponent>
    {
        protected override void Awake(UnitComponent self)
        {
        }
    }

    [ObjectSystem]
    public class UnitComponentDestroySystem: DestroySystem<UnitComponent>
    {
        protected override void Destroy(UnitComponent self)
        {
        }
    }

    public static class UnitComponentSystem
    {
        public static void Add(this UnitComponent self, Unit unit)
        {
            if (unit.Parent != self)
                self.AddChild(unit);
        }

        public static Unit Create(this UnitComponent self, int configId) => self.Create(IdGenerater.Instance.GenerateId(), configId);

        public static Unit Create(this UnitComponent self, long id, int configId) => self.AddChildWithId<Unit, int>(id, configId);

        public static Unit Get(this UnitComponent self, long id)
        {
            var unit = self.GetChild<Unit>(id);
            return unit;
        }

        public static bool Contains(this UnitComponent self, long id) => self.Children.ContainsKey(id);

        public static void Remove(this UnitComponent self, long id)
        {
            var unit = self.GetChild<Unit>(id);
            unit?.Dispose();
        }
    }
}