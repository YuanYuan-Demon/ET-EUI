namespace ET.Client
{
    public class ChatInfoDestroySystem : DestroySystem<ChatInfo>
    {
        protected override void Destroy(ChatInfo self)
        {
            self.Message = null;
            self.Name = null;
        }
    }
}