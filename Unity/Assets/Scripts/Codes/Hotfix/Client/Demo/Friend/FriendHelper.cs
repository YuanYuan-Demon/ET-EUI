using System;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ChatMessage))]
    public static class FriendHelper
    {
        public static async ETTask<int> SendMessage(Scene ZoneScene, long unitId, bool result)
        {
            IResponse response;
            try
            {
                response = await ZoneScene.Call(new C2F_HandleFriendApply() { UnitId = unitId, Accept = result });
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