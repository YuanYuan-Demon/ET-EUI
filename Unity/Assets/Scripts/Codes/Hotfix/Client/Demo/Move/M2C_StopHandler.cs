using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class M2C_StopHandler: AMHandler<M2C_Stop>
    {
        private async ETTask MoveToAndForward(Unit unit, float3 pos, quaternion rotation)
        {
            List<float3> list = new() { unit.Position, pos };
            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
            bool ret = await unit.GetComponent<MoveComponent>().MoveToAsync(list, speed);
            if (ret)
            {
                unit.Position = pos;
                unit.Rotation = rotation;
            }

            unit.GetComponent<ObjectWait>()?.Notify(new Wait_UnitStop() { Error = 0 });
        }

        protected override async ETTask Run(Session session, M2C_Stop message)
        {
            Unit unit = session.DomainScene().CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
            if (unit == null || unit.IsMyUnit())
            {
                return;
            }

            if (unit.IsMyUnit() && message.Error == ErrorCode.ERR_Success)
            {
                unit.GetComponent<ObjectWait>()?.Notify(new Wait_UnitStop() { Error = 0 });
                return;
            }

            await this.MoveToAndForward(unit, message.Position, message.Rotation);
        }
    }
}