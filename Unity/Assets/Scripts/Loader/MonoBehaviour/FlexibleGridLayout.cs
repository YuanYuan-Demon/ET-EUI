using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public class FlexibleGridLayout : LayoutGroup
    {
        private bool fitX;

        private bool fitY;

        public FitType fitType;

        public int rows;

        public int columns;

        public Vector2 cellSize;

        public Vector2 spacing;

        public Vector2 size;

        public enum FitType
        {
            Uniform,
            Width,
            Height,
            FixedRows,
            FixedCols,
        }

        public override void CalculateLayoutInputVertical()
        {
        }

        public override void SetLayoutHorizontal()
        {
            size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
            float sqrRt = Mathf.Sqrt(rectChildren.Count);

            if (fitType == FitType.Uniform || fitType == FitType.Width || fitType == FitType.Height)
            {
                fitX = fitY = true;
                columns = Mathf.CeilToInt(sqrRt);
                rows = columns;
            }
            if (fitType == FitType.Height || fitType == FitType.FixedRows)
            {
                columns = Mathf.CeilToInt(rectChildren.Count / (float)rows);
            }
            if (fitType == FitType.Width || fitType == FitType.FixedCols)
            {
                rows = Mathf.CeilToInt(rectChildren.Count / (float)columns);
            }

            float width = size.x;
            float height = size.y;

            float cellWidth = (width - (spacing.x * (columns - 1)) - padding.left - padding.right) / columns;
            float cellHeight = (height - spacing.y * (rows - 1) - padding.top - padding.bottom) / rows;

            cellSize.x = fitX ? cellWidth : cellSize.x;
            cellSize.y = fitY ? cellHeight : cellSize.y;
            for (int i = 0; i < rectChildren.Count; i++)
            {
                int rowIndex = i / columns;
                int colIndex = i % columns;
                var item = rectChildren[i];
                Vector2 pos = new Vector2(x: (cellSize.x + spacing.x) * colIndex + padding.left,
                                  y: (cellSize.y + spacing.y) * rowIndex + padding.top);
                SetChildAlongAxis(item, 0, pos.x, cellSize.x);
                SetChildAlongAxis(item, 1, pos.y, cellSize.y);
            }
        }

        public override void SetLayoutVertical()
        {
        }
    }
}