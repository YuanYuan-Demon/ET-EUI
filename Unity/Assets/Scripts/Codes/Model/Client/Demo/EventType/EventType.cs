using System.Collections.Generic;

namespace ET.Client.EventType
{
    #region 初始化

    public struct AppStart
    {
    }

    public struct AppStartInitFinish
    {
        public Scene ZoneScene;
    }

    #endregion 初始化

    #region 场景

    public struct SceneChangeStart
    {
        public Scene ZoneScene;
    }

    public struct SceneChangeFinish
    {
    }

    public struct AfterCreateClientScene
    {
    }

    public struct SceneChangeFinishAsync
    {
        public Scene ZoneScene;
        public Scene CurrentScene;
    }

    public struct PingChange
    {
        public Scene ZoneScene;
        public long Ping;
    }

    public struct AfterCreateZoneScene
    {
        public Scene ZoneScene;
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
        public Scene ZoneScene;
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
        public Scene ZoneScene;
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
        public Scene ZoneScene;
    }

    public struct PointIsZero
    {
        public Scene ZoneScene;
    }

    #endregion 角色面板

    #region 关卡系统

    public struct StartGameLevel
    {
        public Scene ZoneScene;
    }

    public struct AdventureRoundReset
    {
        public Scene ZoneScene;
    }

    public struct AdventureBattleRoundView
    {
        public Scene ZoneScene;
        public Unit AttackUnit;
        public Unit TargetUnit;
    }

    public struct AdventureBattleRound
    {
        public Scene ZoneScene;
        public Unit AttackUnit;
        public Unit TargetUnit;
    }

    public struct ShowDamageValueView
    {
        public Scene ZoneScene;
        public Unit TargetUnit;
        public int DamageValue;
    }

    public struct AdventureBattleOver
    {
        public Scene ZoneScene;
        public Unit WinUnit;
    }

    public struct AdventureBattleReport
    {
        public Scene ZoneScene;
        public int Round;
        public BattleRoundResult BattleRoundResult;
    }

    public class ShowAdventureHpBar : DisposeObject
    {
        [StaticField]
        public static readonly ShowAdventureHpBar Instance = new();

        public Unit Unit;
        public bool isShow;

        public override void Dispose()
        {
            this.Unit = null;
        }
    }

    #endregion 关卡系统

    #region 打造系统

    public class MakeQueueOver : DisposeObject
    {
        [StaticField]
        public static readonly MakeQueueOver Instance = new();

        public Scene ZoneScene;

        public override void Dispose()
        {
            this.ZoneScene = null;
        }
    }

    #endregion 打造系统

    #region 任务系统

    public struct UpdateTaskInfo
    {
        public Scene ZoneScene;
    }

    #endregion 任务系统

    #region 聊天系统

    public struct UpdateChatInfo
    {
        public Scene ZoneScene;
    }

    #endregion 聊天系统
}