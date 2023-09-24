namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Loop Vertical Scroll Rect", 51)]
    [DisallowMultipleComponent]
    public class LoopVerticalScrollRect: LoopScrollRect
    {
        protected override float GetSize(RectTransform item, bool includeSpacing = true)
        {
            float size = includeSpacing? this.contentSpacing : 0;
            if (this.m_GridLayout != null)
            {
                size += this.m_GridLayout.cellSize.y;
            }
            else
            {
                size += LayoutUtility.GetPreferredHeight(item);
            }

            size *= this.m_Content.localScale.y;
            return size;
        }

        protected override float GetDimension(Vector2 vector) => vector.y;

        protected override float GetAbsDimension(Vector2 vector) => vector.y;

        protected override Vector2 GetVector(float value) => new(0, value);

        protected override void Awake()
        {
            this.direction = LoopScrollRectDirection.Vertical;
            base.Awake();
            if (this.m_Content)
            {
                GridLayoutGroup layout = this.m_Content.GetComponent<GridLayoutGroup>();
                if (layout != null && layout.constraint != GridLayoutGroup.Constraint.FixedColumnCount)
                {
                    Debug.LogError("[LoopScrollRect] unsupported GridLayoutGroup constraint");
                }
            }
        }

        protected override bool UpdateItems(ref Bounds viewBounds, ref Bounds contentBounds)
        {
            var changed = false;

            // special case: handling move several page in one frame
            if (viewBounds.size.y < contentBounds.min.y - viewBounds.max.y && this.itemTypeEnd > this.itemTypeStart)
            {
                int maxItemTypeStart = -1;
                if (this.totalCount >= 0)
                {
                    maxItemTypeStart = Mathf.Max(0, this.totalCount - (this.itemTypeEnd - this.itemTypeStart));
                }

                float currentSize = contentBounds.size.y;
                float elementSize = (currentSize - this.contentSpacing * (this.CurrentLines - 1)) / this.CurrentLines;
                this.ReturnToTempPool(true, this.itemTypeEnd - this.itemTypeStart);
                this.itemTypeStart = this.itemTypeEnd;

                int offsetCount = Mathf.FloorToInt((contentBounds.min.y - viewBounds.max.y) / (elementSize + this.contentSpacing));
                if (maxItemTypeStart >= 0 && this.itemTypeStart + offsetCount * this.contentConstraintCount > maxItemTypeStart)
                {
                    offsetCount = Mathf.FloorToInt((float)(maxItemTypeStart - this.itemTypeStart) / this.contentConstraintCount);
                }

                this.itemTypeStart += offsetCount * this.contentConstraintCount;
                if (this.totalCount >= 0)
                {
                    this.itemTypeStart = Mathf.Max(this.itemTypeStart, 0);
                }

                this.itemTypeEnd = this.itemTypeStart;

                float offset = offsetCount * (elementSize + this.contentSpacing);
                this.m_Content.anchoredPosition -= new Vector2(0, offset + (this.reverseDirection? 0 : currentSize));
                contentBounds.center -= new Vector3(0, offset + currentSize / 2, 0);
                contentBounds.size = Vector3.zero;

                changed = true;
            }

            if (viewBounds.min.y - contentBounds.max.y > viewBounds.size.y && this.itemTypeEnd > this.itemTypeStart)
            {
                float currentSize = contentBounds.size.y;
                float elementSize = (currentSize - this.contentSpacing * (this.CurrentLines - 1)) / this.CurrentLines;
                this.ReturnToTempPool(false, this.itemTypeEnd - this.itemTypeStart);
                this.itemTypeEnd = this.itemTypeStart;

                int offsetCount = Mathf.FloorToInt((viewBounds.min.y - contentBounds.max.y) / (elementSize + this.contentSpacing));
                if (this.totalCount >= 0 && this.itemTypeStart - offsetCount * this.contentConstraintCount < 0)
                {
                    offsetCount = Mathf.FloorToInt((float)this.itemTypeStart / this.contentConstraintCount);
                }

                this.itemTypeStart -= offsetCount * this.contentConstraintCount;
                if (this.totalCount >= 0)
                {
                    this.itemTypeStart = Mathf.Max(this.itemTypeStart, 0);
                }

                this.itemTypeEnd = this.itemTypeStart;

                float offset = offsetCount * (elementSize + this.contentSpacing);
                this.m_Content.anchoredPosition += new Vector2(0, offset + (this.reverseDirection? currentSize : 0));
                contentBounds.center += new Vector3(0, offset + currentSize / 2, 0);
                contentBounds.size = Vector3.zero;

                changed = true;
            }

            if (viewBounds.min.y > contentBounds.min.y + this.threshold + this.m_ContentBottomPadding)
            {
                float size = this.DeleteItemAtEnd(), totalSize = size;
                while (size > 0 && viewBounds.min.y > contentBounds.min.y + this.threshold + this.m_ContentBottomPadding + totalSize)
                {
                    size = this.DeleteItemAtEnd();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (viewBounds.max.y < contentBounds.max.y - this.threshold - this.m_ContentTopPadding)
            {
                float size = this.DeleteItemAtStart(), totalSize = size;
                while (size > 0 && viewBounds.max.y < contentBounds.max.y - this.threshold - this.m_ContentTopPadding - totalSize)
                {
                    size = this.DeleteItemAtStart();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (viewBounds.min.y < contentBounds.min.y + this.m_ContentBottomPadding)
            {
                float size = this.NewItemAtEnd(), totalSize = size;
                while (size > 0 && viewBounds.min.y < contentBounds.min.y + this.m_ContentBottomPadding - totalSize)
                {
                    size = this.NewItemAtEnd();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (viewBounds.max.y > contentBounds.max.y - this.m_ContentTopPadding)
            {
                float size = this.NewItemAtStart(), totalSize = size;
                while (size > 0 && viewBounds.max.y > contentBounds.max.y - this.m_ContentTopPadding + totalSize)
                {
                    size = this.NewItemAtStart();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (changed)
            {
                this.ClearTempPool();
            }

            return changed;
        }
    }
}