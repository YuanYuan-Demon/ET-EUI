namespace ET
{
    /// <summary>
    /// 装备装配部位
    /// </summary>
    public enum EquipPosition
    {
        /// <summary>
        /// 不可装备
        /// </summary>
        None,

        /// <summary>
        /// 头盔
        /// </summary>
        Head,

        /// <summary>
        /// 衣服
        /// </summary>
        Clothes,

        /// <summary>
        /// 鞋子
        /// </summary>
        Shoes,

        /// <summary>
        /// 戒指
        /// </summary>
        Ring,

        /// <summary>
        /// 武器
        /// </summary>
        Weapon,

        /// <summary>
        /// 盾牌
        /// </summary>
        Shield,
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