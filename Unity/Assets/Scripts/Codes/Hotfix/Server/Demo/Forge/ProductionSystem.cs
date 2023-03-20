namespace ET.Server
{
    [FriendOf(typeof(Production))]
    public static class ProductionSystem
    {
        public static ProductionProto ToMessage(this Production self)
        {
            var productionProto = new ProductionProto
            {
                Id = self.Id,
                ConfigId = self.ConfigId,
                StartTime = self.StartTime,
                TargetTime = self.TargetTime,
                ProductionState = (int)self.ProductionState
            };
            return productionProto;
        }

        public static void Reset(this Production self)
        {
            self.ConfigId = 0;
            self.ProductionState = ProductionState.Received;
            self.TargetTime = 0;
            self.StartTime = 0;
        }
    }
}