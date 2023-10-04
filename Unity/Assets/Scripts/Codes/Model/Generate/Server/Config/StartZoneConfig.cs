
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

public sealed partial class StartZoneConfig: Luban.BeanBase
{

    public StartZoneConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        DBConnection = _buf.ReadString();
        DBName = _buf.ReadString();
        PostInit();
    }

    public static StartZoneConfig DeserializeStartZoneConfig(ByteBuf _buf)
    {
        return new StartZoneConfig(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// 数据库地址
    /// </summary>
    public string DBConnection { get; }
    /// <summary>
    /// 数据库名
    /// </summary>
    public string DBName { get; }

    public const int __ID__ = -457316368;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<Type, IConfigSingleton> _tables)
    {
        PostResolve();
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "dBConnection:" + DBConnection + ","
        + "dBName:" + DBName + ","
        + "}";
    }
}

}

