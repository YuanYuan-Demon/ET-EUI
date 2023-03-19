namespace ET
{
    /// <summary>
    /// 物品项类型
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// 武器
        /// </summary>
        Weapon,

        /// <summary>
        /// 防具
        /// </summary>
        Armor,

        /// <summary>
        /// 戒指
        /// </summary>
        Ring,

        /// <summary>
        /// 道具
        /// </summary>
        Prop,
    }

    /// <summary>
    /// 物品操作指令
    /// </summary>
    public enum ItemOp
    {
        /// <summary>
        /// 增加物品
        /// </summary>
        Add,

        /// <summary>
        /// 移除物品
        /// </summary>
        Remove,
    }

    /// <summary>
    /// 物品容器类型
    /// </summary>
    public enum ItemContainerType
    {
        /// <summary>
        /// 背包容器
        /// </summary>
        Bag,

        /// <summary>
        /// 游戏角色装配容器
        /// </summary>
        RoleInfo,
    }
}