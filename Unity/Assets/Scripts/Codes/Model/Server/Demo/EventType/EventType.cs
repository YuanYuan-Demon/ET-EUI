namespace ET.Server.EventType
{
    #region 初始化

    public struct AppStart
    {
    }

    #endregion 初始化

    #region 地图

    public struct MoveStart
    {
        public Unit Unit;
    }

    public struct MoveStop
    {
        public Unit Unit;
    }

    #endregion 地图

    #region 关卡系统

    public struct BattleWin
    {
        public Unit Unit;
        public int LevelId;
    }

    #endregion 关卡系统

    #region 背包系统

    public struct ChangeEquipItem
    {
        public Unit Unit;
        public Item Item;
        public EquipOp EquipOp;
    }

    #endregion 背包系统

    #region 打造系统

    public struct MakeProdutionOver
    {
        public Unit Unit;
        public int ProductionConfigId;
    }

    #endregion 打造系统
}