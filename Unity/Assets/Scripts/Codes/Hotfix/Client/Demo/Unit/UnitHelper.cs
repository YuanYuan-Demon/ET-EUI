namespace ET.Client
{
    public static class UnitHelper
    {
        public static Unit GetMyUnit(this Entity entity) => entity.GetUnitComponent().MyUnit;

        public static UnitComponent GetUnitComponent(this Entity entity) => entity.ClientScene().CurrentScene().GetComponent<UnitComponent>();

        public static NumericComponent GetMyNumericComponent(this Entity entity) => entity.GetMyUnit()?.GetComponent<NumericComponent>();

        public static bool IsMyUnit(this Unit unit)
        {
            if (unit == null || unit.IsDisposed)
            {
                return false;
            }

            UnitComponent unitComponent = unit.GetUnitComponent();
            if (unitComponent == null || unitComponent.IsDisposed)
            {
                return false;
            }

            if (unitComponent.MyUnit == null)
            {
                return false;
            }

            return unitComponent.MyUnit == null && unitComponent.MyUnit.Id == unit.Id;
        }
    }
}