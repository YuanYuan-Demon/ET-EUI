using System.Diagnostics;
using ET.EventType;
using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET
{
    [ChildOf]
    [DebuggerDisplay("ViewName,nq")]
    public class Unit: Entity, IAwake<int>, IAddComponent, IGetComponent
    {
        [BsonElement]
        private float3 position;

        [BsonElement]
        private quaternion rotation;

        protected override string ViewName => $"{this.GetType().Name} ({this.Id})";

        public int ConfigId { get; set; } //配置表id

        [BsonIgnore]
        public UnitConfig Config => UnitConfigCategory.Instance.Get(this.ConfigId);

        public UnitType Type => UnitConfigCategory.Instance.Get(this.ConfigId).UnitType;

        //坐标

        [BsonIgnore]
        public float3 Position
        {
            get => this.position;
            set
            {
                float3 oldPos = this.position;
                this.position = value;
                EventSystem.Instance.Publish(this.DomainScene(), new ChangePosition() { Unit = this, OldPos = oldPos });
            }
        }

        [BsonIgnore]
        public float3 Forward
        {
            get => math.mul(this.Rotation, math.forward());
            set => this.Rotation = quaternion.LookRotation(value, math.up());
        }

        [BsonIgnore]
        public quaternion Rotation
        {
            get => this.rotation;
            set
            {
                this.rotation = value;
                EventSystem.Instance.Publish(this.DomainScene(), new ChangeRotation() { Unit = this });
            }
        }
    }
}