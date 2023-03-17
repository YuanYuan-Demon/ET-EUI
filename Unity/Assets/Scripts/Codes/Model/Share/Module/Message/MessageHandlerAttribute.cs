namespace ET
{
    public class MessageHandlerAttribute : BaseAttribute
    {
        public MessageHandlerAttribute(SceneType sceneType)
        {
            this.SceneType = sceneType;
        }

        public SceneType SceneType { get; }
    }
}