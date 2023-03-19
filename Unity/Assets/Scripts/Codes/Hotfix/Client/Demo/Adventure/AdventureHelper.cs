namespace ET.Client
{
    public static class AdventureHelper
    {
        /// <summary>
        /// 发送开始闯关请求
        /// </summary>
        /// <param name="zoneScene"></param>
        /// <param name="levelId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 发送关卡结束请求[EndGameLevel]
        /// </summary>
        /// <param name="zoneScene"></param>
        /// <param name="battleRoundResult"></param>
        /// <param name="round"></param>
        /// <returns></returns>
        public static async ETTask<int> RequestEndGameLevel(Scene zoneScene, BattleRoundResult battleRoundResult, int round)
        {
            M2C_EndGameLevel request;
            try
            {
                request = await zoneScene.GetSession().Call(new C2M_EndGameLevel()
                {
                    Round = round,
                    BattleResult = (int)battleRoundResult,
                }) as M2C_EndGameLevel;
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