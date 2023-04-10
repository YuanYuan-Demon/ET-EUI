using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (OperaComponent))]
    public static class OperaComponentSystem
    {
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
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, 1000, self.mapMask))
                    {
                        self.ClientScene().GetComponent<SessionComponent>().Session.Send(new C2M_PathfindingResult() { Position = hit.point });
                    }
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
                    self.ClientScene().GetComponent<SessionComponent>().Session.Call(c2MTransferMap).Coroutine();
                }
            }
        }

        #endregion

        public static void JoyMove(this OperaComponent self, float3 moveDir)
        {
            Unit unit = self.GetMyUnit();
            float3 unitPos = unit.Position;
            float3 newPos = unitPos + moveDir * 2;

            List<float3> list = new() { unit.Position, newPos };
            unit.MoveToAsync(list).Coroutine();

            self.ClientScene().GetComponent<SessionComponent>().Session.Send(new C2M_PathfindingResult() { Position = newPos });
        }

        public static void Stop(this OperaComponent self)
        {
            Unit unit = self.GetMyUnit();
            unit.GetComponent<MoveComponent>().StopForce();

            self.ClientScene().GetComponent<SessionComponent>().Session.Send(new C2M_JoyStop() { Position = unit.Position, Forward = unit.Forward });
        }
    }
}