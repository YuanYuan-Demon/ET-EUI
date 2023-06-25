namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_AllItemsListHandler : AMHandler<M2C_AllItemsList>
    {
        protected override async ETTask Run(Session session, M2C_AllItemsList message)
        {
            await ETTask.CompletedTask;
            ItemHelper.Clear(session.ClientScene(), message.ContainerType);

            for (int i = 0; i < message.ItemInfoList.Count; i++)
            {
                ItemHelper.AddItem(session.ClientScene(), message.ItemInfoList[i], message.ContainerType);
            }
        }
    }
}