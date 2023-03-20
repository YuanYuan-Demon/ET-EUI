﻿using System.Collections.Generic;

namespace ET.Client
{
    public static class NumericHelper
    {
        public static async ETTask<int> ReqeustAddAttributePoint(Scene zoneScene, Dictionary<int, long> attributes)
        {
            C2M_AddAttributePoints request = new();
            foreach ((int numericType, long addValue) in attributes)
            {
                request.NumericTypes.Add(numericType);
                request.AddValues.Add(addValue);
            }
            M2C_AddAttributePoints response;
            try
            {
                response = await zoneScene.GetSession().Call(request) as M2C_AddAttributePoints;
            }
            catch (System.Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }
            if (response?.Error != ErrorCode.ERR_Success)
            {
                Log.Error(response.Error.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            return ErrorCode.ERR_Success;
        }

        public static (int, long) CalAddPointValue(int numericType, int addValue)
        {
            switch (numericType)
            {
                //力量+1点 伤害值+5
                case NumericType.Power:
                    return (NumericType.DamageValueAdd, addValue * 5);

                //体力+1点 最大生命值 +1%
                case NumericType.PhysicalStrength:
                    return (NumericType.MaxHpPct, addValue * 10000);

                //敏捷+1点  闪避概率加0.1%
                case NumericType.Agile:
                    return (NumericType.DodgeFinalAdd, addValue * 1000);

                //精神+1点 最大法力值 +1%
                case NumericType.Spirit:
                    return (NumericType.MaxMpFinalPct, addValue * 10000);

                default:
                    return default;
            }
        }

        public static int GetRelativeAttribute(int numericType)
        {
            switch (numericType)
            {
                case NumericType.DamageValue:
                    return NumericType.Power;

                case NumericType.MaxHp:
                    return NumericType.PhysicalStrength;

                case NumericType.Dodge:
                    return NumericType.Agile;

                case NumericType.MaxMp:
                    return NumericType.Spirit;

                default:
                    return 0;
            }
        }

        public static async ETTask<int> ReqeustUpRoleLevel(Scene zoneScene)
        {
            M2C_UpRoleLevel response;
            try
            {
                response = await zoneScene.GetSession().Call(new C2M_UpRoleLevel() { }) as M2C_UpRoleLevel;
            }
            catch (System.Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
            {
                Log.Error(response.Error.ToString());
                return response.Error;
            }
            return ErrorCode.ERR_Success;
        }
    }
}