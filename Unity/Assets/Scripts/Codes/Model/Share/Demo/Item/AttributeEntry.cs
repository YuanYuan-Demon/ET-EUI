namespace ET
{
    public enum EntryType
    {
        /// <summary>
        ///     普通词条
        /// </summary>
        Common = 1,

        /// <summary>
        ///     特殊词条
        /// </summary>
        Special = 2,
    }

    [ChildOf(typeof (EquipInfoComponent))]
    public class AttributeEntry: Entity, IAwake, IDestroy, ISerializeToEntity
    {
        /// <summary>
        ///     词条数值属性类型
        /// </summary>
        public NumericType AttributeType;

        /// <summary>
        ///     词条数值属性值
        /// </summary>
        public long AttributeValue;

        /// <summary>
        ///     词条类型
        /// </summary>
        public EntryType EntryType;
    }
}