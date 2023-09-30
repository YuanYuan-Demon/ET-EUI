namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_ItemUpdateOpInfoHandler: AMHandler<M2C_ItemUpdateOpInfo>
    {
        protected override async ETTask Run(Session session, M2C_ItemUpdateOpInfo message)
        {
            switch (message.Op)
            {
                case ItemOp.Add:
                    ItemHelper.AddItem(session.ClientScene(), message.ItemInfo, message.ContainerType);
                    break;

                case ItemOp.Update:
                    ItemHelper.UpdateItem(session.ClientScene(), message.ItemInfo, message.ContainerType);
                    break;

                case ItemOp.Remove:
                    ItemHelper.RemoveItemById(session.ClientScene(), message.ItemInfo.ItemUid, message.ContainerType);
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}