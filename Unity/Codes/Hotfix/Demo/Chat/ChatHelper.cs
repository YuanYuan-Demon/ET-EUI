using System;

namespace ET
{
    public static class ChatHelper
    {
        public static async ETTask<int> SendMessage(Scene ZoneScene, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return ErrorCode.ERR_ChatMessageEmpty;
            }

            Chat2C_SendChatInfo response;
            try
            {
                response = (Chat2C_SendChatInfo)await ZoneScene.Call(new C2Chat_SendChatInfo() { ChatMessage = message });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }
            return ErrorCode.ERR_Success;
        }
    }
}