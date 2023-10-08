using Unity.Mathematics;

namespace ET
{
    public partial class MyFloat3
    {
        public static implicit operator float3(MyFloat3 f) => new(f.X, f.Y, f.Z);
    }
}