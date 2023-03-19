namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_UpRoleLevelHandler : AMActorLocationRpcHandler<Unit, C2M_UpRoleLevel, M2C_UpRoleLevel>
    {
        protected override async ETTask Run(Unit unit, C2M_UpRoleLevel request, M2C_UpRoleLevel response)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            int unitLevel = numericComponent.GetAsInt(NumericType.Level);
            var config = PlayerLevelConfigCategory.Instance.Get(unitLevel);
            long exp = numericComponent.GetAsLong(NumericType.Exp);
            if (exp < config.NeedExp)
            {
                response.Error = ErrorCode.ERR_ExpNotEnough;
                return;
            }

            numericComponent[NumericType.Exp] -= config.NeedExp;
            numericComponent[NumericType.Level]++;
            numericComponent[NumericType.AttributePoints]++;

            await ETTask.CompletedTask;
        }
    }
}