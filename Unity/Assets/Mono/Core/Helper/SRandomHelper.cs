using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public class SRandom
    {
        public static int count = 0;
        private ulong randSeed = 1;

        public SRandom(uint seed)
        {
            randSeed = seed;
        }

        public void SetRandomSeed(uint seed)
        {
            randSeed = seed;
        }

        /// <summary>
        /// [0,uint.MaxValue]
        /// </summary>
        /// <returns></returns>
        public uint Next()
        {
            randSeed = randSeed * 1103515245 + 12345;
            return (uint)(randSeed / 65535);
        }

        /// <summary>
        /// [0,max)
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public uint Next(uint max)
        {
            return Next() % max;
        }

        /// <summary>
        /// [0,max)
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public int Next(int max)
        {
            return (int)(Next() % max);
        }

        /// <summary>
        /// [min,max)
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public uint Range(uint min, uint max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException("minValue", $"'{min}' 不能大于 '{max}'.");
            uint width = max - min;
            return Next(width) + min;
        }

        /// <summary>
        /// [min,max)
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int Range(int min, int max)
        {
            count++;
            if (min > max)
                throw new ArgumentOutOfRangeException("minValue", $"'{min}' 不能大于 '{max}'.");
            int width = max - min;
            return Next(width) + min;
        }
    }
}