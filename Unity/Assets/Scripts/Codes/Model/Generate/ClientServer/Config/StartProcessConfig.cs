//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ET.Luban;

namespace ET
{
    public sealed partial class StartProcessConfig: Luban.BeanBase
    {
        public const int __ID__ = 2140444015;

        public StartProcessConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            MachineId = _buf.ReadInt();
            InnerPort = _buf.ReadInt();
            PostInit();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 所属机器
        /// </summary>
        public int MachineId { get; }

        /// <summary>
        /// 内网端口
        /// </summary>
        public int InnerPort { get; }

        public static StartProcessConfig DeserializeStartProcessConfig(ByteBuf _buf)
        {
            return new StartProcessConfig(_buf);
        }

        public override int GetTypeId() => __ID__;

        public void Resolve(Dictionary<Type, IConfigSingleton> _tables)
        {
            PostResolve();
        }

        public override string ToString()
        {
            return "{ "
                    + "id:" + Id + ","
                    + "machineId:" + MachineId + ","
                    + "innerPort:" + InnerPort + ","
                    + "}";
        }
    }
}