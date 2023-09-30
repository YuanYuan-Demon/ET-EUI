using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof (MoveComponent))]
    [FriendOf(typeof (NumericComponent))]
    public static class UnitHelper
    {
        public static UnitInfo ToNUnit(this Unit unit)
        {
            var nc = unit.GetComponent<NumericComponent>();
            UnitInfo unitInfo = new()
            {
                UnitId = unit.Id,
                ConfigId = unit.ConfigId,
                Type = unit.Type,
                Position = unit.Position,
                Forward = unit.Forward,
                Numeric = nc.NumericDic.ToDictionary(pair => pair.Key, pair => pair.Value),
                NRoleInfo = unit.GetComponent<RoleInfo>().ToNRoleInfo(false),
            };

            var moveComponent = unit.GetComponent<MoveComponent>();
            if (moveComponent != null && !moveComponent.IsArrived())
            {
                unitInfo.MoveInfo = new() { Targets = new() };
                unitInfo.MoveInfo.Targets.Add(unit.Position);
                for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
                {
                    float3 pos = moveComponent.Targets[i];
                    unitInfo.MoveInfo.Targets.Add(pos);
                }
            }

            return unitInfo;
        }

        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, AOIEntity> GetBeSeePlayers(this Unit self) => self.GetComponent<AOIEntity>().GetBeSeePlayers();

        public static async ETTask InitUnit(Unit unit, bool isNewPlayer) => await ETTask.CompletedTask;
    }
}