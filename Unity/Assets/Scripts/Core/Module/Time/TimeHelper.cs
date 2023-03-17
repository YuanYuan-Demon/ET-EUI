using System;

namespace ET
{
    public static class TimeHelper
    {
        public const long OneDay = 86400_000;
        public const long Hour = 3600_000;
        public const long Minute = 60_000;
        public const long Second = 1000;

        /// <summary>
        /// 客户端时间
        /// </summary>
        /// <returns></returns>
        public static long ClientNow()
        {
            return TimeInfo.Instance.ClientNow();
        }

        public static long ClientNowSeconds()
        {
            return ClientNow() / 1000;
        }

        public static DateTime DateTimeNow()
        {
            return DateTime.Now;
        }

        public static long ServerNow()
        {
            return TimeInfo.Instance.ServerNow();
        }

        public static long ClientFrameTime()
        {
            return TimeInfo.Instance.ClientFrameTime();
        }

        public static long ServerFrameTime()
        {
            return TimeInfo.Instance.ServerFrameTime();
        }
    }
}