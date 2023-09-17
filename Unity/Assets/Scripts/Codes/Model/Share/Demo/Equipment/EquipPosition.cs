namespace ET
{
    /// <summary>
    /// 装备装配部位
    /// </summary>
    public enum EquipPosition
    {
        无,
        头盔,
        衣服,
        鞋子,
        护肩,
        武器,
        副手,
        裤子,
    }

    /// <summary>
    /// 装备操作指令
    /// </summary>
    public enum EquipOp
    {
        /// <summary>
        /// 穿戴
        /// </summary>
        Load,

        /// <summary>
        /// 卸下
        /// </summary>
        Unload,
    }
}