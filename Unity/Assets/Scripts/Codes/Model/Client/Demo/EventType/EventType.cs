using System.Collections.Generic;

namespace ET.Client.EventType
{
    #region 初始化

    public struct AppStart
    {
    }

    public struct AppStartInitFinish
    {
    }

    #endregion 初始化

    #region 场景

    public struct SceneChangeStart
    {
    }

    public struct SceneChangeFinish
    {
    }

    public struct AfterCreateClientScene
    {
    }

    public struct PingChange
    {
        public Scene ZoneScene;
        public long Ping;
    }

    public struct AfterCreateZoneScene
    {
    }

    public struct AfterCreateCurrentScene
    {
        public Scene CurrentScene;
    }

    public struct AfterCreateLoginScene
    {
        public Scene LoginScene;
    }

    #endregion 场景

    #region 登录

    public struct LoginFinish
    {
    }

    public struct LoadingBegin
    {
        public Scene Scene;
    }

    public struct LoadingFinish
    {
        public Scene Scene;
    }

    #endregion 登录

    #region 地图

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    #endregion 地图

    #region 角色面板

    public struct AddAttribute
    {
        public Scene ZoneScene;
        public int NumericType;
        public int AddValue;
    }

    public struct AddAttributeConfirm
    {
        public Scene ZoneScene;
        public bool ConfirmAdd;
        public Dictionary<int, long> Attributes;
    }

    public struct GetPoint
    {
    }

    public struct PointIsZero
    {
    }

    #endregion 角色面板

    #region 关卡系统

    public struct StartGameLevel
    {
    }

    public struct AdventureRoundReset
    {
    }

    public struct AdventureBattleRoundView
    {
        public Unit AttackUnit;
        public Unit TargetUnit;
    }

    public struct AdventureBattleRound
    {
        public Unit AttackUnit;
        public Unit TargetUnit;
    }

    public struct ShowDamageValueView
    {
        public Unit TargetUnit;
        public int DamageValue;
    }

    public struct AdventureBattleOver
    {
        public Unit WinUnit;
    }

    public struct AdventureBattleReport
    {
        public int Round;
        public BattleRoundResult BattleRoundResult;
    }

    public struct ShowAdventureHpBar
    {
        public Unit Unit;
        public bool isShow;
    }

    #endregion 关卡系统

    #region 打造系统

    public struct MakeQueueOver
    {
    }

    public struct ReceiveProduct
    {
    }

    #endregion 打造系统

    #region 任务系统

    public struct UpdateTaskInfo
    {
    }

    #endregion 任务系统

    #region 聊天系统

    public struct UpdateChatInfo
    {
    }

    #endregion 聊天系统
}