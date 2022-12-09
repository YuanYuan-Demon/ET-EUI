using ET.EventType;
using UnityEngine;

namespace ET
{
    public class ChangeRotation_SyncGameObjectRotation : AEventClass<EventType.ChangeRotation>
    {
        protected override void Run(EventType.ChangeRotation changeRotation)
        {
            GameObjectComponent gameObjectComponent = changeRotation.Unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Transform transform = gameObjectComponent.GameObject.transform;
            transform.rotation = (changeRotation as EventType.ChangeRotation).Unit.Rotation;
        }
    }
}