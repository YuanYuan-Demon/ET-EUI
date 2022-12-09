namespace ET
{
    public class M2C_NoticeUnitNumericHandler : AMHandler<M2C_NoticeUnitNumeric>
    {
        protected override void Run(Session session, M2C_NoticeUnitNumeric message)
        {
#if UNITY_2021_3_OR_NEWER

            Unit myUnit = UnitHelper.GetMyUnitFromZoneScene(session.ZoneScene());
            if (message.UnitId == myUnit.Id)
            {
                myUnit.GetComponent<NumericComponent>().SetFromServer(message.NumericType, message.NewValue);
                return;
            }
#endif
            session.ZoneScene()?.CurrentScene()?.GetComponent<UnitComponent>()?.
                Get(message.UnitId)?.GetComponent<NumericComponent>()?.Set(message.NumericType, message.NewValue);
        }
    }
}