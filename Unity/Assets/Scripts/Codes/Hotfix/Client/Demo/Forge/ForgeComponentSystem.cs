using System.Linq;
using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof(ET.ForgeComponent))]
    [FriendOf(typeof(ET.Production))]
    public static class ForgeComponentSystem
    {
        #region 生命周期

        public class ForgeComponentAwakeSystem : AwakeSystem<ForgeComponent>
        {
            protected override void Awake(ForgeComponent self)
            {
            }
        }

        public class ForgeComponentDestroySystem : DestroySystem<ForgeComponent>
        {
            protected override void Destroy(ForgeComponent self)
            {
                foreach (var production in self.ProductionsList)
                {
                    production?.Dispose();
                }

                foreach (var key in self.ProductionTimerDict.Keys)
                {
                    self.ProductionTimerDict.TryGetValue(key, out var value);
                    TimerComponent.Instance.Remove(ref value);
                }
            }
        }

        #endregion 生命周期

        #region 定时任务

        [Invoke(TimerInvokeType.MakeQueueOver)]
        public class MakeQueueOverTimer : ATimer<ForgeComponent>
        {
            protected override void Run(ForgeComponent t)
            {
                EventSystem.Instance.Publish(t.ClientScene(), new MakeQueueOver());
            }
        }

        #endregion 定时任务

        /// <summary>
        /// 是否有物品制作完成
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsExistMakeQueueOver(this ForgeComponent self)
        {
            return self.ProductionsList.Any(p => p.IsMakingState() && p.IsMakeTimeOver());
            //bool isCanRecive = false;
            //foreach (Production production in self.ProductionsList)
            //{
            //    if (production.IsMakingState() && production.IsMakeTimeOver())
            //    {
            //        isCanRecive = true;
            //        break;
            //    }
            //}
            //return isCanRecive;
        }

        /// <summary>
        /// 添加制作队列
        /// </summary>
        /// <param name="self"></param>
        /// <param name="productionProto">制作物品</param>
        public static void AddOrUpdateProductionQueue(this ForgeComponent self, ProductionProto productionProto)
        {
            Production production = self.GetProductionById(productionProto.Id);

            if (production == null)
            {
                production = self.AddChild<Production>();
                self.ProductionsList.Add(production);
            }
            production.FromMessage(productionProto);
            if (self.ProductionTimerDict.TryGetValue(production.Id, out long timeId))
            {
                TimerComponent.Instance.Remove(ref timeId);
                self.ProductionTimerDict.Remove(production.Id);
            }

            if (production.IsMakingState() && !production.IsMakeTimeOver())
            {
                Log.Debug($"启动一个定时器!!!!:{production.TargetTime}");
                timeId = TimerComponent.Instance.NewOnceTimer(production.TargetTime, TimerInvokeType.MakeQueueOver, self);
                self.ProductionTimerDict.Add(production.Id, timeId);
            }

            EventSystem.Instance.Publish(self.ClientScene(), new MakeQueueOver());
        }

        /// <summary>
        /// 根据配方Id获取产品
        /// </summary>
        /// <param name="self"></param>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public static Production GetProductionById(this ForgeComponent self, long productionId)
        {
            foreach (Production product in self.ProductionsList)
            {
                if (product.Id == productionId)
                {
                    return product;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据索引获取制作队列项目
        /// </summary>
        /// <param name="self"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Production GetProductionByIndex(this ForgeComponent self, int index)
        {
            return index < self.ProductionsList.Count
                ? self.ProductionsList[index]
                : null;
        }

        /// <summary>
        /// 获取正在制作的物品数量
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetMakingProductionQueueCount(this ForgeComponent self)
        {
            int count = 0;
            for (int i = 0; i < self.ProductionsList.Count; i++)
            {
                Production production = self.ProductionsList[i];
                if (production.ProductionState == ProductionState.Making)
                {
                    ++count;
                }
            }
            return count;
        }
    }
}