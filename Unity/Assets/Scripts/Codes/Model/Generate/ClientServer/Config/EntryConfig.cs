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
    public sealed partial class EntryConfig: Luban.BeanBase
    {
        public const int __ID__ = 66159156;

        public EntryConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            EntryType = _buf.ReadInt();
            EntryLevel = _buf.ReadInt();
            EntryScore = _buf.ReadInt();
            AttributeType = (NumericType)_buf.ReadInt();
            AttributeMinValue = _buf.ReadInt();
            AttributeMaxValue = _buf.ReadInt();
            PostInit();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 词条类型
        /// </summary>
        public int EntryType { get; }

        /// <summary>
        /// 词条等级
        /// </summary>
        public int EntryLevel { get; }

        /// <summary>
        /// 词条评分
        /// </summary>
        public int EntryScore { get; }

        /// <summary>
        /// 属性类型
        /// </summary>
        public NumericType AttributeType { get; }

        /// <summary>
        /// 属性值最小范围
        /// </summary>
        public int AttributeMinValue { get; }

        /// <summary>
        /// 属性值最大范围
        /// </summary>
        public int AttributeMaxValue { get; }

        public static EntryConfig DeserializeEntryConfig(ByteBuf _buf)
        {
            return new EntryConfig(_buf);
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
                    + "entryType:" + EntryType + ","
                    + "entryLevel:" + EntryLevel + ","
                    + "entryScore:" + EntryScore + ","
                    + "attributeType:" + AttributeType + ","
                    + "attributeMinValue:" + AttributeMinValue + ","
                    + "attributeMaxValue:" + AttributeMaxValue + ","
                    + "}";
        }
    }
}