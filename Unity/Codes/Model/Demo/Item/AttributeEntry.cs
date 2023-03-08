namespace ET
{
    public enum EntryType
    {
        /// <summary>
        /// 普通词条
        /// </summary>
        Common = 1,

        /// <summary>
        /// 特殊词条
        /// </summary>
        Special = 2,
    }

#if SERVER

    public class AttributeEntry : Entity, IAwake, IDestroy, ISerializeToEntity
#else
    public class AttributeEntry: Entity, IAwake, IDestroy
#endif
    {
        /// <summary>
        ///     词条数值属性类型
        /// </summary>
        public int AttributeName;

        /// <summary>
        ///     词条类型
        /// </summary>
        public EntryType EntryType;

        /// <summary>
        ///     词条数值属性值
        /// </summary>
        public long AttributeValue;
    }
}