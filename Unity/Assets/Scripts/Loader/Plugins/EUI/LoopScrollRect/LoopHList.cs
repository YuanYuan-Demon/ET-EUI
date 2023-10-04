namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Loop H List", 50)]
    [DisallowMultipleComponent]
    public class LoopHList: LoopList
    {
        protected override void Awake()
        {
            this.direction = LoopScrollRectDirection.Horizontal;
            base.Awake();
            if (this.m_Content)
            {
                var layout = this.m_Content.GetComponent<GridLayoutGroup>();
                if (layout != null && layout.constraint != GridLayoutGroup.Constraint.FixedRowCount)
                {
                    Debug.LogError("[LoopScrollRect] unsupported GridLayoutGroup constraint");
                }
            }
        }

        protected override float GetSize(RectTransform item, bool includeSpacing)
        {
            var size = includeSpacing? this.contentSpacing : 0;
            if (this.m_GridLayout != null)
            {
                size += this.m_GridLayout.cellSize.x;
            }
            else
            {
                size += LayoutUtility.GetPreferredWidth(item);
            }

            size *= this.m_Content.localScale.x;
            return size;
        }

        protected override float GetDimension(Vector2 vector) => -vector.x;

        protected override float GetAbsDimension(Vector2 vector) => vector.x;

        protected override Vector2 GetVector(float value) => new(-value, 0);

        protected override bool UpdateItems(ref Bounds viewBounds, ref Bounds contentBounds)
        {
            var changed = false;

            // special case: handling move several page in one frame
            if (viewBounds.size.x < contentBounds.min.x - viewBounds.max.x && this.itemTypeEnd > this.itemTypeStart)
            {
                var currentSize = contentBounds.size.x;
                var elementSize = (currentSize - this.contentSpacing * (this.CurrentLines - 1)) / this.CurrentLines;
                this.ReturnToTempPool(false, this.itemTypeEnd - this.itemTypeStart);
                this.itemTypeEnd = this.itemTypeStart;

                var offsetCount = Mathf.FloorToInt((contentBounds.min.x - viewBounds.max.x) / (elementSize + this.contentSpacing));
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

                var offset = offsetCount * (elementSize + this.contentSpacing);
                this.m_Content.anchoredPosition -= new Vector2(offset + (this.reverseDirection? currentSize : 0), 0);
                contentBounds.center -= new Vector3(offset + currentSize / 2, 0, 0);
                contentBounds.size = Vector3.zero;

                changed = true;
            }

            if (viewBounds.min.x - contentBounds.max.x > viewBounds.size.x && this.itemTypeEnd > this.itemTypeStart)
            {
                var maxItemTypeStart = -1;
                if (this.totalCount >= 0)
                {
                    maxItemTypeStart = Mathf.Max(0, this.totalCount - (this.itemTypeEnd - this.itemTypeStart));
                    maxItemTypeStart = maxItemTypeStart / this.contentConstraintCount * this.contentConstraintCount;
                }

                var currentSize = contentBounds.size.x;
                var elementSize = (currentSize - this.contentSpacing * (this.CurrentLines - 1)) / this.CurrentLines;
                this.ReturnToTempPool(true, this.itemTypeEnd - this.itemTypeStart);
                // TODO: fix with contentConstraint?
                this.itemTypeStart = this.itemTypeEnd;

                var offsetCount = Mathf.FloorToInt((viewBounds.min.x - contentBounds.max.x) / (elementSize + this.contentSpacing));
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

                var offset = offsetCount * (elementSize + this.contentSpacing);
                this.m_Content.anchoredPosition += new Vector2(offset + (this.reverseDirection? 0 : currentSize), 0);
                contentBounds.center += new Vector3(offset + currentSize / 2, 0, 0);
                contentBounds.size = Vector3.zero;

                changed = true;
            }

            if (viewBounds.max.x < contentBounds.max.x - this.threshold - this.m_ContentRightPadding)
            {
                float size = this.DeleteItemAtEnd(), totalSize = size;
                while (size > 0 && viewBounds.max.x < contentBounds.max.x - this.threshold - this.m_ContentRightPadding - totalSize)
                {
                    size = this.DeleteItemAtEnd();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (viewBounds.min.x > contentBounds.min.x + this.threshold + this.m_ContentLeftPadding)
            {
                float size = this.DeleteItemAtStart(), totalSize = size;
                while (size > 0 && viewBounds.min.x > contentBounds.min.x + this.threshold + this.m_ContentLeftPadding + totalSize)
                {
                    size = this.DeleteItemAtStart();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (viewBounds.max.x > contentBounds.max.x - this.m_ContentRightPadding)
            {
                float size = this.NewItemAtEnd(), totalSize = size;
                while (size > 0 && viewBounds.max.x > contentBounds.max.x - this.m_ContentRightPadding + totalSize)
                {
                    size = this.NewItemAtEnd();
                    totalSize += size;
                }

                if (totalSize > 0)
                {
                    changed = true;
                }
            }

            if (viewBounds.min.x < contentBounds.min.x + this.m_ContentLeftPadding)
            {
                float size = this.NewItemAtStart(), totalSize = size;
                while (size > 0 && viewBounds.min.x < contentBounds.min.x + this.m_ContentLeftPadding - totalSize)
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