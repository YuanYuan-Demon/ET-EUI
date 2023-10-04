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
    public sealed partial class StartSceneConfig: Luban.BeanBase
    {
        public const int __ID__ = 1499456844;

        public StartSceneConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Process = _buf.ReadInt();
            Zone = _buf.ReadInt();
            SceneType = _buf.ReadString();
            Name = _buf.ReadString();
            OuterPort = _buf.ReadInt();
            PostInit();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 所属进程
        /// </summary>
        public int Process { get; }

        /// <summary>
        /// 所属区
        /// </summary>
        public int Zone { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public string SceneType { get; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 外网端口
        /// </summary>
        public int OuterPort { get; }

        public static StartSceneConfig DeserializeStartSceneConfig(ByteBuf _buf)
        {
            return new StartSceneConfig(_buf);
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
                    + "process:" + Process + ","
                    + "zone:" + Zone + ","
                    + "sceneType:" + SceneType + ","
                    + "name:" + Name + ","
                    + "outerPort:" + OuterPort + ","
                    + "}";
        }
    }
}