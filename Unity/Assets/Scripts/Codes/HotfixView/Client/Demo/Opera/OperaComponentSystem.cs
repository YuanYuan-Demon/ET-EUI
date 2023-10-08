using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (OperaComponent))]
    public static class OperaComponentSystem
    {
        public static void JoyMove(this OperaComponent self, float3 moveDir)
        {
            var unit = self.GetMyUnit();
            var unitPos = unit.Position;
            var newPos = unitPos + moveDir * 2;

            List<float3> list = new() { unit.Position, newPos };
            unit.MoveToAsync(list).Coroutine();

            self.ClientScene().GetComponent<SessionComponent>().Session.Send(new C2M_PathfindingResult() { Position = newPos });
        }

        public static void Stop(this OperaComponent self)
        {
            var unit = self.GetMyUnit();
            unit.GetComponent<MoveComponent>().StopForce();

            self.ClientScene().GetComponent<SessionComponent>().Session.Send(new C2M_JoyStop() { Position = unit.Position, Forward = unit.Forward });
        }

#region 生命周期

        [ObjectSystem]
        public class OperaComponentAwakeSystem: AwakeSystem<OperaComponent>
        {
            protected override void Awake(OperaComponent self) => self.mapMask = LayerMask.GetMask("Map");
        }

        [ObjectSystem]
        public class OperaComponentUpdateSystem: UpdateSystem<OperaComponent>
        {
            protected override void Update(OperaComponent self)
            {
                if (!UIHelper.IsTouchedUI())
                    if (Input.GetMouseButtonDown(0))
                    {
                        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out var hit, 1000, self.mapMask))
                            self.ClientScene().GetComponent<SessionComponent>().Session.Send(new C2M_PathfindingResult() { Position = hit.point });
                    }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    CodeLoader.Instance.LoadHotfix();
                    EventSystem.Instance.Load();
                    Log.Debug("hot reload success!");
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    C2M_TransferMap c2MTransferMap = new();
                    self.ClientScene().Call(c2MTransferMap).Coroutine();
                }
            }
        }

#endregion
    }
}