namespace ET
{
    /// <summary>
    /// 物品项类型
    /// </summary>
    public enum ItemType
    {
        All,
        Equip,
        Consumable,
        Material,
    }

    /// <summary>
    /// 物品操作指令
    /// </summary>
    public enum ItemOp
    {
        Add = 0,  //增加物品
        Remove = 1 //移除物品
    }

    /// <summary>
    /// 物品容器类型
    /// </summary>
    public enum ItemContainerType
    {
        Bag = 0,  //背包容器
        RoleInfo = 1, //游戏角色装配容器
    }
}