namespace ET
{
    /// <summary>
    ///     物品操作指令
    /// </summary>
    public enum ItemOp
    {
        Add,    //增加物品
        Update, //更新物品
        Remove, //移除物品
    }

    /// <summary>
    ///     物品容器类型
    /// </summary>
    public enum ItemContainerType
    {
        Bag,   //背包容器
        Equip, //游戏角色装配容器
    }
}