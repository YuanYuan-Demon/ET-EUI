﻿using System;
using System.Threading.Tasks;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ChatMessage))]
    public static class ChatHelper
    {
        public static async Task<int> SendMessage(Scene ZoneScene, string message, ChatChannel channel, long targetId)
        {
            if (string.IsNullOrEmpty(message))
                return ErrorCode.ERR_ChatMessageEmpty;

            Chat2C_SendChatInfo response;
            try
            {
                response = await ZoneScene.Call(new C2Chat_SendChatInfo()
                {
                    NChatMessage = new() { message = message, fromID = ZoneScene.GetMyUnit().Id, toID = targetId, Channel = channel },
                }) as Chat2C_SendChatInfo;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
                return response.Error;
            return ErrorCode.ERR_Success;
        }
    }
}