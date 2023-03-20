namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_AllProductionListHandler : AMHandler<M2C_AllProductionList>
    {
        protected override async ETTask Run(Session session, M2C_AllProductionList message)
        {
            for (int i = 0; i < message.ProductionProtoList.Count; i++)
            {
                session.ClientScene().GetComponent<ForgeComponent>().AddOrUpdateProductionQueue(message.ProductionProtoList[i]);
            }
            await ETTask.CompletedTask;
        }
    }
}