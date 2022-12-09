using ET.EventType;
using UnityEngine;

namespace ET
{
    public class ChangePosition_SyncGameObjectPos : AEventClass<EventType.ChangePosition>
    {
        protected override void Run(EventType.ChangePosition changePosition)
        {
            EventType.ChangePosition args = changePosition;
            GameObjectComponent gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Transform transform = gameObjectComponent.GameObject.transform;
            transform.position = args.Unit.Position;
        }
    }
}