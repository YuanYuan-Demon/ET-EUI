using UnityEngine;

namespace ET
{
    namespace EventType
    {
        #region 初始化

        public struct AppStart
        {
        }

        #endregion 初始化

        #region 地图

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

        public struct MoveStart
        {
            public Unit Unit;
        }

        public struct MoveStop
        {
            public Unit Unit;
        }

        #endregion 地图

        #region AOI

        public struct UnitEnterSightRange
        {
            public AOIEntity A;
            public AOIEntity B;
        }

        public struct UnitLeaveSightRange
        {
            public AOIEntity A;
            public AOIEntity B;
        }

        #endregion AOI

        #region 关卡系统

        public struct BattleWin
        {
            public Unit Unit;
            public int LevelId;
        }

        #endregion 关卡系统
    }
}