namespace ET.Server
{
    public static class BagHelper
    {
        public static bool AddItemByConfigId(Unit unit, int configId, int count = 1, bool isSync = true)
        {
            BagComponent bagComponent = unit.GetComponent<BagComponent>();
            if (bagComponent == null) return false;
            return bagComponent.AddItemByConfigId(configId, count, isSync);
        }
    }
}