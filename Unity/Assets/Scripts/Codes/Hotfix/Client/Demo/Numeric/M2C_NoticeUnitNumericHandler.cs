namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_NoticeUnitNumericHandler : AMHandler<M2C_NoticeUnitNumeric>
    {
        protected override async ETTask Run(Session session, M2C_NoticeUnitNumeric message)
        {
            //Unit myUnit = UnitHelper.GetMyUnitFromClientScene(session.ClientScene());
            //if (message.UnitId == myUnit.Id)
            //{
            //    myUnit.GetComponent<NumericComponent>().Set(message.NumericType, message.NewValue);
            //    return;
            //}
            session.ClientScene().GetMyNumericComponent().Set(message.NumericType, message.NewValue);
            await ETTask.CompletedTask;
        }
    }
}