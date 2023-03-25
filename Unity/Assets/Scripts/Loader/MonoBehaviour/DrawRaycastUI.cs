using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class DrawRaycastUI : MonoBehaviour
    {
        private static Vector3[] fourCorners = new Vector3[4];

        private void OnDrawGizmos()
        {
            foreach (var g in FindObjectsOfType<MaskableGraphic>())
            {
                if (g.raycastTarget)
                {
                    RectTransform rectTransform = g.transform as RectTransform;
                    rectTransform.GetWorldCorners(fourCorners);
                    Gizmos.color = Color.green;
                    for (int i = 0; i < 4; i++)
                        Gizmos.DrawLine(fourCorners[i], fourCorners[(i + 1) % 4]);
                }
            }
        }
    }
}