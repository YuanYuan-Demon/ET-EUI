using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class MoveComponent : Entity, IAwake, IDestroy
    {
        // 开启移动协程的时间
        public long BeginTime;

        // 开启移动协程的Unit的位置
        public float3 StartPos;

        public long MoveTimer;

        public float Speed;

        public ETTask<bool> tcs;

        // m/s
        public List<float3> Targets = new List<float3>();

        public int N;

        public int TurnTime;

        public bool IsTurnHorizontal;

        public quaternion From;

        public quaternion To;

        public float3 PreTarget => this.Targets[N - 1];

        public float3 NextTarget => this.Targets[this.N];

        // 每个点的开始时间
        public long StartTime { get; set; }

        public float3 RealPos => this.Targets[0];

        public long NeedTime { get; set; }

        public float3 FinalTarget => this.Targets[^1];
    }
}