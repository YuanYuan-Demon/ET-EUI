using System.Collections.Generic;

namespace ET.EventType
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

    public struct AfterUnitCreateAsync
    {
        public Unit Unit;
    }

    public struct MoveStart
    {
        public Unit Unit;
    }

    public struct MoveStop
    {
        public Unit Unit;
    }

    public class ChangePosition : DisposeObject
    {
        public static readonly ChangePosition Instance = new ChangePosition();

        public Unit Unit;
        public WrapVector3 OldPos = new WrapVector3();

        // 因为是重复利用的，所以用完PublishClass会调用Dispose
        public override void Dispose()
        {
            this.Unit = null;
        }
    }

    public class ChangeRotation : DisposeObject
    {
        public static readonly ChangeRotation Instance = new ChangeRotation();

        public Unit Unit;

        // 因为是重复利用的，所以用完PublishClass会调用Dispose
        public override void Dispose()
        {
            this.Unit = null;
        }
    }

    #endregion 地图

    #region 角色面板

    public struct AddAttributeConfirm
    {
        public Scene ZoneScene;
        public bool ConfirmAdd;
        public Dictionary<int, long> Attributes;
    }

    public struct AddAttribute
    {
        public Scene ZoneScene;
        public int NumericType;
        public int AddValue;
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

    public struct AdventureBattleRoundViewAsync
    {
        public Scene ZoneScene;
        public Unit AttackUnit;
        public Unit TargetUnit;
    }

    public struct AdventureBattleRoundAsync
    {
        public Scene ZoneScene;
        public Unit AttackUnit;
        public Unit TargetUnit;
    }

    public struct ShowDamageValueViewAsync
    {
        public Scene ZoneScene;
        public Unit TargetUnit;
        public int DamageValue;
    }

    public struct AdventureBattleOverAsync
    {
        public Scene ZoneScene;
        public Unit WinUnit;
    }

    public struct AdventureBattleReportAsync
    {
        public Scene ZoneScene;
        public int Round;
        public BattleRoundResult BattleRoundResult;
    }

    public class ShowAdventureHpBar : DisposeObject
    {
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
        public static readonly MakeQueueOver Instance = new MakeQueueOver();

        public Scene ZoneScene;

        public override void Dispose()
        {
            this.ZoneScene = null;
        }
    }

    #endregion 打造系统
}