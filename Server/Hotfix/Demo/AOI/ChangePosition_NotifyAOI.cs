using ET.EventType;
using UnityEngine;

namespace ET
{
    [Event]
    public class ChangePosition_NotifyAOI : AEventClass<EventType.ChangePosition>
    {
        protected override void Run(ChangePosition changePosition)
        {
            Vector3 oldPos = changePosition.OldPos.Value;
            Unit unit = changePosition.Unit;
            int oldCellX = (int)(oldPos.x * 1000) / AOIManagerComponent.CellSize;
            int oldCellY = (int)(oldPos.z * 1000) / AOIManagerComponent.CellSize;
            int newCellX = (int)(unit.Position.x * 1000) / AOIManagerComponent.CellSize;
            int newCellY = (int)(unit.Position.z * 1000) / AOIManagerComponent.CellSize;
            if (oldCellX == newCellX && oldCellY == newCellY)
            {
                return;
            }

            AOIEntity aoiEntity = unit.GetComponent<AOIEntity>();
            if (aoiEntity == null)
            {
                return;
            }

            unit.Domain.GetComponent<AOIManagerComponent>().Move(aoiEntity, newCellX, newCellY);
        }
    }
}