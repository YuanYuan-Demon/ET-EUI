
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



namespace ET.Client
{


public sealed partial class MyFloat3: Luban.BeanBase
{

    public MyFloat3(ByteBuf _buf) 
    {
        X = _buf.ReadInt();
        Y = _buf.ReadInt();
        Z = _buf.ReadInt();
        PostInit();
    }

    public static MyFloat3 DeserializeMyFloat3(ByteBuf _buf)
    {
        return new MyFloat3(_buf);
    }

    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public const int __ID__ = -1121610173;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<Type, IConfigSingleton> _tables)
    {
        PostResolve();
    }

    public override string ToString()
    {
        return "{ "
        + "x:" + X + ","
        + "y:" + Y + ","
        + "z:" + Z + ","
        + "}";
    }
}

}
