namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_AddAttributePointsHandler : AMActorLocationRpcHandler<Unit, C2M_AddAttributePoints, M2C_AddAttributePoints>
    {
        protected override async ETTask Run(Unit unit, C2M_AddAttributePoints request, M2C_AddAttributePoints response)
        {
            await ETTask.CompletedTask;
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            int count = request.NumericTypes.Count;
            if (numericComponent.GetAsInt(NumericType.AttributePoints) < count)
            {
                response.Error = ErrorCode.ERR_AddPointNotEnough;
                return;
            }
            long pointCount = 0;
            for (int i = 0; i < request.NumericTypes.Count; i++)
            {
                int targetNumericType = request.NumericTypes[i];

                if (!PlayerNumericConfigCategory.Instance.Contain(targetNumericType))
                {
                    response.Error = ErrorCode.ERR_NumericTypeNotExist;
                    return;
                }

                PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.Get(targetNumericType);
                if (config.isAddPoint == 0)
                {
                    response.Error = ErrorCode.ERR_NumericTypeNotAddPoint;
                    return;
                }
                numericComponent.Add(targetNumericType, request.AddValues[i]);
                pointCount += request.AddValues[i];
            }
            numericComponent.Minus(NumericType.AttributePoints, pointCount);

            numericComponent.AddOrUpdateUnitCache();  //关键数据立即存库
        }
    }
}