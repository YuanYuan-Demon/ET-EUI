using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    [FriendOfAttribute(typeof(ET.MoveComponent))]
    public class M2C_PathfindingResultHandler : AMHandler<M2C_PathfindingResult>
    {
        protected override async ETTask Run(Session session, M2C_PathfindingResult message)
        {
            Unit unit = session.GetUnitComponent().Get(message.Id);
            if (unit == null)
                return;

            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);

            //非当前玩家控制的角色直接进行移动
            if (!unit.IsMyUnit())
            {
                unit.GetComponent<MoveComponent>().StopForce();
                List<float3> points = new();
                points.Add(unit.Position);
                points.AddRange(message.Points.GetRange(1, message.Points.Count - 1));

                unit.GetComponent<MoveComponent>().MoveToAsync(points, speed).Coroutine();
                return;
            }

            //当前玩家控制的角色 需要进行和解计算
            //获取当前玩家控制的游戏角色在本地客户端的移动时间
            long moveTime = TimeHelper.ServerNow() - unit.GetComponent<MoveComponent>().BeginTime;
            long needTime = 0;  //每一段路径点之间移动所需的时间
            long totalTime = 0; //总共移动所需的时间
            int n = 0;  //移动的路径点索引
            float3 prePos = message.Points[0];
            for (int i = 1; i < message.Points.Count; i++)
            {
                float3 nextPos = message.Points[i];

                float distance = math.distance(nextPos, prePos);
                prePos = nextPos;
                needTime = (long)(distance / speed * 1000);

                totalTime += needTime;
                ++n;
                if (totalTime >= moveTime)
                {
                    ++n;
                    break;
                }
            }

            //如果本地客户端移动时间大于路径移动时间,则不进行同步移动,因为已经超过了服务器的移动时间
            if (totalTime <= moveTime)
                return;

            List<float3> list = new();
            list.Add(unit.Position);
            list.AddRange(message.Points.GetRange(1, message.Points.Count - 1));

            if (list.Count <= 1)
            {
                list.Clear();
                return;
            }
            await unit.GetComponent<MoveComponent>().MoveToAsync(list, speed);
        }
    }
}