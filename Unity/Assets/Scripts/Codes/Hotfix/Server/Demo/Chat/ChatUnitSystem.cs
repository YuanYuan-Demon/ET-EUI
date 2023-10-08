namespace ET.Server
{
    public class ChatUnitDestroySystem: DestroySystem<ChatUnit>
    {
        protected override void Destroy(ChatUnit self)
        {
            self.Name = null;
            self.GateSessionActorId = 0;
        }
    }
}