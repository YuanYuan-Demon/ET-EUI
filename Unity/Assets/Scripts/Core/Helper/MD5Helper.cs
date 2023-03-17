﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ET
{
    public static class MD5Helper
    {
        public static string FileMD5(string filePath)
        {
            byte[] retVal;
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
                MD5 md5 = MD5.Create();
                retVal = md5.ComputeHash(file);
            }
            return retVal.ToHex("x2");
        }

        public static string StringMD5(string str)
        {
            MD5 md5 = MD5.Create();
            var res = Encoding.Default.GetBytes(str);
            var output = md5.ComputeHash(res);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}