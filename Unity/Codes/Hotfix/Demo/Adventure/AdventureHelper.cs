namespace ET
{
    public static class AdventureHelper
    {
        public static async ETTask<int> RequestStartGameLevel(Scene zoneScene, int levelId)
        {
            M2C_StartGameLevel request;
            try
            {
                request = await zoneScene.GetSession().Call(new C2M_StartGameLevel()
                {
                    LevelId = levelId
                }) as M2C_StartGameLevel;
            }
            catch (System.Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }
            if (request.Error != ErrorCode.ERR_Success)
            {
                Log.Error(request.Error.ToString());
                return request.Error;
            }
            return ErrorCode.ERR_Success;
        }
    }
}