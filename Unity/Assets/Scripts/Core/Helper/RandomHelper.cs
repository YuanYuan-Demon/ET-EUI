using System;
using System.Collections.Generic;

namespace ET
{
    // 支持多线程
    public static class RandomHelper
    {
        [StaticField]
        [ThreadStatic]
        private static Random random;

        public static bool RandomBool()
        {
            return GetRandom().Next(2) == 0;
        }

        public static T RandomArray<T>(T[] array)
        {
            return array[RandomNumber(0, array.Length)];
        }

        public static T RandomArray<T>(List<T> array)
        {
            return array[RandomNumber(0, array.Count)];
        }

        /// <summary>
        /// 打乱数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">要打乱的数组</param>
        public static void BreakRank<T>(List<T> arr)
        {
            if (arr == null || arr.Count < 2)
            {
                return;
            }

            for (int i = 0; i < arr.Count; i++)
            {
                int index = GetRandom().Next(0, arr.Count);
                (arr[index], arr[i]) = (arr[i], arr[index]);
            }
        }

        public static float RandomFloat01()
        {
            int a = RandomNumber(0, 1000000);
            return a / 1000000f;
        }

        private static Random GetRandom()
        {
            return random ??= new Random(Guid.NewGuid().GetHashCode());
        }

        #region 整数

        public static ulong RandomUInt64()
        {
            int r1 = RandomInt32();
            int r2 = RandomInt32();

            return ((ulong)r1 << 32) & (ulong)r2;
        }

        public static int RandomInt32()
        {
            return GetRandom().Next();
        }

        public static uint RandomUInt32()
        {
            return (uint)GetRandom().Next();
        }

        public static long RandInt64()
        {
            uint r1 = RandomUInt32();
            uint r2 = RandomUInt32();
            return (long)(((ulong)r1 << 32) | r2);
        }

        /// <summary>
        /// 获取lower与Upper之间的随机数,包含下限，不包含上限
        /// </summary>
        /// <param name="lower">下届</param>
        /// <param name="upper">上届</param>
        /// <returns>随机数</returns>
        public static int RandomNumber(int lower, int upper)
        {
            return GetRandom().Next(lower, upper);
        }

        #endregion 整数

        #region 浮点数

        public static float RandomFloat(float upper = 1)
        {
            return (float)random.NextDouble() * upper;
        }

        public static float RandomFloat(float lower, float upper)
        {
            return (float)(random.NextDouble() * (upper - lower) + lower);
        }

        public static double RandomDouble01(double upper = 1)
        {
            return random.NextDouble() * upper;
        }

        public static double RandomDouble(double lower, double upper)
        {
            return random.NextDouble() * (upper - lower) + lower;
        }

        #endregion 浮点数
    }
}