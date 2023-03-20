using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(ForgeComponent))]
    [FriendOf(typeof(Production))]
    public static class ForgeComponentSystem
    {
        #region 生命周期

        public class ForgeComponentDeserializeSystem : DeserializeSystem<ForgeComponent>
        {
            protected override void Deserialize(ForgeComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    self.ProductionsList.Add(entity as Production);
                }
            }
        }

        #endregion 生命周期

        public static Production GetProductionById(this ForgeComponent self, long productionId)
        {
            return self.ProductionsList.FirstOrDefault(product => product.Id == productionId);
        }

        public static bool IsExistProductionOverQueue(this ForgeComponent self, long productionId)
        {
            return self.ProductionsList.Any(p =>
            p.Id == productionId
            && p.ProductionState == ProductionState.Making
            && p.TargetTime <= TimeHelper.ServerNow());
        }

        /// <summary>
        /// 是否存在空闲的队列
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsExistFreeQueue(this ForgeComponent self)
        {
            if (self.ProductionsList.Count < 2)
            {
                return true;
            }

            Production production = self.GetFreeProduction();

            return production != null;
        }

        public static Production StartProduction(this ForgeComponent self, int configId)
        {
            Production production = self.GetFreeProduction();
            if (production == null)
            {
                production = self.AddChild<Production>();
                self.ProductionsList.Add(production);
            }

            production.ConfigId = configId;
            production.ProductionState = ProductionState.Making;
            production.StartTime = TimeHelper.ServerNow();
            production.TargetTime = TimeHelper.ServerNow() + (ForgeProductionConfigCategory.Instance.Get(configId).ProductionTime * 1000);

            return production;
        }

        public static Production GetFreeProduction(this ForgeComponent self)
        {
            return self.ProductionsList.FirstOrDefault(p =>
            p.ProductionState == ProductionState.Received);
        }
    }
}