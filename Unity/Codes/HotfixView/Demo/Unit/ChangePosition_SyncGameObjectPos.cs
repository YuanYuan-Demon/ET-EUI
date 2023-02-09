using ET.EventType;
using UnityEngine;
using UnityEngine.Rendering;

namespace ET
{
    [FriendClassAttribute(typeof(ET.GameObjectComponent))]
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

            SortingGroup sortingGroup = transform.GetComponent<SortingGroup>();
            if (sortingGroup == null)
            {
                return;
            }
            sortingGroup.sortingOrder = -(int)args.Unit.Position.y;
        }
    }
}