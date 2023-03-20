namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_ItemUpdateOpInfoHandler : AMHandler<M2C_ItemUpdateOpInfo>
    {
        protected override async ETTask Run(Session session, M2C_ItemUpdateOpInfo message)
        {
            await ETTask.CompletedTask;
            if (message.Op == (int)ItemOp.Add)
            {
                Item item = ItemFactory.Create(session.ClientScene(), message.ItemInfo);
                ItemHelper.AddItem(session.ClientScene(), item, (ItemContainerType)message.ContainerType);
            }
            else if (message.Op == (int)ItemOp.Remove)
            {
                ItemHelper.RemoveItemById(session.ClientScene(), message.ItemInfo.ItemUid, (ItemContainerType)message.ContainerType);
            }
        }
    }
}