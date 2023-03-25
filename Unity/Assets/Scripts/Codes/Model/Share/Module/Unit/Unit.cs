using System.Diagnostics;
using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET
{
    [ChildOf(null)]
    [DebuggerDisplay("ViewName,nq")]
    public class Unit : Entity, IAwake<int>, IAddComponent, IGetComponent
    {
        [BsonElement]
        private float3 position;

        [BsonElement]
        private quaternion rotation;

        protected override string ViewName => $"{GetType().Name} ({Id})";

        public int ConfigId { get; set; } //配置表id

        [BsonIgnore]
        public UnitConfig Config => UnitConfigCategory.Instance.Get(ConfigId);

        public UnitType Type => (UnitType)UnitConfigCategory.Instance.Get(ConfigId).Type;

        //坐标

        [BsonIgnore]
        public float3 Position
        {
            get => position;
            set
            {
                float3 oldPos = position;
                position = value;
                EventSystem.Instance.Publish(this.DomainScene(), new EventType.ChangePosition() { Unit = this, OldPos = oldPos });
            }
        }

        [BsonIgnore]
        public float3 Forward
        {
            get => math.mul(Rotation, math.forward());
            set => Rotation = quaternion.LookRotation(value, math.up());
        }

        [BsonIgnore]
        public quaternion Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                EventSystem.Instance.Publish(this.DomainScene(), new EventType.ChangeRotation() { Unit = this });
            }
        }
    }
}