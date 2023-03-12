namespace ET
{
    [FriendClassAttribute(typeof(ET.ForgeComponent))]
    public static class ForgeHelper
    {
        public static void SyncAllProduction(Unit unit)
        {
            ForgeComponent forgeComponent = unit.GetComponent<ForgeComponent>();

            M2C_AllProductionList m2CAllProductionList = new M2C_AllProductionList();
            foreach (Production product in forgeComponent.ProductionsList)
            {
                m2CAllProductionList.ProductionProtoList.Add(product.ToMessage());
            }
            MessageHelper.SendToClient(unit, m2CAllProductionList);
        }
    }
}