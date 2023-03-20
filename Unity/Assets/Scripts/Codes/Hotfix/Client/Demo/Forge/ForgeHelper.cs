using System;

namespace ET.Client
{
    public static class ForgeHelper
    {
        /// <summary>
        /// 请求开始生产物品
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="productionConfigId"></param>
        /// <returns></returns>
        public static async ETTask<int> StartProduction(Scene ZoneScene, int productionConfigId)
        {
            //判定生成配方是否存在
            if (!ForgeProductionConfigCategory.Instance.Contain(productionConfigId))
            {
                return ErrorCode.ERR_MakeConfigNotExist;
            }

            //判定生产材料数量是否满足
            var config = ForgeProductionConfigCategory.Instance.Get(productionConfigId);
            int materailCount = ZoneScene.GetMyNumericComponent().GetAsInt(config.ConsumId);
            if (materailCount < config.ConsumeCount)
            {
                return ErrorCode.ERR_MakeConsumeError;
            }

            M2C_StartProduction response;
            try
            {
                response = await ZoneScene.Call(new C2M_StartProduction() { ConfigId = productionConfigId }) as M2C_StartProduction;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ZoneScene.GetComponent<ForgeComponent>().AddOrUpdateProductionQueue(response.ProductionProto);
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 请求获取生产好的物品
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public static async ETTask<int> ReceivedProductionItem(Scene ZoneScene, long productionId)
        {
            //背包已满
            if (ZoneScene.GetComponent<BagComponent>().IsMaxLoad())
            {
                return ErrorCode.ERR_BagMaxLoad;
            }

            M2C_ReceiveProduction response;
            try
            {
                response = await ZoneScene.Call(new C2M_ReceiveProduction() { ProducitonId = productionId }) as M2C_ReceiveProduction;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ZoneScene.GetComponent<ForgeComponent>().AddOrUpdateProductionQueue(response.ProductionProto);
            return ErrorCode.ERR_Success;
        }
    }
}