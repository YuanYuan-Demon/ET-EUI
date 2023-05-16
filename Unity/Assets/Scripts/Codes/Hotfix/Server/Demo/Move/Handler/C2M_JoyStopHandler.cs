using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_JoyStopHandler : AMActorLocationHandler<Unit, C2M_JoyStop>
    {
        protected override async ETTask Run(Unit unit, C2M_JoyStop message)
        {
            List<float3> list = new();

            float3 target = message.Position;
            unit.GetComponent<PathfindingComponent>().Find(unit.Position, target, list);
            if (list.Count < 2)
            {
                unit.Stop(3);
                return;
            }

            //广播寻路路径
            M2C_PathfindingResult m2CPathfindingResult = new();
            m2CPathfindingResult.Id = unit.Id;
            m2CPathfindingResult.Points.AddRange(list);

            MessageHelper.Broadcast(unit, m2CPathfindingResult);

            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
            bool ret = await unit.GetComponent<MoveComponent>().MoveToAsync(list, speed);
            unit.Forward = message.Forward;
            unit.Stop(0);
        }
    }
}