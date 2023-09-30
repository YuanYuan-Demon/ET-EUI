using System.Collections.Generic;

namespace ET
{
    public static class OpcodeHelper
    {
        [StaticField]
        private static readonly HashSet<ushort> ignoreDebugLogMessageSet = new()
        {
            OuterMessage.C2G_Ping,
            OuterMessage.G2C_Ping,
            OuterMessage.C2G_Benchmark,
            OuterMessage.G2C_Benchmark,
            OuterMessage.C2M_PathfindingResult,
            OuterMessage.M2C_PathfindingResult,
            ushort.MaxValue // ActorResponse
        };

        private static bool IsNeedLogMessage(ushort opcode)
        {
            return !ignoreDebugLogMessageSet.Contains(opcode);
        }

        public static bool IsOuterMessage(ushort opcode)
        {
            return opcode < OpcodeRangeDefine.OuterMaxOpcode;
        }

        public static bool IsInnerMessage(ushort opcode)
        {
            return opcode >= OpcodeRangeDefine.InnerMinOpcode;
        }

        public static void LogMsg(int zone, object message)
        {
            var opcode = NetServices.Instance.GetOpcode(message.GetType());
            if (!IsNeedLogMessage(opcode))
            {
                return;
            }

            Logger.Instance.Debug("zone: {0} {1}", zone, message);
        }

        public static void LogMsg(long actorId, object message)
        {
            var opcode = NetServices.Instance.GetOpcode(message.GetType());
            if (!IsNeedLogMessage(opcode))
            {
                return;
            }

            Logger.Instance.Debug("actorId: {0} {1}", actorId, message);
        }
    }
}